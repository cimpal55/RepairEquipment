namespace RepairEquipment.Shared.Models.Data
{
    public sealed record Equipment
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int TypeId { get; init; }
        public string Type { get; init; } = string.Empty;
        public int LocationId { get; init; }
        public string Location { get; init; } = string.Empty;
        public string SerialNumber { get; init; } = string.Empty;
        public int FixedAssetNr { get; init; }
        public DateTime? PurchaseDate { get; init; }
        public decimal PurchaseSum { get; init; }
        public string PurchaseInvoiceNr { get; init; } = string.Empty;
        public string PurchaseInvoiceLink { get; init; } = string.Empty;
        public int DepreciationPeriod { get; init; }
        public decimal Depreciation { get; init; }
        public string Notes { get; init; } = string.Empty;
        public bool IsWriteOff { get; set; }
        public bool IsInStock { get; set; }
    }
}