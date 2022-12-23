using RepairEquipment.Shared.Models.Data;
using RepairEquipment.Shared.Models.Export;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IDocumentService
    {
        public Task<List<DocumentRecord>> GetDocumentsListAsync();
        public Task InsertDocumentAsync(DocumentRecord item);
        public Task UpdateDocumentAsync(DocumentRecord item);
        public Task DeleteDocumentAsync(DocumentRecord item);
        public Task<IEnumerable<DocExportModel>> GetDocumentsAsync(string? search, CancellationToken ct = default);
    }
}
