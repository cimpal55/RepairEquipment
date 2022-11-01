namespace RepairEquipment.Core.Models.Data
{
    public sealed record Employee
    {
        public string Name { get; init; } = string.Empty;
        public string Surname { get; init; } = string.Empty;
        public string Code { get; init; } = string.Empty;
        public string PersonalCode { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
    }
}
