using QuestPDF.Infrastructure;
using RepairEquipment.Shared.Models.Export;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IPdfService
    {
        public Task<IDocument> CreateClientPdf(IEnumerable<DocExportRecord> data, string docType);
        public Task<IDocument> CreateEmployeePdf(IEnumerable<DocExportRecord> data, string docType);
    }
}
