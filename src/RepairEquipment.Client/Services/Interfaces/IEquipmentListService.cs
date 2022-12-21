using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IEquipmentListService
    {
        public Task<List<EquipmentListItem>> GetListItemsAsync();

    }
}
