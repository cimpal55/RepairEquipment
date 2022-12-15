namespace RepairEquipment.Shared.Models.Export
{
    public sealed record DocExportFileRequest
    {
        public string Format { get; init; } = string.Empty;
        public string DocType { get; init; } = string.Empty;
    }
}
