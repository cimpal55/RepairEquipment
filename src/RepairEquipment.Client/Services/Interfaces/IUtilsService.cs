using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IUtilsService
    {
        public Task<string> GetClientNameByIdAsync(int? id);
        public Task<string> GetEmployeeNameByIdAsync(int? id);
        public Task<string> GetEquipmentTypeNameByIdAsync(int? id);
        public Task<string> GetLocationNameByIdAsync(int? id);
        

    }
}
