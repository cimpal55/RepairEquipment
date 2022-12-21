using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.EquipmentType)]
    public sealed record EquipmentTypeRecord
    {
        [Column(EquipmentType.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }

        [Column(EquipmentType.Name, CanBeNull = false)]
        public string Name { get; init; } = string.Empty;

        [Column(EquipmentType.FixedAssetNeeded, CanBeNull = false)]
        public bool FixedAssetNeeded { get; init; } = false;

        [Column(EquipmentType.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}