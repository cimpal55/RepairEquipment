using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class EquipmentListService : IEquipmentListService
    {
        private readonly IUtilsService _utilsService;

        private readonly IEquipmentService _equipmentService;
        public EquipmentListService(IUtilsService utilsService, IEquipmentService equipmentService)
        {
            _utilsService = utilsService;
            _equipmentService = equipmentService;
        }

        public async Task<List<EquipmentListItem>> GetListItemsAsync()
        {
            var equipment = await _equipmentService.GetEquipmentListAsync()
                .ConfigureAwait(false);

            var list = new List<EquipmentListItem>();

            foreach (var item in equipment)
            {
                var el = new EquipmentListItem(item.ID)
                {
                    ID = item.ID,
                    Name = item.Name,
                    TypeID = item.TypeID,
                    Type = await _utilsService.GetEquipmentTypeNameByIdAsync(item.TypeID)
                                    .ConfigureAwait(false),
                    SerialNumber = item.SerialNumber,
                    FixedAssetNr = item.FixedAssetNr,
                    PurchaseDate = item.PurchaseDate ?? DateTime.MinValue,
                    PurchaseSum = item.PurchaseSum,
                    PurchaseInvoiceNr = item.PurchaseInvoiceNr,
                    PurchaseInvoiceLink = item.PurchaseInvoiceLink,
                    DepreciationPeriod = item.DepreciationPeriod,
                    Depreciation = item.Depreciation,
                    Notes = item.Notes,
                    LocationID = item.LocationID,
                    Location = await _utilsService.GetLocationNameByIdAsync(item.LocationID)
                                    .ConfigureAwait(false)
                };

                list.Add(el);
            }

            return list;
        }
    }
}
