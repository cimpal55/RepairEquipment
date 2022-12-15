using RepairEquipment.Shared.Models.Export;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IDocExportService
    {
        Task<DocExportFileResponse> ExportPdfAsync(DocExportFileRequest req, string? search, CancellationToken ct = default);
    }
}
