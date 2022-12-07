using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IEquipmentService
    {
        public Task<List<EquipmentRecord>> GetEquipmentListAsync();
        public Task<EquipmentRecord?> GetEquipmentDetailsAsync(int id);
        public Task InsertEquipmentAsync(EquipmentRecord item);
        public Task UpdateEquipmentAsync(EquipmentRecord item);
        public Task DeleteEquipmentAsync(EquipmentRecord item);
    }
}
