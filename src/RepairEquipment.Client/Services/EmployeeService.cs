using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RepairEquipment.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISqlDataAccess _data;
        public EmployeeService(ISqlDataAccess data)
        {
            _data = data;
        }
        public Task DeleteEmployeeAsync(Employee item)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetEmployeeDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployeesList()
        {
            string sql = "SELECT * FROM TBL_CONF_Employees";
            return _data.LoadData<Employee, dynamic>(sql, new { });
        }

        public Task InsertEmployeeAsync(Employee item)
        {
            string sql = @"INSERT INTO TBL_CONF_Employees (Name, Surname, Code, PersonalCode, Phone, Email, Address) 
                          VALUES (@Name, @Surname, @Code, @PersonalCode, @Phone, @Email, @Address);";
            return _data.SaveData(sql, item); 
            
        }

        public Task UpdateEmployeeAsync(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
