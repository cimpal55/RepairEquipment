using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class EquipmentTypeService : IEquipmentTypeService
    {
        private readonly ISqlDataAccess _data;
        public EquipmentTypeService(ISqlDataAccess data)
        {
            _data = data;
        }
        public Task<List<EquipmentTypeRecord>> GetEquipmentTypeListAsync()
        {
            string sql = "SELECT * FROM TBL_CONF_EquipmentTypes";
            return _data.LoadData<EquipmentTypeRecord, dynamic>(sql, new { });
        }
    }
}
