using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.EquipmentType)]
    public sealed record EquipmentTypeRecord
    {
        [Column(EquipmentType.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        [Column(EquipmentType.Name, CanBeNull = false)]
        public string Name { get; set; } = string.Empty;

        [Column(EquipmentType.FixedAssetNeeded, CanBeNull = false)]
        public bool FixedAssetNeeded { get; set; } = false;

        [Column(EquipmentType.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}