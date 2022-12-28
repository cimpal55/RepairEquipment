using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly SqlDataAccess _conn;
        public EmployeeService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task DeleteEmployeeAsync(EmployeeRecord item)
        {
            await _conn
                .DeleteAsync(item)
                .ConfigureAwait(false);
        }

        public Task<EmployeeRecord?> GetEmployeeDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeRecord>> GetEmployeesListAsync() =>
            await _conn
                .EmployeesRecords
                .ToListAsync();
        public async Task InsertEmployeeAsync(EmployeeRecord item)
        {
            await _conn
                .InsertAsync(item)
                .ConfigureAwait(false);
        }

        public async Task UpdateEmployeeAsync(EmployeeRecord item)
        {
            await _conn
                .UpdateAsync(item)
                .ConfigureAwait(false);
        }
    }
}
