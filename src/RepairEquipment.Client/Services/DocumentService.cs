using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;
using RepairEquipment.Shared.Models.Export;

namespace RepairEquipment.Client.Services
{
    public sealed class DocumentService : IDocumentService
    {
        private readonly SqlDataAccess _conn;

        private readonly IUtilsService _utilsService;
        public DocumentService(SqlDataAccess conn, IUtilsService utilsService)
        {
            _conn = conn;
            _utilsService = utilsService;
        }
        public async Task DeleteDocumentAsync(DocumentRecord item)
        {
            var record = new DocumentRecord
            {
                ID = item.ID
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
                ID = item.ID,
                DocumentNumber = item.DocumentNumber,
                ClientID = item.ClientID,
                EmployeeID = item.EmployeeID,
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
                ID = item.ID,
                DocumentNumber = item.DocumentNumber,
                ClientID = item.ClientID,
                EmployeeID = item.EmployeeID,
                Created = DateTime.Now
            };

            await _conn
                .UpdateAsync(record)
                .ConfigureAwait(false);
        }
        public async Task<int> GetDocumentClientByNameAsync(string name) =>
            await _conn
                .ClientsRecords
                .Where(x => x.Name.Contains(name))
                .Select(x => x.ID)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

        public async Task<int> GetDocumentEmployeeByNameAsync(string code) =>
            await _conn
                .EmployeesRecords
                .Where(x => x.Code.Contains(code))
                .Select(x => x.ID)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        public async Task<IEnumerable<DocExportModel>> GetDocumentsAsync(string? search)
        {
            IEnumerable<DocExportModel> res;

                res = _conn.DocumentDetailsRecords
                    .SelectMany(dd => _conn.DocumentsRecords
                            .InnerJoin(ddd => ddd.ID == dd.DocumentID),
                    (dd, d) => new DocExportModel
                    {
                        DocumentNumber = d.DocumentNumber,
                        ClientId = d.ClientID,
                        EmployeeId = d.EmployeeID,
                        DocumentDetailNumber = dd.DocumentNumber,
                        DocumentDateOut = dd.DocumentDateOut,
                        DocumentDateIn = dd.DocumentDateIn,
                        EquipmentId = dd.EquipmentID,
                        Quantity = dd.Quantity,
                        Sum = dd.Sum,
                        TotalSum = dd.TotalSum
                    });
            return res.ToList();
        }

    }
}
