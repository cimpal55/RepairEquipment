namespace RepairEquipment.Shared.Models.Data
{
    public sealed record DocumentDetailRecord
    {
        public int ID { get; init; }
        public int DocumentID { get; init; }
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime? DocumentDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sum { get; set; }
        public decimal TotalSum { get; set; }
        public int EquipmentID { get; init; }
        public string Equipment { get; init; } = string.Empty;
    }
}