using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class DocumentDetailsListService : IDocumentsDetailsListService
    {
        private readonly IUtilsService _utilsService;

        private readonly IDocumentDetailsService _documentDetailsService;
        public DocumentDetailsListService(IUtilsService utilsService, IDocumentDetailsService documentDetailsService)
        {
            _utilsService = utilsService;
            _documentDetailsService = documentDetailsService;
        }
        public async Task<List<DocumentsDetailsListItem>> GetListItemsAsync()
        {
            var document = await _documentDetailsService.GetDocumentDetailsListAsync()
                .ConfigureAwait(false);

            var list = new List<DocumentsDetailsListItem>();

            foreach (var item in document)
            {
                var el = new DocumentsDetailsListItem(item.ID)
                {
                    ID = item.ID,
                    DocumentID = item.DocumentID,
                    DocumentNumber = item.DocumentNumber,
                    DocumentDateOut = item.DocumentDateOut?.Date,
                    DocumentDateIn = item.DocumentDateIn?.Date,
                    Quantity = item.Quantity,
                    Sum = item.Sum,
                    TotalSum = item.TotalSum,
                    EquipmentID = item.EquipmentID,
                    Equipment = _utilsService.GetEquipmentNameById(item.EquipmentID),
                    Created = DateTime.Now
                };

                list.Add(el);
            }

            return list;
        }
    }
}
