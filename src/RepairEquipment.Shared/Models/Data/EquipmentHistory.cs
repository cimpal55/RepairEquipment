namespace RepairEquipment.Shared.Models.Data
{
    public sealed record EquipmentHistory
    {
        public int ID { get; init; }
        public int EquipmentID { get; init; }
        public string Equipment { get; init; } = string.Empty;
        public int? ClientID { get; init; }
        public string? Client { get; init; }
        public int? EmployeeID { get; init; }
        public string? Employee { get; init; }
        public string Location { get; init; } = string.Empty;
        public DateTime DateOut { get; init; }
        public DateTime? DateIn { get; init; }
    }
}