using CoolMaster.Common;
using CoolMaster.DTOs;
using CoolMaster.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Data.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString) { }

        // --- 1. HÀM RIÊNG CỦA SUPPLIER (Lấy danh sách phân trang) ---
        public async Task<PagedResult<SupplierViewDTO>> GetPagedViewsAsync(string keyword, int pageIndex, int pageSize)
        {
            using (var conn = CreateConnection())
            {
                var param = new DynamicParameters();
                var whereBuilder = new StringBuilder();

                // Mặc định chỉ lấy dòng chưa xóa
                whereBuilder.Append(" WHERE IsDeleted = 0 ");

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    // Tìm theo Tên NCC, Người liên hệ hoặc SĐT
                    whereBuilder.Append(" AND (SupplierName LIKE @Kw OR ContactPerson LIKE @Kw OR Phone LIKE @Kw) ");
                    param.Add("Kw", "%" + keyword + "%");
                }

                // Query lấy dữ liệu
                string dataSql = $@"
                    SELECT SupplierId, SupplierName, ContactPerson, Phone, Address
                    FROM Suppliers
                    {whereBuilder}
                    ORDER BY CreatedAt DESC
                    OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";

                // Query đếm tổng
                string countSql = $@"SELECT COUNT(1) FROM Suppliers {whereBuilder}";

                param.Add("Offset", (pageIndex - 1) * pageSize);
                param.Add("Size", pageSize);

                var multi = await conn.QueryMultipleAsync(dataSql + ";" + countSql, param);

                var items = await multi.ReadAsync<SupplierViewDTO>();
                var totalCount = await multi.ReadFirstAsync<int>();

                return new PagedResult<SupplierViewDTO>(items, totalCount, pageIndex, pageSize);
            }
        }

        // --- 2. IMPLEMENT CÁC HÀM CÒN THIẾU TỪ INTERFACE (CRUD CƠ BẢN) ---

        // Thêm mới
        public override async Task<int> AddAsync(Supplier entity)
        {
            var sql = @"
                INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Address, CreatedAt, IsDeleted)
                VALUES (@SupplierName, @ContactPerson, @Phone, @Address, GETDATE(), 0);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var conn = CreateConnection())
            {
                return await conn.ExecuteScalarAsync<int>(sql, entity);
            }
        }

        public override async Task<bool> UpdateAsync(Supplier entity)
        {
            var sql = @"
                UPDATE Suppliers 
                SET SupplierName = @SupplierName,
                    ContactPerson = @ContactPerson,
                    Phone = @Phone,
                    Address = @Address,
                    UpdatedAt = GETDATE()
                WHERE SupplierId = @SupplierId";

            using (var conn = CreateConnection())
            {
                var rows = await conn.ExecuteAsync(sql, entity);
                return rows > 0;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var sql = @"
                UPDATE Suppliers 
                SET IsDeleted = 1, 
                    UpdatedAt = GETDATE()
                WHERE SupplierId = @Id";

            using (var conn = CreateConnection())
            {
                var rows = await conn.ExecuteAsync(sql, new { Id = id });
                return rows > 0;
            }
        }

        public override async Task<Supplier> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Suppliers WHERE SupplierId = @Id AND IsDeleted = 0";
            using (var conn = CreateConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<Supplier>(sql, new { Id = id });
            }
        }

        public override async Task<IEnumerable<Supplier>> GetAllAsync()
        {   
            var sql = "SELECT * FROM Suppliers WHERE IsDeleted = 0 ORDER BY CreatedAt DESC";
            using (var conn = CreateConnection())
            {
                return await conn.QueryAsync<Supplier>(sql);
            }
        }
    }
}
