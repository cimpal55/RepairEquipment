using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IEquipmentTypeService
    {
        public Task<List<EquipmentTypeRecord>> GetEquipmentTypeListAsync();
    }
}
