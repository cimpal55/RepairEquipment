using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace RepairEquipment.Client.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connString)
        {
            using (IDbConnection connection = new SqlConnection(connString))
            {
                {
                    var rows = await connection.QueryAsync<T>(sql, parameters);
                    return rows.ToList();
                }
            }
        }

        public Task SaveData<T>(string sql, T parameters, string connString)
        {
            using (IDbConnection connection = new SqlConnection(connString))
            {
                {
                    return connection.ExecuteAsync(sql, parameters);
                }
            }
        }
    }
}
