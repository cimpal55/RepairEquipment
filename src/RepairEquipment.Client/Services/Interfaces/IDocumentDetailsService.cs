using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IDocumentDetailsService
    {
        public Task InsertDocumentDetailAsync(DocumentDetailRecord item);
        public Task UpdateDocumentDetailAsync(DocumentDetailRecord item);
        public Task DeleteDocumentDetailAsync(DocumentDetailRecord item);
        public Task<IEnumerable<DocumentDetailRecord>> GetDocumentDetailsAsync(int docId);
        public Task<IEnumerable<DocumentDetailRecord>> GetDocumentDetailsListAsync();
    }
}
