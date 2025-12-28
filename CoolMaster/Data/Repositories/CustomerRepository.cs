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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString) { }

        public override async Task<int> AddAsync(Customer entity)
        {
            using (var conn = CreateConnection())
            {
                // Câu lệnh SQL thêm mới và lấy về ID vừa tạo
                string sql = @"
                    INSERT INTO Customers 
                    (FullName, PhoneNumber, Address, CreatedAt, IsDeleted)
                    VALUES 
                    (@FullName, @PhoneNumber, @Address, GETDATE(), 0);
                    
                    SELECT CAST(SCOPE_IDENTITY() as int);";

                // Thực thi và trả về ID của khách hàng mới
                return await conn.ExecuteScalarAsync<int>(sql, entity);
            }
        }

        public async Task<PagedResult<CustomerDTO>> GetPagedListAsync(string keyword, int pageIndex, int pageSize)
        {
            using (var conn = CreateConnection())
            {
                var param = new DynamicParameters();
                var whereBuilder = new StringBuilder(" WHERE IsDeleted = 0 ");

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    whereBuilder.Append(" AND (FullName LIKE @Kw OR PhoneNumber LIKE @Kw) ");
                    param.Add("Kw", "%" + keyword + "%");
                }

                string sqlData = $@"
                    SELECT CustomerId, FullName, PhoneNumber, Address, CreatedAt
                    FROM Customers
                    {whereBuilder}
                    ORDER BY CreatedAt DESC
                    OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";

                string sqlCount = $"SELECT COUNT(1) FROM Customers {whereBuilder}";

                param.Add("Offset", (pageIndex - 1) * pageSize);
                param.Add("Size", pageSize);

                var multi = await conn.QueryMultipleAsync(sqlData + ";" + sqlCount, param);
                var items = await multi.ReadAsync<CustomerDTO>();
                var total = await multi.ReadFirstAsync<int>();

                return new PagedResult<CustomerDTO>(items, total, pageIndex, pageSize);
            }
        }
    }
}
