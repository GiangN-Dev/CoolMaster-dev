using CoolMaster.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
// Giải quyết việc chung (CRUD).

namespace CoolMaster.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly string _connectionString;
        public BaseRepository(string connectionString) => _connectionString = connectionString;

        protected IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        protected string GetTableName()
        {
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            return tableAttr != null ? tableAttr.Name : type.Name + "s";
        }

        // Helper: detect whether table has a given column by reading schema (safe)
        private async Task<bool> TableHasColumnAsync(IDbConnection conn, string tableName, string columnName)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    if (conn is SqlConnection sqlConn)
                        await sqlConn.OpenAsync();
                    else
                        conn.Open();
                }

                // Read zero/one row to get schema
                using (var reader = await conn.ExecuteReaderAsync($"SELECT TOP 1 * FROM [{tableName}]"))
                {
                    var schema = reader.GetSchemaTable();
                    if (schema == null) return false;
                    return schema.Rows.Cast<System.Data.DataRow>()
                        .Any(r => string.Equals(r["ColumnName"]?.ToString(), columnName, StringComparison.OrdinalIgnoreCase));
                }
            }
            catch
            {
                return false;
            }
        }

        // Hàm này CÓ await nên giữ async -> ĐÚNG CHUẨN
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var conn = CreateConnection())
            {
                var tableName = GetTableName();

                // If table has IsDeleted column, return only non-deleted rows; otherwise return all
                bool hasIsDeleted = await TableHasColumnAsync(conn, tableName, "IsDeleted");
                if (hasIsDeleted)
                {
                    return await conn.QueryAsync<T>($"SELECT * FROM [{tableName}] WHERE IsDeleted = 0");
                }
                else
                {
                    return await conn.QueryAsync<T>($"SELECT * FROM [{tableName}]");
                }
            }
        }

        // --- Helpers ---
        private static bool IsSimplePropertyType(Type type)
        {
            var t = Nullable.GetUnderlyingType(type) ?? type;
            if (t.IsEnum) return true;
            if (t.IsPrimitive) return true;
            if (t == typeof(string)
                || t == typeof(decimal)
                || t == typeof(DateTime)
                || t == typeof(Guid)
                || t == typeof(DateTimeOffset)
                || t == typeof(TimeSpan)
                || t == typeof(bool)
                ) return true;
            return false;
        }

        // GetByIdAsync: generic implementation using detected key column
        public virtual async Task<T> GetByIdAsync(int id)
        {
            using (var conn = CreateConnection())
            {
                var tableName = GetTableName();

                var propsAll = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
                var keyProp = propsAll.FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null)
                              ?? propsAll.FirstOrDefault(p => string.Equals(p.Name, typeof(T).Name + "Id", StringComparison.OrdinalIgnoreCase))
                              ?? propsAll.FirstOrDefault(p => string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase));

                var keyName = keyProp != null ? keyProp.Name : "Id";

                if (conn.State != ConnectionState.Open)
                {
                    if (conn is SqlConnection sqlConn)
                        await sqlConn.OpenAsync();
                    else
                        conn.Open();
                }

                var sql = $"SELECT * FROM [{tableName}] WHERE [{keyName}] = @Id";
                return await conn.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
            }
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            using (var conn = CreateConnection())
            {
                var tableName = GetTableName();

                // Lấy tất cả property public instance — chỉ giữ các property scalar (không phải navigation/collections)
                var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p =>
                        p.CanRead &&
                        p.GetCustomAttribute<NotMappedAttribute>() == null &&
                        IsSimplePropertyType(p.PropertyType)
                    )
                    .ToList();

                // Tìm property là Key (KeyAttribute) hoặc theo tên {ClassName}Id hoặc Id
                var keyProp = props.FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null)
                              ?? props.FirstOrDefault(p => string.Equals(p.Name, typeof(T).Name + "Id", StringComparison.OrdinalIgnoreCase))
                              ?? props.FirstOrDefault(p => string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase));

                // Những cột để insert = tất cả trừ key (key thường là identity)
                var insertProps = props.Where(p => p != keyProp && p.GetSetMethod() != null).ToList();

                if (!insertProps.Any())
                    throw new InvalidOperationException("Không tìm thấy trường nào để INSERT cho loại " + typeof(T).Name);

                var columns = insertProps.Select(p => $"[{p.Name}]");
                var parameters = insertProps.Select(p => "@" + p.Name);

                // SQL dùng OUTPUT INSERTED.[Key] để trả về ID mới sinh
                var outputColumn = keyProp != null ? keyProp.Name : "Id";
                var sql = $"INSERT INTO [{tableName}] ({string.Join(", ", columns)}) OUTPUT INSERTED.[{outputColumn}] VALUES ({string.Join(", ", parameters)})";

                var dyn = new DynamicParameters();
                foreach (var p in insertProps)
                {
                    var val = p.GetValue(entity);
                    dyn.Add("@" + p.Name, val);
                }

                // Open connection (SqlConnection has OpenAsync)
                if (conn.State != ConnectionState.Open)
                {
                    if (conn is SqlConnection sqlConn)
                    {
                        await sqlConn.OpenAsync();
                    }
                    else
                    {
                        conn.Open();
                    }
                }

                var newId = await conn.ExecuteScalarAsync<int>(sql, dyn);
                return newId;
            }
        }

        // Basic generic UpdateAsync implementation (can be overridden by concrete repo)
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            using (var conn = CreateConnection())
            {
                var tableName = GetTableName();

                var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p =>
                        p.CanRead &&
                        p.CanWrite &&
                        p.GetCustomAttribute<NotMappedAttribute>() == null &&
                        IsSimplePropertyType(p.PropertyType)
                    )
                    .ToList();

                var keyProp = props.FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null)
                              ?? props.FirstOrDefault(p => string.Equals(p.Name, typeof(T).Name + "Id", StringComparison.OrdinalIgnoreCase))
                              ?? props.FirstOrDefault(p => string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase));

                if (keyProp == null)
                    throw new InvalidOperationException("Không tìm thấy khóa để UPDATE cho loại " + typeof(T).Name);

                var updateProps = props.Where(p => p != keyProp).ToList();
                if (!updateProps.Any()) return false;

                var setClause = string.Join(", ", updateProps.Select(p => $"[{p.Name}] = @{p.Name}"));
                var sql = $"UPDATE [{tableName}] SET {setClause} WHERE [{keyProp.Name}] = @{keyProp.Name}";

                var dyn = new DynamicParameters();
                foreach (var p in updateProps)
                {
                    dyn.Add("@" + p.Name, p.GetValue(entity));
                }
                dyn.Add("@" + keyProp.Name, keyProp.GetValue(entity));

                if (conn.State != ConnectionState.Open)
                {
                    if (conn is SqlConnection sqlConn)
                        await sqlConn.OpenAsync();
                    else
                        conn.Open();
                }

                var rows = await conn.ExecuteAsync(sql, dyn);
                return rows > 0;
            }
        }

        // Generic DeleteAsync: soft delete if IsDeleted column exists, otherwise hard delete.
        public virtual async Task<bool> DeleteAsync(int id)
        {
            using (var conn = CreateConnection())
            {
                var tableName = GetTableName();

                // Open connection for schema check
                if (conn.State != ConnectionState.Open)
                {
                    if (conn is SqlConnection sqlConn)
                        await sqlConn.OpenAsync();
                    else
                        conn.Open();
                }

                // Determine key name
                var propsAll = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
                var keyProp = propsAll.FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null)
                              ?? propsAll.FirstOrDefault(p => string.Equals(p.Name, typeof(T).Name + "Id", StringComparison.OrdinalIgnoreCase))
                              ?? propsAll.FirstOrDefault(p => string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase));
                var keyName = keyProp != null ? keyProp.Name : "Id";

                // Prefer soft delete if column exists
                bool hasIsDeleted = await TableHasColumnAsync(conn, tableName, "IsDeleted");

                if (hasIsDeleted)
                {
                    var sql = $"UPDATE [{tableName}] SET [IsDeleted] = 1 WHERE [{keyName}] = @Id";
                    var rows = await conn.ExecuteAsync(sql, new { Id = id });
                    return rows > 0;
                }
                else
                {
                    var sql = $"DELETE FROM [{tableName}] WHERE [{keyName}] = @Id";
                    var rows = await conn.ExecuteAsync(sql, new { Id = id });
                    return rows > 0;
                }
            }
        }
    }
}
