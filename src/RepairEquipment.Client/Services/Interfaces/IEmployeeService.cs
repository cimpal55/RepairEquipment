using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployeesList();
        public Task<Employee?> GetEmployeeDetailsAsync(int id);
        public Task InsertEmployeeAsync(Employee item);
        public Task UpdateEmployeeAsync(Employee item);
        public Task DeleteEmployeeAsync(Employee item);
    }
}
