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
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public async Task<(IEnumerable<UserViewDTO> Items, int TotalCount)> GetUsersAsync(string keyword, int pageIndex, int pageSize)
        {
            using (var conn = CreateConnection())
            {
                var sql = @"
                    SELECT COUNT(*) FROM Users WHERE IsDeleted = 0 AND (FullName LIKE @Key OR StaffCode LIKE @Key OR PhoneNumber LIKE @Key);
                    SELECT UserId, StaffCode, FullName, Role, PhoneNumber, Email, Address
                    FROM Users
                    WHERE IsDeleted = 0 AND (FullName LIKE @Key OR StaffCode LIKE @Key OR PhoneNumber LIKE @Key)
                    ORDER BY UserId DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

                var p = new { Key = $"%{keyword}%", Offset = (pageIndex - 1) * pageSize, PageSize = pageSize };

                using (var multi = await conn.QueryMultipleAsync(sql, p))
                {
                    var total = await multi.ReadFirstAsync<int>();
                    var items = (await multi.ReadAsync<UserViewDTO>()).ToList();
                    return (items, total);
                }
            }
        }

        public override async Task<int> AddAsync(User entity)
        {
            using (var conn = CreateConnection())
            {
                var sql = @"INSERT INTO Users (StaffCode, FullName, Role, PhoneNumber, Email, Address, Password, IsDeleted) 
                            VALUES (@StaffCode, @FullName, @Role, @PhoneNumber, @Email, @Address, @Password, 0); 
                            SELECT CAST(SCOPE_IDENTITY() as int);";
                // Đã có await -> Hết lỗi
                return await conn.ExecuteScalarAsync<int>(sql, entity);
            }
        }

        public override async Task<bool> UpdateAsync(User entity)
        {
            using (var conn = CreateConnection())
            {
                var sql = @"UPDATE Users SET FullName = @FullName, Role = @Role, PhoneNumber = @PhoneNumber, Email = @Email, Address = @Address WHERE UserId = @UserId";
                // Đã có await -> Hết lỗi
                return await conn.ExecuteAsync(sql, entity) > 0;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            using (var conn = CreateConnection())
            {
                var sql = "UPDATE Users SET IsDeleted = 1 WHERE UserId = @Id";
                // Đã có await -> Hết lỗi
                return await conn.ExecuteAsync(sql, new { Id = id }) > 0;
            }
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            using (var conn = CreateConnection())
            {
                // Đã có await -> Hết lỗi
                return await conn.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE UserId = @Id AND IsDeleted = 0", new { Id = id });
            }
        }
    }
}
