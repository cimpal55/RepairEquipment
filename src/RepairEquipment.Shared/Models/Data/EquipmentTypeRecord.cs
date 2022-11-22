namespace RepairEquipment.Shared.Models.Data
{
    public sealed record EquipmentTypeRecord
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}