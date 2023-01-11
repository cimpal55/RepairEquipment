using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.EquipmentHistory)]
    public sealed record EquipmentHistoryRecord
    {
        [Column(EquipmentHistory.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }
         
        [Column(EquipmentHistory.Equipment, CanBeNull = false)]
        public string Equipment { get; set; } = string.Empty;

        [Column(EquipmentHistory.EquipmentType, CanBeNull = false)]
        public string EquipmentType { get; set; } = string.Empty;

        [Column(EquipmentHistory.Location, CanBeNull = false)]
        public string Location { get; set; } = string.Empty;

        [Column(EquipmentHistory.Client, CanBeNull = false)]
        public string Client { get; set; } = string.Empty;

        [Column(EquipmentHistory.Employee, CanBeNull = false)]
        public string Employee { get; set; } = string.Empty;

        [Column(EquipmentHistory.DocumentNumber, CanBeNull = false)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Column(EquipmentHistory.DocumentDateOut, CanBeNull = false)]
        public DateTime? DocumentDateOut { get; set; }

        [Column(EquipmentHistory.DocumentDateIn)]
        public DateTime? DocumentDateIn { get; set; }

        [Column(EquipmentHistory.Quantity, CanBeNull = false)]
        public decimal Quantity { get; set; }

        [Column(EquipmentHistory.Sum, CanBeNull = false)]
        public decimal Sum { get; set; }

        [Column(EquipmentHistory.TotalSum, CanBeNull = false)]
        public decimal TotalSum { get; set; }
        public DateTime Created { get; init; }
        
    }
}