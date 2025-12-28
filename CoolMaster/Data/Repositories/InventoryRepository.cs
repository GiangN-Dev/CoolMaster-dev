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
    public class InventoryRepository : BaseRepository<InventoryLog>, IInventoryRepository
    {
        public InventoryRepository(string connectionString) : base(connectionString) { }

        public async Task<PagedResult<InventoryViewDTO>> GetInventoryStatusAsync(string keyword, int? categoryId, int pageIndex, int pageSize)
        {
            using (var conn = CreateConnection())
            {
                var param = new DynamicParameters();
                var whereBuilder = new StringBuilder(" WHERE p.IsDeleted = 0 ");

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    whereBuilder.Append(" AND (p.ProductName LIKE @Kw OR p.Barcode LIKE @Kw) ");
                    param.Add("Kw", "%" + keyword + "%");
                }

                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    whereBuilder.Append(" AND p.CategoryId = @CatId ");
                    param.Add("CatId", categoryId.Value);
                }

                // Query Data
                string sqlData = $@"
                    SELECT 
                        p.ProductId, p.Barcode, p.ProductName, p.Unit, p.UnitPrice,
                        p.StockWarehouse, p.StockCounter,
                        (p.StockWarehouse + p.StockCounter) as TotalStock,
                        c.CategoryName
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                    {whereBuilder}
                    ORDER BY p.StockWarehouse ASC -- Ưu tiên xem hàng sắp hết
                    OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";

                // Query Count
                string sqlCount = $@"
                    SELECT COUNT(1) FROM Products p 
                    {whereBuilder}";

                param.Add("Offset", (pageIndex - 1) * pageSize);
                param.Add("Size", pageSize);

                var multi = await conn.QueryMultipleAsync(sqlData + ";" + sqlCount, param);
                var items = await multi.ReadAsync<InventoryViewDTO>();
                var total = await multi.ReadFirstAsync<int>();

                return new PagedResult<InventoryViewDTO>(items, total, pageIndex, pageSize);
            }
        }

        public async Task<bool> ProcessStockTransactionAsync(InventoryLog log, int newStockWarehouse, int newStockCounter)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert Log
                        string sqlLog = @"
                            INSERT INTO InventoryLogs 
                            (ProductId, SupplierId, QuantityChange, StockBefore, StockAfter, ChangeType, ReferenceId, Note, CreatedByUserId, CreatedAt, IsDeleted)
                            VALUES 
                            (@ProductId, @SupplierId, @QuantityChange, @StockBefore, @StockAfter, @ChangeType, @ReferenceId, @Note, @CreatedByUserId, GETDATE(), 0)";

                        await conn.ExecuteAsync(sqlLog, log, transaction);

                        // 2. Update Product Stock
                        string sqlUpdateProduct = @"
                            UPDATE Products 
                            SET StockWarehouse = @NewWare, 
                                StockCounter = @NewCount, 
                                UpdatedAt = GETDATE()
                            WHERE ProductId = @Pid";

                        await conn.ExecuteAsync(sqlUpdateProduct, new
                        {
                            NewWare = newStockWarehouse,
                            NewCount = newStockCounter,
                            Pid = log.ProductId
                        }, transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Ném ra để Service xử lý message
                    }
                }
            }
        }
    }
}
