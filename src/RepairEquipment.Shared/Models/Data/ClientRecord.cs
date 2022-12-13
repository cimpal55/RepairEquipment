using System.ComponentModel.DataAnnotations;

namespace RepairEquipment.Shared.Models.Data
{
    public sealed record ClientRecord
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;      
        public string Code { get; set; } = string.Empty;
        public string RegistrationNr { get; set; } = string.Empty;
        public string LegalAddress { get; set; } = string.Empty;      
        public string Phone { get; set; } = string.Empty;    
        public string Email { get; set; } = string.Empty;
        public string ContactPersonName { get; set; } = string.Empty;
        public string ContactPersonAddress { get; set; } = string.Empty;
        public string ContactPersonPhone { get; set; } = string.Empty;
        public string ContactPersonEmail { get; set; } = string.Empty;
        public DateTime Created { get; init; }
    }
}