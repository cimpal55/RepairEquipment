using RepairEquipment.Shared.Models.Data;


namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IClientService
    {
        public Task<List<ClientRecord>> GetClientsListAsync();
        public Task<List<ClientRecord>> GetClientById(int id);
        public Task InsertClientAsync(ClientRecord item);
        public Task UpdateClientAsync(ClientRecord item);
        public Task DeleteClientAsync(ClientRecord item);
    }
}
