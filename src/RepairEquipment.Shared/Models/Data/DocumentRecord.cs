namespace RepairEquipment.Shared.Models.Data
{
    public sealed record DocumentRecord
    {
        public int Id { get; init; }
        public string DocumentNumber { get; set; } = string.Empty;
        public int? ClientId { get; set; }
        public string? Client { get; set; }
        public int? EmployeeId { get; set; }
        public string? Employee { get; set; }
    }
}