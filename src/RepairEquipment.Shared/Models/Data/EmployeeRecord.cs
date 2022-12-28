using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.Employee)]
    public sealed record EmployeeRecord
    {
        [Column(Client.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }
        
        [Column(Employee.Name, CanBeNull = false)]
        public string Name { get; set; } = string.Empty;

        [Column(Employee.Surname, CanBeNull = false)]
        public string Surname { get; set; } = string.Empty;

        [Column(Employee.Code, CanBeNull = false)]
        public string Code { get; set; } = string.Empty;

        [Column(Employee.PersonalCode, CanBeNull = false)]
        public string PersonalCode { get; set; } = string.Empty;

        [Column(Employee.Phone, CanBeNull = false)]
        public string Phone { get; set; } = string.Empty;

        [Column(Employee.Email, CanBeNull = false)]
        public string Email { get; set; } = string.Empty;

        [Column(Employee.Address, CanBeNull = false)]
        public string Address { get; set; } = string.Empty;

        [Column(Employee.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}
