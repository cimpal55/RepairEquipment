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
        public Task DeleteEmployeeAsync(EmployeeRecord item)
        {
            string sql = "DELETE FROM TBL_CONF_Employees WHERE ID = @ID";
            return _data.SaveData(sql, item);
        }

        public Task<EmployeeRecord?> GetEmployeeDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeRecord>> GetEmployeesListAsync()
        {
            string sql = "SELECT * FROM TBL_CONF_Employees";
            return _data.LoadData<EmployeeRecord, dynamic>(sql, new { });
        }
        public Task<string> GetEmployeeNameAsync(int? id)
        {
            string sql = "SELECT Name FROM TBL_CONF_Employees WHERE ID = @ID";
            return _data.LoadRow<string, dynamic>(sql, new { });
        }

        public Task InsertEmployeeAsync(EmployeeRecord item)
        {
            string sql = @"INSERT INTO TBL_CONF_Employees (Name, Surname, Code, PersonalCode, Phone, Email, Address) 
                           VALUES (@Name, @Surname, @Code, @PersonalCode, @Phone, @Email, @Address);";
            return _data.SaveData(sql, item);

        }

        public Task UpdateEmployeeAsync(EmployeeRecord item)
        {
            string sql = @"UPDATE TBL_CONF_Employees SET Name = @Name, Surname = @Surname, Code = @Code, 
                           PersonalCode = @PersonalCode, Phone = @Phone, Email = @Email, Address = @Address WHERE ID = @ID";
            return _data.SaveData(sql, item);
        }
    }
}
