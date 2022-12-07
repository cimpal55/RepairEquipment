namespace RepairEquipment.Shared.Models.Data
{
    public sealed record LocationRecord
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public DateTime Created { get; init; }
    }
}
