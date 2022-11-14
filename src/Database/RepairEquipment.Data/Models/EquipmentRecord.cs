namespace RepairEquipment.Data.Models
{
    public sealed record EquipmentRecord
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int TypeId { get; init; }
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
        public DateTime Created { get; init; }
    }
}
