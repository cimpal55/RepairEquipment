namespace RepairEquipment.Shared.Models.Export
{
    public sealed record DocExportFileResponse(Stream FileStream)
    {
        public string ContentType { get; init; } = string.Empty;
        public string FileName { get; init; } = string.Empty;
    }
}
