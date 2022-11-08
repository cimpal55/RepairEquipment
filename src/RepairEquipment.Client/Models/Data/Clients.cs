namespace RepairEquipment.Shared.Models.Data
{
    public sealed record Clients
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Code { get; init; } = string.Empty;
        public string RegistrationNr { get; init; } = string.Empty;
        public string LegalAddress { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
    }
}