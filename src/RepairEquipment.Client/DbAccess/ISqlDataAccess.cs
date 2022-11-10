namespace RepairEquipment.Client.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connString);
        Task SaveData<T>(string sql, T parameters, string connString);
    }
}