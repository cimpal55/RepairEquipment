using RepairEquipment.Shared.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
