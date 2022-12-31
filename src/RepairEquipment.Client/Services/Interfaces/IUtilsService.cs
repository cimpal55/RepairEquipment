using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IUtilsService
    {
        public Task<ClientRecord> GetClientNameByIdAsync(int? id);
        public Task<EmployeeRecord> GetEmployeeNameByIdAsync(int? id);
        public Task<EquipmentTypeRecord> GetEquipmentTypeByIdAsync(int? id);
        public Task<EquipmentRecord> GetEquipmentByIdAsync(int? id);
        public Task<LocationRecord> GetLocationByIdAsync(int? id);
        public string GetEquipmentTypeNameById(int? id);
        public string GetLocationNameById(int? id);
        public string GetClientNameById(int? id);
        public string GetEmployeeNameById(int? id);
        public string GetEquipmentNameById(int id);
        public Task<IEnumerable<DocumentDetailRecord>> GetDocumentDetailEquipmentByIdAsync(int id);
        public Task<IEnumerable<DocumentRecord>> GetDocumentEmployeeByIdAsync(int id);
        public Task<IEnumerable<DocumentRecord>> GetDocumentClientByIdAsync(int id);


        //public Task<IEnumerable<EquipmentRecord>> GetUsedEquipmentAsync();




    }
}
