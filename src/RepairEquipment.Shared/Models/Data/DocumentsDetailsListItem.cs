namespace RepairEquipment.Shared.Models.Data
{
    public sealed class DocumentsDetailsListItem
    {
        public DocumentsDetailsListItem(int key) { }
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime? DocumentDateOut { get; set; }
        public DateTime? DocumentDateIn { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sum { get; set; }
        public decimal TotalSum { get; set; }
        public int EquipmentID { get; set; }
        public string Equipment { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}
