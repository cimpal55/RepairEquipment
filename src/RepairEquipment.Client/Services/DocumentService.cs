using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly ISqlDataAccess _data;
        public DocumentService(ISqlDataAccess data)
        {
            _data = data;
        }
        public Task DeleteDocumentAsync(DocumentRecord item)
        {
            string sql = "DELETE FROM TBL_Documents WHERE ID = @ID";
            return _data.SaveData(sql, item);
        }

        public Task<DocumentRecord?> GetDocumentsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DocumentRecord>> GetDocumentsListAsync()
        {
            string sql = "SELECT * FROM TBL_Documents";
            return _data.LoadData<DocumentRecord, dynamic>(sql, new { });
        }

        public Task InsertDocumentAsync(DocumentRecord item)
        {
            string sql = @"INSERT INTO TBL_Documents (ClientID, EmployeeID, DocumentNumber) 
                         VALUES (@ClientID, @EmployeeID, @DocumentNumber);";
            return _data.SaveData(sql, item);
        }

        public Task UpdateDocumentAsync(DocumentRecord item)
        {
            string sql = @"UPDATE TBL_Documents SET ClientID = @ClientID, EmployeeID = @EmployeeID, DocumentNumber = @DocumentNumber, WHERE ID = @ID";
            return _data.SaveData(sql, item);
        }
    }
}
