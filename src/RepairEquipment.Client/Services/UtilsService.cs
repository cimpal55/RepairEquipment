using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class UtilsService : IUtilsService
    {
        private readonly SqlDataAccess _conn;
        public UtilsService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task<ClientRecord> GetClientNameByIdAsync(int? id) =>
            await _conn
                    .ClientsRecords
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();
        public async Task<EmployeeRecord> GetEmployeeNameByIdAsync(int? id) =>
            await _conn
                    .EmployeesRecords
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();
        public async Task<EquipmentTypeRecord> GetEquipmentTypeByIdAsync(int? id) =>
            await _conn
                    .EquipmentTypeRecords
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();
        public async Task<EquipmentRecord> GetEquipmentByIdAsync(int? id) =>
            await _conn
                    .EquipmentRecords
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();

        public async Task<LocationRecord> GetLocationByIdAsync(int? id) =>
            await _conn
                    .LocationRecords
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();

        public string GetEquipmentTypeNameById(int? id) =>
            _conn
                .EquipmentTypeRecords
                .Where(x => x.ID == id)
                .Select(x => x.Name)
                .FirstOrDefault() ?? string.Empty;
        public string GetLocationNameById(int? id) =>
            _conn
                .LocationRecords
                .Where(x => x.ID == id)
                .Select(x => x.Name)
                .FirstOrDefault() ?? string.Empty;
        public string GetClientNameById(int? id) =>
            _conn
                .ClientsRecords
                .Where(x => x.ID == id)
                .Select(x => x.Name)
                .FirstOrDefault() ?? string.Empty;
        public string GetEmployeeNameById(int? id) =>
            _conn
                .EmployeesRecords
                .Where(x => x.ID == id)
                .Select(x => x.Name)
                .FirstOrDefault() ?? string.Empty;
        public string GetEquipmentNameById(int id) =>
            _conn
                .EquipmentRecords
                .Where(x => x.ID == id)
                .Select(x => x.Name)
                .FirstOrDefault() ?? string.Empty;
        public async Task<IEnumerable<DocumentDetailRecord>> GetDocumentDetailEquipmentByIdAsync(int id) =>
            await _conn
                .DocumentDetailsRecords
                .Where(x => x.EquipmentID == id)
                .ToListAsync()
                .ConfigureAwait(false);
        public async Task<IEnumerable<DocumentRecord>> GetDocumentEmployeeByIdAsync(int id) =>
            await _conn
                .DocumentsRecords
                .Where(x => x.EmployeeID == id)
                .ToListAsync()
                .ConfigureAwait(false);
        public async Task<IEnumerable<DocumentRecord>> GetDocumentClientByIdAsync(int id) =>
            await _conn
                .DocumentsRecords
                .Where(x => x.ClientID == id)
                .ToListAsync()
                .ConfigureAwait(false);

        //public async Task<IEnumerable<EquipmentRecord>> GetUsedEquipmentAsync() =>
        //    await _conn
        //        .DocumentDetailsRecords
        //        .Where(x => x.EquipmentID)
        //        .ToListAsync()
        //        .ConfigureAwait(false);

    }
}

