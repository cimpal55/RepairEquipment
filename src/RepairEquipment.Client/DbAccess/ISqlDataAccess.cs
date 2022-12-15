namespace RepairEquipment.Client.DbAccess
{
    public interface ISqlDataAccess
    {
        string ConnectionString { get; set; }
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}