using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IEquipmentHistoryService
    {
        public Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryListAsync();
        public Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryListAsyncById(int id);
        public Task InsertEquipmentHistoryAsync(EquipmentHistoryRecord item);
    }
}
