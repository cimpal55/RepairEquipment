namespace RepairEquipment.Data.Models
{
    public sealed record EquipmentTypeRecord
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public bool FixedAssetNeeded { get; init; } = false;
        public DateTime Created { get; init; }
    }
}
