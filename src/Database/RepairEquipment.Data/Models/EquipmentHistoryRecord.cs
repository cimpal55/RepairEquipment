namespace RepairEquipment.Data.Models
{
    public sealed record EquipmentHistoryRecord
    {        
        public int Id { get; init; }
        public int EquipmentId { get; init; }
        public int? ClientId { get; init; }
        public int? EmployeeId { get; init; }
        public string Location { get; init; } = string.Empty;
        public DateTime DateOut { get; init; }
        public DateTime? DateIn { get; init; }
    }
}
