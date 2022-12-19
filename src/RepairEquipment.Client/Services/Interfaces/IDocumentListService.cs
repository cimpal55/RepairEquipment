using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IDocumentListService
    {
        public Task<List<DocumentsListItem>> GetListItemsAsync();
    }
}
