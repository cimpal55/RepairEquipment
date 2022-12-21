using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.Equipment)]
    public sealed record EquipmentRecord
    {
        [Column(Equipment.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }

        [Column(Equipment.Name, CanBeNull = false)]
        public string Name { get; set; } = string.Empty;

        [Column(Equipment.TypeId, CanBeNull = false)]
        public int TypeID { get; set; }

        [Column(Equipment.LocationId, CanBeNull = false)]
        public int LocationID { get; set; }

        [Column(Equipment.SerialNumber, CanBeNull = true)]
        public string SerialNumber { get; set; } = string.Empty;

        [Column(Equipment.FixedAssetNr, CanBeNull = true)]
        public int FixedAssetNr { get; set; }

        [Column(Equipment.PurchaseDate, CanBeNull = false)]
        public DateTime? PurchaseDate { get; set; }
        
        [Column(Equipment.PurchaseSum, CanBeNull = false)]
        public decimal PurchaseSum { get; set; }
        
        [Column(Equipment.PurchaseInvoiceNr, CanBeNull = false)]
        public string PurchaseInvoiceNr { get; set; } = string.Empty;

        [Column(Equipment.PurchaseInvoiceLink, CanBeNull = false)]
        public string PurchaseInvoiceLink { get; set; } = string.Empty;

        [Column(Equipment.DepreciationPeriod, CanBeNull = false)]
        public int DepreciationPeriod { get; set; }

        [Column(Equipment.Depreciation, CanBeNull = false)]
        public decimal Depreciation { get; set; }

        [Column(Equipment.Notes, CanBeNull = false)]
        public string Notes { get; set; } = string.Empty;
        
        [Column(Equipment.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}