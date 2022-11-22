namespace RepairEquipment.Shared.Models.Data
{
    public sealed record DocumentRecord
    {
        public int Id { get; init; }
        public string DocumentNumber { get; set; } = string.Empty;
        public int? ClientId { get; init; }
        public string? Client { get; init; }
        public int? EmployeeId { get; init; }
        public string? Employee { get; init; }
    }
}