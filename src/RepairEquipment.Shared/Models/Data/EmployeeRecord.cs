using System.ComponentModel.DataAnnotations;

namespace RepairEquipment.Shared.Models.Data
{
    public sealed record EmployeeRecord
    {
        public int ID { get; init; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string PersonalCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime Created { get; init; }
    }
}
