using CoolMaster.Common;
using CoolMaster.DTOs;
using CoolMaster.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
//Giải quyết việc riêng (Tìm kiếm, Lọc tồn kho, Lấy hàng sắp hết hạn...).

namespace CoolMaster.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        // Constructor truyền chuỗi kết nối xuống cho BaseRepository
        public ProductRepository(string connectionString) : base(connectionString) { }

        // --- GHI ĐÈ (OVERRIDE) CÁC HÀM CRUD CỦA BASE REPOSITORY ---

        public override async Task<int> AddAsync(Product product)
        {
            var sql = @"
                INSERT INTO Products 
                (Barcode, ProductName, UnitPrice, Unit, StockWarehouse, StockCounter, CategoryId, Brand, WarrantyMonth, Description, CreatedAt, IsDeleted)
                VALUES 
                (@Barcode, @ProductName, @UnitPrice, @Unit, @StockWarehouse, @StockCounter, @CategoryId, @Brand, @WarrantyMonth, @Description, GETDATE(), 0);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var conn = CreateConnection())
            {
                // Dapper sẽ tự map properties của product vào @Parameters
                return await conn.ExecuteScalarAsync<int>(sql, product);
            }
        }

        // --- CÁC HÀM RIÊNG CỦA PRODUCT ---

        public async Task<IEnumerable<ProductViewDTO>> GetAllViewsAsync()
        {
            var sql = @"
                SELECT 
                    p.ProductId, p.Barcode, p.ProductName, p.UnitPrice, 
                    p.StockWarehouse, p.StockCounter,
                    (p.StockWarehouse + p.StockCounter) AS TotalStock, 
                    p.Unit, c.CategoryName, p.ImageUrl       
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                WHERE p.IsDeleted = 0
                ORDER BY p.ProductName";

            using (var conn = CreateConnection())
            {
                return await conn.QueryAsync<ProductViewDTO>(sql);
            }
        }

        public async Task<PagedResult<ProductViewDTO>> GetPagedViewsAsync(string keyword, int pageIndex, int pageSize)
        {
            // Tận dụng hàm tìm kiếm nâng cao (GetPagedAdvancedAsync) để đỡ viết lặp logic
            // Tạo filter từ keyword
            var filter = new ProductFilterRequest { Keyword = keyword };
            return await GetPagedAdvancedAsync(filter, pageIndex, pageSize);
        }

        public async Task<List<string>> GetDistinctBrandsAsync()
        {
            using (var conn = CreateConnection())
            {
                var result = await conn.QueryAsync<string>(
                    "SELECT DISTINCT Brand FROM Products WHERE IsDeleted = 0 AND Brand IS NOT NULL ORDER BY Brand"
                );
                return result.ToList();
            }
        }

        public async Task<List<string>> GetDistinctCategoriesAsync()
        {
            using (var conn = CreateConnection())
            {
                var result = await conn.QueryAsync<string>(
                    "SELECT CategoryName FROM Categories ORDER BY CategoryName"
                );
                return result.ToList();
            }
        }

        public async Task<PagedResult<ProductViewDTO>> GetPagedAdvancedAsync(ProductFilterRequest filter, int pageIndex, int pageSize)
        {
            using (var conn = CreateConnection())
            {
                var param = new DynamicParameters();
                var whereBuilder = new StringBuilder();
                whereBuilder.Append(" WHERE p.IsDeleted = 0 ");

                // --- Build Conditions ---
                if (!string.IsNullOrWhiteSpace(filter.Keyword))
                {
                    whereBuilder.Append(" AND (p.ProductName LIKE @Kw OR p.Barcode LIKE @Kw) ");
                    param.Add("Kw", "%" + filter.Keyword + "%");
                }

                if (!string.IsNullOrWhiteSpace(filter.CategoryName) && filter.CategoryName != "Tất cả")
                {
                    whereBuilder.Append(" AND c.CategoryName = @CatName ");
                    param.Add("CatName", filter.CategoryName);
                }

                if (!string.IsNullOrWhiteSpace(filter.Brand) && filter.Brand != "Tất cả")
                {
                    whereBuilder.Append(" AND p.Brand = @Brand ");
                    param.Add("Brand", filter.Brand);
                }

                if (filter.PriceFrom.HasValue)
                {
                    whereBuilder.Append(" AND p.UnitPrice >= @PriceFrom ");
                    param.Add("PriceFrom", filter.PriceFrom);
                }
                if (filter.PriceTo.HasValue)
                {
                    whereBuilder.Append(" AND p.UnitPrice <= @PriceTo ");
                    param.Add("PriceTo", filter.PriceTo);
                }

                if (!string.IsNullOrWhiteSpace(filter.StockStatus) && filter.StockStatus != "Tất cả")
                {
                    switch (filter.StockStatus)
                    {
                        case "Còn hàng":
                            whereBuilder.Append(" AND (p.StockWarehouse + p.StockCounter) > 0 ");
                            break;
                        case "Hết hàng":
                            whereBuilder.Append(" AND (p.StockWarehouse + p.StockCounter) <= 0 ");
                            break;
                        case "Sắp hết":
                            whereBuilder.Append(" AND (p.StockWarehouse + p.StockCounter) > 0 AND (p.StockWarehouse + p.StockCounter) <= 5 ");
                            break;
                    }
                }

                // --- Query Data ---
                string dataSql = $@"
                    SELECT 
                        p.ProductId, p.Barcode, p.ProductName, p.UnitPrice, 
                        p.StockWarehouse, p.StockCounter,
                        (p.StockWarehouse + p.StockCounter) AS TotalStock, 
                        p.Unit, c.CategoryName 
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                    {whereBuilder}
                    ORDER BY p.CreatedAt DESC
                    OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";

                // --- Query Count ---
                string countSql = $@"
                    SELECT COUNT(1) 
                    FROM Products p 
                    LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                    {whereBuilder}";

                param.Add("Offset", (pageIndex - 1) * pageSize);
                param.Add("Size", pageSize);

                var multi = await conn.QueryMultipleAsync(dataSql + ";" + countSql, param);

                var items = await multi.ReadAsync<ProductViewDTO>();
                var totalCount = await multi.ReadFirstAsync<int>();

                return new PagedResult<ProductViewDTO>(items, totalCount, pageIndex, pageSize);
            }
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            using (var conn = CreateConnection())
            {
                // Lấy thông tin sản phẩm theo ID, chỉ lấy sản phẩm chưa bị xóa
                string sql = "SELECT * FROM Products WHERE ProductId = @Id AND IsDeleted = 0";

                // Dapper sẽ map các cột SQL vào object Product
                return await conn.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
            }
        }
    }
}
