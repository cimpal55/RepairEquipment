using MyNihongo.LinqAsync;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Export;

namespace RepairEquipment.Client.Services
{
    public sealed class DocExportService
    {
        private const string FileName = "doc_export";
        private const string PdfContentType = "application/pdf";

        private readonly IDocumentService _documentService;
        private readonly IUtilsService _utilsService;
        private readonly IPdfService _pdfService;

        public DocExportService(
            IDocumentService documentService,
            IUtilsService utilsService,
            IPdfService pdfService)
        {
            _documentService = documentService;
            _utilsService = utilsService;
            _pdfService = pdfService;
        }

        public async Task<IEnumerable<DocExportRecord>> CreateAsync(string? search, CancellationToken ct = default)
        {
            var items = await _documentService
                .GetDocumentsAsync(search, ct)
                .Select(x => new DocExportRecord
                {
                    DocumentNumber = x.DocumentNumber,
                    DocumentDetailNumber = x.DocumentDetailNumber,
                    DocumentDateOut = x.DocumentDateOut,
                    DocumentDateIn = x.DocumentDateIn,
                    Quantity = x.Quantity,
                    Sum = x.Sum,
                    TotalSum = x.TotalSum,
                    Client = _utilsService.GetClientNameById(x.ClientId),
                    ClientRegistrationNr = x.ClientRegistrationNr,
                    ClientContactPerson = x.ClientContactPerson,
                    Employee = _utilsService.GetEmployeeNameById(x.EmployeeId),
                    Equipment = _utilsService.GetEquipmentNameById(x.EquipmentId)
                })
                .ConfigureAwait(false);

            return items;
        }

        public async Task<DocExportFileResponse> ExportPdfAsync(DocExportFileRequest req, string? search, CancellationToken ct = default)
        {
            IDocument document;
            var data = await CreateAsync(search, ct)
                                .ConfigureAwait(false);

            var docExportRecords = data.ToList();
            if (docExportRecords.Any(x => !string.IsNullOrEmpty(x.Employee)))
            {
                document = await _pdfService.CreateEmployeePdf(docExportRecords, req.DocType)
                                .ConfigureAwait(false);
            }
            else if (docExportRecords.Any(x => !string.IsNullOrEmpty(x.Client)))
            {
                document = await _pdfService.CreateClientPdf(docExportRecords, req.DocType)
                                .ConfigureAwait(false);
            }
            else
            {
                throw new Exception("No one Employee or Client is found!!!");
            }

            return CreateExportResponse(document);
        }

        private static DocExportFileResponse CreateExportResponse(IDocument document)
        {
            var stream = new MemoryStream();
            document.GeneratePdf(stream);
            stream.Position = 0;

            return new DocExportFileResponse(stream)
            {
                ContentType = PdfContentType
            };
        }
    }
}
