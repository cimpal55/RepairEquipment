using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairEquipment.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly ISqlDataAccess _data;
        public ClientService(ISqlDataAccess data)
        {
            _data = data;
        }
        public Task DeleteClientAsync(ClientRecord item)
        {
            string sql = "DELETE FROM TBL_CONF_Clients WHERE ID = @ID";
            return _data.SaveData(sql, item);
        }

        public Task<ClientRecord?> GetClientsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientRecord>> GetClientsListAsync()
        {
            string sql = "SELECT * FROM TBL_CONF_Clients";
            return _data.LoadData<ClientRecord, dynamic>(sql, new { });
        }

        public Task InsertClientAsync(ClientRecord item)
        {
            string sql = @"INSERT INTO TBL_CONF_Clients (Name, Code, RegistrationNr, LegalAddress, Phone, Email) 
                           VALUES (@Name, @Code, @RegistrationNr, @LegalAddress, @Phone, @Email);";
            return _data.SaveData(sql, item);
        }

        public Task UpdateClientAsync(ClientRecord item)
        {
            string sql = @"UPDATE TBL_CONF_Clients SET Name = @Name, Code = @Code, RegistrationNr = @RegistrationNr,
                           LegalAddress = @LegalAddress, Phone = @Phone, Email = @Email WHERE ID = @ID";
            return _data.SaveData(sql, item);
        }
    }
}
