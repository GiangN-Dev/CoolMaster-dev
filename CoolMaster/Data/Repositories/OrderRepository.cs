using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Common;
using CoolMaster.DTOs;
using CoolMaster.Model;
using Dapper;

namespace CoolMaster.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString) { }

        // --- HÀM 1: DÙNG CHO POS (Tạo đơn hàng) ---
        public async Task<int> CreateOrderTransactionAsync(Order order, List<OrderDetail> details, int userId)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert Order
                        string sqlOrder = @"
                            INSERT INTO Orders (TotalAmount, PaymentMethod, OrderStatus, Note, CustomerId, StaffId, CreatedAt, IsDeleted)
                            VALUES (@TotalAmount, @PaymentMethod, @OrderStatus, @Note, @CustomerId, @StaffId, GETDATE(), 0);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                        int orderId = await conn.ExecuteScalarAsync<int>(sqlOrder, order, trans);

                        // 2. Xử lý Chi tiết & Tồn kho
                        foreach (var item in details)
                        {
                            item.OrderId = orderId;
                            string sqlDetail = @"
                                INSERT INTO OrderDetails (Quantity, SalePrice, OrderId, ProductId, CreatedAt, IsDeleted)
                                VALUES (@Quantity, @SalePrice, @OrderId, @ProductId, GETDATE(), 0)";
                            await conn.ExecuteAsync(sqlDetail, item, trans);

                            if (order.OrderStatus == OrderStatus.Completed)
                            {
                                string sqlCheckStock = "SELECT StockCounter FROM Products WHERE ProductId = @Id";
                                int currentStock = await conn.ExecuteScalarAsync<int>(sqlCheckStock, new { Id = item.ProductId }, trans);

                                if (currentStock < item.Quantity)
                                {
                                    throw new Exception($"Sản phẩm ID {item.ProductId} không đủ hàng tại quầy (Còn: {currentStock}).");
                                }

                                string sqlUpdateStock = @"
                                    UPDATE Products 
                                    SET StockCounter = StockCounter - @Qty, UpdatedAt = GETDATE()
                                    WHERE ProductId = @Pid";
                                await conn.ExecuteAsync(sqlUpdateStock, new { Qty = item.Quantity, Pid = item.ProductId }, trans);

                                string sqlLog = @"
                                    INSERT INTO InventoryLogs 
                                    (ProductId, QuantityChange, StockBefore, StockAfter, ChangeType, ReferenceId, Note, CreatedByUserId, CreatedAt, IsDeleted)
                                    VALUES 
                                    (@ProductId, @Change, @Before, @After, @Type, @Ref, @Note, @User, GETDATE(), 0)";

                                await conn.ExecuteAsync(sqlLog, new
                                {
                                    ProductId = item.ProductId,
                                    Change = -item.Quantity,
                                    Before = currentStock,
                                    After = currentStock - item.Quantity,
                                    Type = InventoryChangeType.Sale,
                                    Ref = $"ORD-{orderId}",
                                    Note = "Bán lẻ",
                                    User = userId
                                }, trans);
                            }
                        }

                        trans.Commit();
                        return orderId;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        // --- HÀM 2: DÙNG CHO LỊCH SỬ ĐƠN HÀNG ---
        public async Task<PagedResult<OrderHistoryDTO>> GetPagedHistoryAsync(string keyword, DateTime? fromDate, DateTime? toDate, int pageIndex, int pageSize)
        {
            using (var conn = CreateConnection())
            {
                var param = new DynamicParameters();
                var whereBuilder = new StringBuilder(" WHERE o.IsDeleted = 0 ");

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    whereBuilder.Append(" AND (c.FullName LIKE @Kw OR c.PhoneNumber LIKE @Kw OR CAST(o.OrderId AS NVARCHAR) LIKE @Kw) ");
                    param.Add("Kw", "%" + keyword + "%");
                }

                if (fromDate.HasValue)
                {
                    whereBuilder.Append(" AND o.CreatedAt >= @From ");
                    param.Add("From", fromDate.Value);
                }
                if (toDate.HasValue)
                {
                    whereBuilder.Append(" AND o.CreatedAt <= @To ");
                    param.Add("To", toDate.Value);
                }

                // SỬA: Thêm ISNULL(c.FullName, N'Khách lẻ')
                string sqlData = $@"
                    SELECT 
                        o.OrderId, 
                        o.CreatedAt, 
                        o.TotalAmount, 
                        o.OrderStatus, 
                        o.PaymentMethod,
                        ISNULL(c.FullName, N'Khách lẻ') AS CustomerName,
                        u.FullName AS StaffName
                    FROM Orders o
                    LEFT JOIN Customers c ON o.CustomerId = c.CustomerId
                    LEFT JOIN Users u ON o.StaffId = u.UserId
                    {whereBuilder}
                    ORDER BY o.CreatedAt DESC
                    OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";

                string sqlCount = $@"
                    SELECT COUNT(1) 
                    FROM Orders o
                    LEFT JOIN Customers c ON o.CustomerId = c.CustomerId
                    {whereBuilder}";

                param.Add("Offset", (pageIndex - 1) * pageSize);
                param.Add("Size", pageSize);

                var multi = await conn.QueryMultipleAsync(sqlData + ";" + sqlCount, param);
                var items = await multi.ReadAsync<OrderHistoryDTO>();
                var totalCount = await multi.ReadFirstAsync<int>();

                return new PagedResult<OrderHistoryDTO>(items, totalCount, pageIndex, pageSize);
            }
        }

        // --- HÀM 3: DÙNG CHO IN HÓA ĐƠN ---
        public async Task<BillViewModel> GetBillDetailAsync(int orderId)
        {
            using (var conn = CreateConnection())
            {
                // SỬA: Thêm ISNULL để đảm bảo hiện Khách lẻ
                string sqlOrder = @"
                    SELECT 
                        o.OrderId, 
                        o.CreatedAt, 
                        o.TotalAmount, 
                        o.PaymentMethod,
                        ISNULL(c.FullName, N'Khách lẻ') AS CustomerName, 
                        ISNULL(c.PhoneNumber, '') AS PhoneNumber, 
                        ISNULL(c.Address, '') AS Address,
                        u.FullName AS StaffName
                    FROM Orders o
                    LEFT JOIN Customers c ON o.CustomerId = c.CustomerId
                    LEFT JOIN Users u ON o.StaffId = u.UserId
                    WHERE o.OrderId = @Id";

                var bill = await conn.QueryFirstOrDefaultAsync<BillViewModel>(sqlOrder, new { Id = orderId });

                if (bill != null)
                {
                    string sqlDetails = @"
                        SELECT 
                            p.ProductName, 
                            od.Quantity, 
                            od.SalePrice,
                            p.Unit
                        FROM OrderDetails od
                        JOIN Products p ON od.ProductId = p.ProductId
                        WHERE od.OrderId = @Id";

                    var items = await conn.QueryAsync<OrderDetailDTO>(sqlDetails, new { Id = orderId });
                    bill.Items = items.AsList();
                }

                return bill;
            }
        }
    }
}
