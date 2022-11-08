namespace RepairEquipment.Shared.Models.Data
{
    public sealed record DocumentDetail
    {
        public int Id { get; init; }
        public int DocumentId { get; init; }
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime? DocumentDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sum { get; set; }
        public decimal TotalSum { get; set; }
        public int EquipmentId { get; init; }
        public string Equipment { get; init; } = string.Empty;
    }
}