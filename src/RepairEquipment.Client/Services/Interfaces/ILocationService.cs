using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<List<LocationRecord>> GetLocationListAsync();
    }
}
