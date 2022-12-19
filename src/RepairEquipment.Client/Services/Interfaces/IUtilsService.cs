using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IUtilsService
    {
        public Task<string> GetClientNameById(int id);
        public Task<string> GetEmployeeNameById(int id);
    }
}
