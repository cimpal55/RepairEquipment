using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class EquipmentTypeService : IEquipmentTypeService
    {
        private readonly SqlDataAccess _conn;
        public EquipmentTypeService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task<List<EquipmentTypeRecord>> GetEquipmentTypeListAsync() =>
            await _conn
                .EquipmentTypeRecords
                .ToListAsync();
    }
}
