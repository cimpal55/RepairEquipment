using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IEquipmentHistoryService
    {
        public Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryListAsync();
        public Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryFromDbAsync();
        public Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryListAsyncByData(int id);
        public Task InsertEquipmentHistoryAsync(IEnumerable<EquipmentHistoryRecord> item);
    }
}
