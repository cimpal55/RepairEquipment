namespace RepairEquipment.Data.Models
{
    public sealed class DocumentDetailRecord
    {
        public int Id { get; init; }
        public int DocumentId { get; init; }
        public string DocumentNumber { get; init; } = string.Empty;
        public DateTime? DocumentDate { get; init; }
        public decimal Quantity { get; init; }
        public decimal Sum { get; init; }
        public decimal TotalSum { get; init; }
        public int EquipmentId { get; init; }
        public DateTime Created { get; init; }
    }
}
