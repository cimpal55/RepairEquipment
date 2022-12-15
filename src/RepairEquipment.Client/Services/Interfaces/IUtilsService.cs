namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IUtilsService
    {
        public Task<string> GetClientNameById(int id);
    }
}
