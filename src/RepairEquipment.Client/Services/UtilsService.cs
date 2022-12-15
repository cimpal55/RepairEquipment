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
            string sql = "SELECT Name FROM TBL_CONF_Clients WHERE ID = @ID";
            var result = await _conn.LoadData<ClientRecord, dynamic>(sql, new { ID = id });
            return result.FirstOrDefault().Name ?? string.Empty;
        }
    }
}
