using ExportFile.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using NPOI.OpenXmlFormats.Shared;
using System.Data;

namespace ExportFile.Repository.Impl
{
    public class DataRepository : IDataRepository
    {
        private readonly ConnectionSql _connectionSql;

        public DataRepository(ConnectionSql connectionSql)
        {
            _connectionSql = connectionSql;
        }
        public List<DataModel> GetAll()
        {
            List<DataModel> data = new List<DataModel>();
            using var conn = _connectionSql.CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "sp_GetData";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(new DataModel
                    {
                        FullName = reader.GetString(0),
                        Email = reader.GetString(1),
                        BirthDate = reader["BirthDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["BirthDate"]),
                        Address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString(),
                        Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                        Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString(),
                        Position = reader["Position"] == DBNull.Value ? null : reader["Position"].ToString(),
                        Salary = Convert.ToDecimal(reader["Salary"])
                    });
                };

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return data;
        }
    }
}
