using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeRecord>> GetEmployeesListAsync();
        public Task<EmployeeRecord?> GetEmployeeDetailsAsync(int id);
        public Task InsertEmployeeAsync(EmployeeRecord item);
        public Task UpdateEmployeeAsync(EmployeeRecord item);
        public Task DeleteEmployeeAsync(EmployeeRecord item);
    }
}
