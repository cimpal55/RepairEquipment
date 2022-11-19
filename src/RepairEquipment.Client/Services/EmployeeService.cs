using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

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
            string sql = "DELETE FROM TBL_CONF_Employees WHERE ID = @ID";
            return _data.SaveData(sql, item);
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

        public Task UpdateEmployeeAsync(int id)
        {
            string sql = @"UPDATE TBL_CONF_Employees SET Name = @Name, Surname = @Surname, Code = @Code, 
                           PersonalCode = @PersonalCode, Phone = @Phone, Email = @Email, Address = @Address WHERE ID = @id";
            return _data.SaveData(sql, id);
        }
    }
}
