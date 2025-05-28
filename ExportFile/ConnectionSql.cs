using Microsoft.Data.SqlClient;
using System.Data;

namespace ExportFile
{
    public class ConnectionSql
    {
        private readonly IConfiguration _config;

        public ConnectionSql(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
