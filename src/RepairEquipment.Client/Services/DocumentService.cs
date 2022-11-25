using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class DocumentService : IDocumentService
    {
        public Task DeleteDocumentAsync(DocumentRecord item)
        {
            throw new NotImplementedException();
        }

        public Task<DocumentRecord?> GetDocumentsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DocumentRecord>> GetDocumentsListAsync()
        {
            throw new NotImplementedException();
        }

        public Task InsertDocumentAsync(DocumentRecord item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDocumentAsync(DocumentRecord item)
        {
            throw new NotImplementedException();
        }
    }
}
