using System.ComponentModel.DataAnnotations;

namespace RepairEquipment.Shared.Models.Data
{
    public sealed record ClientRecord
    {
        [Key]
        public int ID { get; init; }
    
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string RegistrationNr { get; set; } = string.Empty;
        
        [Required]
        public string LegalAddress { get; set; } = string.Empty;
        
        [Required]
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}