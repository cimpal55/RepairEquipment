using Microsoft.AspNetCore.Mvc;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Export;

namespace RepairEquipment.Controllers
{
    [Route("api/doc-export")]
    [ApiController]
    public sealed class DocExportController : ControllerBase
    {
        private readonly IDocExportService _docExportService;
        public DocExportController(IDocExportService docExportService)
        {
            _docExportService = docExportService;
        }

        [HttpGet("file")]
        public async Task<FileStreamResult> ExportFile([FromQuery(Name = "fmt")] string format, [FromQuery(Name = "doctype")] string docType, [FromQuery(Name = "search")] string? search = null, CancellationToken ct = default)
        {
            var req = new DocExportFileRequest
            {
                Format = format,
                DocType = docType
            };

            var res = await _docExportService.ExportPdfAsync(req, search, ct)
                .ConfigureAwait(false);

            return File(res.FileStream, res.ContentType, res.FileName);
        }

    }
}
