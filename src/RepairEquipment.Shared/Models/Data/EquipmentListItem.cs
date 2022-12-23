namespace RepairEquipment.Shared.Models.Data
{
    public sealed class EquipmentListItem
    {
        public EquipmentListItem(int key) { }
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeID { get; set; }
        public string Type { get; set; } = string.Empty;
        public int LocationID { get; set; }
        public string Location { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public int FixedAssetNr { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseSum { get; set; }
        public string PurchaseInvoiceNr { get; set; } = string.Empty;
        public string PurchaseInvoiceLink { get; set; } = string.Empty;
        public int DepreciationPeriod { get; set; }
        public decimal Depreciation { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
