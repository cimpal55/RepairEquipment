using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Data.Models
{
    public sealed class ClientRecord
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Code { get; init; } = string.Empty;
        public string RegistrationNr { get; init; } = string.Empty;
        public string LegalAddress { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string ContactPersonName { get; init; } = string.Empty;
        public string ContactPersonAddress { get; init; } = string.Empty;
        public string ContactPersonPhone { get; init; } = string.Empty;
        public string ContactPersonEmail { get; init; } = string.Empty;
        public DateTime Created { get; init; }
    }
}
