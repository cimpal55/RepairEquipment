using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace RepairEquipment.Client
{
    public class SQLDataAccess : ISQLDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                var output = await con.QueryAsync<T>(sql, parameters);
                return output.ToList();
            }
        }

        public Task SaveData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.ExecuteAsync(sql, parameters);
            }
        }

    }
}