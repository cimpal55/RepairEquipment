namespace RepairEquipment.Shared.Models.Data
{
    public sealed record EquipmentHistory
    {
        public int Id { get; init; }
        public int EquipmentId { get; init; }
        public string Equipment { get; init; } = string.Empty;
        public int? ClientId { get; init; }
        public string? Client { get; init; }
        public int? EmployeeId { get; init; }
        public string? Employee { get; init; }
        public string Location { get; init; } = string.Empty;
        public DateTime DateOut { get; init; }
        public DateTime? DateIn { get; init; }
    }
}