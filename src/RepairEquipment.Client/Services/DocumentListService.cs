using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairEquipment.Client.Services
{
    public class DocumentListService : IDocumentListService
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
            var document = await _documentService.GetDocumentsListAsync();

            var list = new List<DocumentsListItem>();
            
            foreach (var item in document)
            {
                var el = new DocumentsListItem(item.Id)
                {
                    Id = item.Id,
                    DocumentNumber = item.DocumentNumber,
                    Client = await _utilsService.GetClientNameById(item.ClientId).ConfigureAwait(false),
                    Employee = await _utilsService.GetEmployeeNameById(item.EmployeeId).ConfigureAwait(false)
                };

                list.Add(el);
            }
            
            return list;
        }

    }
}
