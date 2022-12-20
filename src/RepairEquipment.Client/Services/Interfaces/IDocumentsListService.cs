using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IDocumentsListService
    {
        public Task<List<DocumentsListItem>> GetListItemsAsync();

    }
}
