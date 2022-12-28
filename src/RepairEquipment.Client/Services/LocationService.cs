using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class LocationService : ILocationService
    {
        private readonly SqlDataAccess _conn;
        public LocationService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task<List<LocationRecord>> GetLocationListAsync() =>
            await _conn
                .LocationRecords
                .ToListAsync();

    }
}
