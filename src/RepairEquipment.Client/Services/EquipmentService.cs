using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ISqlDataAccess _data;
        public EquipmentService(ISqlDataAccess data)
        {
            _data = data;
        }
        public Task DeleteEquipmentAsync(EquipmentRecord item)
        {
            string sql = "DELETE FROM TBL_CONF_Equipment WHERE ID = @ID";
            return _data.SaveData(sql, item);
        }

        public Task<EquipmentRecord?> GetEquipmentDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EquipmentRecord>> GetEquipmentListAsync()
        {
            string sql = @"SELECT Name, TypeId, LocationId, SerialNumber, FixedAssetNr,
                         PurchaseSum, PurchaseInvoiceNr, PurchaseInvoiceLink, DepreciationPeriod, Depreciation, Notes FROM TBL_CONF_Equipment";
            return _data.LoadData<EquipmentRecord, dynamic>(sql, new { });
        }

        public Task InsertEquipmentAsync(EquipmentRecord item)
        {
            string sql = @"INSERT INTO TBL_CONF_Equipment (Name, TypeId, LocationId, SerialNumber, FixedAssetNr, PurchaseDate, PurchaseSum,
                         PurchaseInvoiceNr, PurchaseInvoiceLink, DepreciationPeriod, Depreciation, Notes) 
                         VALUES (@Name, @TypeId, @LocationId, @SerialNumber, @FixedAssetNr, @PurchaseDate, @PurchaseSum,
                         @PurchaseInvoiceNr, @PurchaseInvoiceLink, @DepreciationPeriod, @Depreciation, @Notes);";
            return _data.SaveData(sql, item);
        }

        public Task UpdateEquipmentAsync(EquipmentRecord item)
        {
            string sql = @"UPDATE TBL_CONF_Equipment SET Name = @Name, TypeId = @TypeId, LocationId = @LocationId, Location = @Location, SerialNumber = @SerialNumber,
                         FixedAssetNr = @FixedAssetNr, PurchaseDate = @PurchaseDate, PurchaseSum = @PurchaseSum, PurchaseInvoiceNr = @PurchaseInvoiceNr,
                         PurchaseInvoiceLink = @PurchaseInvoiceLink, DepreciationPeriod = @DepreciationPeriod, Depreciation = @Depreciation,
                         Notes = @Notes, WHERE ID = @ID";
            return _data.SaveData(sql, item);
        }
    }
}
