using System.ComponentModel.DataAnnotations;

namespace RepairEquipment.Shared.Models.Data
{
    public sealed record EmployeeRecord
    {
        [Key]
        public int ID { get; init; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        [StringLength(12, MinimumLength = 12)]
        public string PersonalCode { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
