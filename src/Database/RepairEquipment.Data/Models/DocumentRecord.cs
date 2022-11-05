namespace RepairEquipment.Data.Models
{
    public sealed class DocumentRecord
    {
        public int Id { get; init; }
        public string DocumentNumber { get; init; } = string.Empty;
        public int? ClientId { get; init; }
        public int? EmployeeId { get; init; }
        public DateTime Created { get; init; }
    }
}
