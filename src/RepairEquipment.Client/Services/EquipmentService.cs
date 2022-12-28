using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class EquipmentService : IEquipmentService
    {
        private readonly SqlDataAccess _conn;
        public EquipmentService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task DeleteEquipmentAsync(EquipmentRecord item)
        {
            var record = new EquipmentRecord
            {
                ID = item.ID
            };

            await _conn
                .DeleteAsync(record)
                .ConfigureAwait(false);
        }

        public Task<EquipmentRecord?> GetEquipmentDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EquipmentRecord>> GetEquipmentListAsync() =>
            await _conn
                .EquipmentRecords
                .ToListAsync();

        public async Task InsertEquipmentAsync(EquipmentRecord item)
        {
            var record = new EquipmentRecord
            {
                ID = item.ID,
                Name = item.Name,
                TypeID = item.TypeID,
                SerialNumber = item.SerialNumber,
                FixedAssetNr = item.FixedAssetNr,
                PurchaseDate = item.PurchaseDate,
                PurchaseSum = item.PurchaseSum,
                PurchaseInvoiceNr = item.PurchaseInvoiceNr,
                PurchaseInvoiceLink = item.PurchaseInvoiceLink,
                DepreciationPeriod = item.DepreciationPeriod,
                Depreciation = item.Depreciation,
                Notes = item.Notes,
                LocationID = item.LocationID,
                Created = DateTime.Now
            };

            await _conn
                .InsertAsync(record)
                .ConfigureAwait(false);
        }

        public async Task UpdateEquipmentAsync(EquipmentRecord item)
        {
            var record = new EquipmentRecord
            {
                ID = item.ID,
                Name = item.Name,
                TypeID = item.TypeID,
                SerialNumber = item.SerialNumber,
                FixedAssetNr = item.FixedAssetNr,
                PurchaseDate = item.PurchaseDate,
                PurchaseSum = item.PurchaseSum,
                PurchaseInvoiceNr = item.PurchaseInvoiceNr,
                PurchaseInvoiceLink = item.PurchaseInvoiceLink,
                DepreciationPeriod = item.DepreciationPeriod,
                Depreciation = item.Depreciation,
                Notes = item.Notes,
                LocationID = item.LocationID,
                Created = DateTime.Now
            };

            await _conn
                .UpdateAsync(record)
                .ConfigureAwait(false);
        }
    }
}
