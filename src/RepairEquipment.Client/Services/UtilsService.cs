using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class UtilsService : IUtilsService
    {
        private readonly ISqlDataAccess _conn;
        
        public UtilsService(ISqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task<string> GetClientNameById(int id)
        {
            string sql = @"SELECT Name 
                               FROM TBL_CONF_Clients
                               WHERE ID = @id";
            return _conn.LoadData<string, dynamic>(sql, new { ID = id }).ToString();
        }
        public async Task<string> GetEmployeeNameById(int id)
        {
            string sql = @"SELECT Name 
                               FROM TBL_CONF_Employees
                               WHERE ID = @id";
            return _conn.LoadData<string, dynamic>(sql, new { ID = id }).ToString();
        }
    }
}
