using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IEquipmentHistoryService
    {
        public Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryListAsync();
        public Task InsertEquipmentHistoryAsync(EquipmentHistoryRecord item);
    }
}
