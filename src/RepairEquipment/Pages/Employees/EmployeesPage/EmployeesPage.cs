using RepairEquipment.Core.Models.Data;

namespace RepairEquipment.Pages.Employees.EmployeesPage
{
    public partial class EmployeesPage
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEmployee.DataService EmployeeDataService { get; set; }
    }
}
