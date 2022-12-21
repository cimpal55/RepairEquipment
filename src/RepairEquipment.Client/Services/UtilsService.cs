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
        public async Task<string> GetClientNameByIdAsync(int? id) =>
            await _conn
                .ClientsRecords
                .Where(x => x.ID == id)
                .Select(x => $"{x.Name}")
                .FirstOrDefaultAsync() ?? string.Empty;
        public async Task<string> GetEmployeeNameByIdAsync(int? id) =>
        await _conn
            .EmployeesRecords
            .Where(x => x.ID == id)
            .Select(x => $"{x.Name}")
            .FirstOrDefaultAsync() ?? string.Empty;
        public async Task<string> GetEquipmentTypeNameByIdAsync(int? id) =>
            await _conn
                .EquipmentTypeRecords
                .Where(x => x.ID == id)
                .Select(x => $"{x.Name}")
                .FirstOrDefaultAsync() ?? string.Empty;
        public async Task<string> GetLocationNameByIdAsync(int? id) =>
            await _conn
                .LocationRecords
                .Where(x => x.ID == id)
                .Select(x => $"{x.Name}")
                .FirstOrDefaultAsync() ?? string.Empty;
    }
}

