using CoolMaster.Common;
using CoolMaster.DTOs;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly string _connectionString;
        public ReportRepository(string connectionString) => _connectionString = connectionString;
        protected IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<PagedResult<RevenueReportDTO>> GetRevenueReportAsync(DateTime fromDate, DateTime toDate, bool byMonth, int page, int size)
        {
            using (var conn = CreateConnection())
            {
                string dateFormat = byMonth ? "FORMAT(CreatedAt, 'MM/yyyy')" : "FORMAT(CreatedAt, 'dd/MM/yyyy')";
                string groupBy = dateFormat;

                string sqlData = $@"
                    SELECT 
                        {dateFormat} as TimeLabel,
                        COUNT(OrderId) as OrderCount,
                        SUM(TotalAmount) as TotalRevenue
                    FROM Orders
                    WHERE IsDeleted = 0 AND OrderStatus = 1 -- Completed
                    AND CreatedAt >= @From AND CreatedAt <= @To
                    GROUP BY {groupBy}
                    ORDER BY MIN(CreatedAt) DESC
                    OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";

                string sqlCount = $@"
                    SELECT COUNT(DISTINCT {groupBy})
                    FROM Orders
                    WHERE IsDeleted = 0 AND OrderStatus = 1
                    AND CreatedAt >= @From AND CreatedAt <= @To";

                var param = new { From = fromDate, To = toDate, Offset = (page - 1) * size, Size = size };

                var multi = await conn.QueryMultipleAsync(sqlData + ";" + sqlCount, param);
                var items = await multi.ReadAsync<RevenueReportDTO>();
                var total = await multi.ReadFirstAsync<int>();

                return new PagedResult<RevenueReportDTO>(items, total, page, size);
            }
        }

        public async Task<PagedResult<ProductPerformanceDTO>> GetProductPerformanceAsync(DateTime fromDate, DateTime toDate, string keyword, bool orderByRevenue, int page, int size)
        {
            using (var conn = CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("From", fromDate);
                param.Add("To", toDate);
                param.Add("Offset", (page - 1) * size);
                param.Add("Size", size);

                var whereBuilder = new StringBuilder(" WHERE o.IsDeleted = 0 AND o.OrderStatus = 1 AND o.CreatedAt >= @From AND o.CreatedAt <= @To ");

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    whereBuilder.Append(" AND (p.ProductName LIKE @Kw OR p.Barcode LIKE @Kw) ");
                    param.Add("Kw", "%" + keyword + "%");
                }

                string orderBy = orderByRevenue ? "SUM(od.SubTotal) DESC" : "SUM(od.Quantity) DESC";

                string sqlData = $@"
                    SELECT 
                        p.ProductId, p.Barcode, p.ProductName, c.CategoryName,
                        SUM(od.Quantity) as QuantitySold,
                        SUM(od.SubTotal) as RevenueGenerated
                    FROM OrderDetails od
                    JOIN Orders o ON od.OrderId = o.OrderId
                    JOIN Products p ON od.ProductId = p.ProductId
                    LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                    {whereBuilder}
                    GROUP BY p.ProductId, p.Barcode, p.ProductName, c.CategoryName
                    ORDER BY {orderBy}
                    OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";

                // Count distinct products sold
                string sqlCount = $@"
                    SELECT COUNT(DISTINCT p.ProductId)
                    FROM OrderDetails od
                    JOIN Orders o ON od.OrderId = o.OrderId
                    JOIN Products p ON od.ProductId = p.ProductId
                    {whereBuilder}";

                var multi = await conn.QueryMultipleAsync(sqlData + ";" + sqlCount, param);
                var items = await multi.ReadAsync<ProductPerformanceDTO>();
                var total = await multi.ReadFirstAsync<int>();

                return new PagedResult<ProductPerformanceDTO>(items, total, page, size);
            }
        }

        public async Task<Tuple<decimal, int>> GetSummaryAsync(DateTime fromDate, DateTime toDate)
        {
            using (var conn = CreateConnection())
            {
                string sql = @"
                    SELECT ISNULL(SUM(TotalAmount), 0), COUNT(OrderId)
                    FROM Orders
                    WHERE IsDeleted = 0 AND OrderStatus = 1
                    AND CreatedAt >= @From AND CreatedAt <= @To";

                // Dapper map về Tuple không trực tiếp được như QueryFirst, dùng dynamic cho nhanh
                var result = await conn.QueryFirstOrDefaultAsync(sql, new { From = fromDate, To = toDate });

                // Vì result là dynamic (DapperRow), ta ép kiểu thủ công
                IDictionary<string, object> row = result;
                if (row != null)
                {
                    var revenue = Convert.ToDecimal(row.Values.ElementAt(0));
                    var count = Convert.ToInt32(row.Values.ElementAt(1));
                    return Tuple.Create(revenue, count);
                }
                return Tuple.Create(0m, 0);
            }
        }
    }
}
