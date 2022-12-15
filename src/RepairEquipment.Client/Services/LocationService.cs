using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public class LocationService : ILocationService
    {
        private readonly ISqlDataAccess _data;
        public LocationService(ISqlDataAccess data)
        {
            _data = data;
        }
        public Task<List<LocationRecord>> GetLocationListAsync()
        {
            string sql = "SELECT * FROM TBL_CONF_Locations";
            return _data.LoadData<LocationRecord, dynamic>(sql, new { });
        }

    }
}
