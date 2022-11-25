using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IDocumentService
    {
        public Task<List<DocumentRecord>> GetDocumentsListAsync();
        public Task<DocumentRecord?> GetDocumentsAsync(int id);
        public Task InsertDocumentAsync(DocumentRecord item);
        public Task UpdateDocumentAsync(DocumentRecord item);
        public Task DeleteDocumentAsync(DocumentRecord item);
    }
}
