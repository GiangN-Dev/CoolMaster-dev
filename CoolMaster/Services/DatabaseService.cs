using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace CoolMaster.Services
{
    public class DatabaseService
    {
        private readonly string _connString;

        public DatabaseService()
        {
            _connString = ConfigurationManager.ConnectionStrings["CoolMasterConnString"].ConnectionString;
        }

        public async Task BackupDatabase(string backupPath)
        {
            using (var conn = new SqlConnection(_connString))
            {
                await conn.OpenAsync();
                var dbName = conn.Database;

                string sql = $"BACKUP DATABASE [{dbName}] TO DISK = @path WITH FORMAT, INIT, NAME = 'CoolMaster Backup';";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@path", backupPath);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task RestoreDatabase(string backupPath)
        {

            var builder = new SqlConnectionStringBuilder(_connString);
            string dbName = builder.InitialCatalog;


            builder.InitialCatalog = "master";
            string masterConnStr = builder.ToString();

            using (var conn = new SqlConnection(masterConnStr))
            {
                await conn.OpenAsync();

                string sql = $@"
                    ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [{dbName}] FROM DISK = @path WITH REPLACE;
                    ALTER DATABASE [{dbName}] SET MULTI_USER;";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@path", backupPath);
                    cmd.CommandTimeout = 120;
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
