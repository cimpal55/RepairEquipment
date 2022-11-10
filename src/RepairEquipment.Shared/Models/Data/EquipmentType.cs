namespace RepairEquipment.Shared.Models.Data
{
    public sealed record EquipmentType
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}