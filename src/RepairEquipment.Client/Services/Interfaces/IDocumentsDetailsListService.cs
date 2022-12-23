using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IDocumentsDetailsListService
    {
        public Task<List<DocumentsDetailsListItem>> GetListItemsAsync();
    }
}
