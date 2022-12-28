using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class ClientService : IClientService
    {
        private readonly SqlDataAccess _conn;
        public ClientService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task DeleteClientAsync(ClientRecord item)
        {
            await _conn
                .DeleteAsync(item)
                .ConfigureAwait(false);
        }

        public async Task<List<ClientRecord>> GetClientsListAsync() =>
            await _conn
                .ClientsRecords
                .ToListAsync();

        public async Task InsertClientAsync(ClientRecord item)
        {
            await _conn
                .InsertAsync(item)
                .ConfigureAwait(false);
        }
        public async Task UpdateClientAsync(ClientRecord item)
        {
            await _conn
                .UpdateAsync(item)
                .ConfigureAwait(false);
        }
    }
}
