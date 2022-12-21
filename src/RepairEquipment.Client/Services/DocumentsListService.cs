using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class DocumentListService : IDocumentsListService
    {
        private readonly IUtilsService _utilsService;

        private readonly IDocumentService _documentService;
        public DocumentListService(IUtilsService utilsService, IDocumentService documentService)
        {
            _utilsService = utilsService;
            _documentService = documentService;
        }
        public async Task<List<DocumentsListItem>> GetListItemsAsync()
        {
            var document = await _documentService.GetDocumentsListAsync()
                .ConfigureAwait(false);

            var list = new List<DocumentsListItem>();

            foreach (var item in document)
            {
                var el = new DocumentsListItem(item.ID)
                {
                    ID = item.ID,
                    DocumentNumber = item.DocumentNumber,
                    ClientID = item.ClientID,
                    EmployeeID = item.EmployeeID,
                    Client = await _utilsService.GetClientNameByIdAsync(item.ClientID).ConfigureAwait(false),
                    Employee = await _utilsService.GetEmployeeNameByIdAsync(item.EmployeeID).ConfigureAwait(false)
                };

                list.Add(el);
            }

            return list;
        }

    }
}
