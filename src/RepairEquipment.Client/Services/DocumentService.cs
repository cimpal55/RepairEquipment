using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly SqlDataAccess _conn;
        public DocumentService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task DeleteDocumentAsync(DocumentRecord item)
        {
            var record = new DocumentRecord
            {
                Id = item.Id
            };

            await _conn
                .DeleteAsync(record)
                .ConfigureAwait(false);
        }
        public async Task<List<DocumentRecord>> GetDocumentsListAsync() =>
            await _conn
                .DocumentsRecords
                .ToListAsync();
        public async Task InsertDocumentAsync(DocumentRecord item)
        {
            var record = new DocumentRecord
            {
                Id = item.Id,
                DocumentNumber = item.DocumentNumber,
                ClientId = item.ClientId,
                EmployeeId = item.EmployeeId,
                Created = DateTime.Now
            };

            await _conn
                .InsertAsync(record)
                .ConfigureAwait(false);
        }
        public async Task UpdateDocumentAsync(DocumentRecord item)
        {
            var record = new DocumentRecord
            {
                Id = item.Id,
                DocumentNumber = item.DocumentNumber,
                ClientId = item.ClientId,
                EmployeeId = item.EmployeeId,
                Created = DateTime.Now
            };

            await _conn
                .UpdateAsync(record)
                .ConfigureAwait(false);
        }
    }
}
