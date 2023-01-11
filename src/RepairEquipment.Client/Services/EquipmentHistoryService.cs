using LinqToDB;
using LinqToDB.Data;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class EquipmentHistoryService : IEquipmentHistoryService
    {
        private readonly SqlDataAccess _conn;
        public EquipmentHistoryService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryListAsync()
        {
            var sql = @"SELECT ROW_NUMBER() OVER(ORDER BY eq.Name ASC) AS ID, dd.ID as DocumentDetailsID, eq.Name AS Equipment,
                      et.Name AS EquipmentType, lo.Name AS Location, cl.Name AS Client, CONCAT(em.Name, em.Surname) AS Employee,
                      dd.DocumentNumber, dd.DocumentDateOut, dd.DocumentDateIn, dd.Quantity, dd.Sum, dd.TotalSum 
                      FROM TBL_DocumentDetails dd 
                      INNER JOIN TBL_Documents do ON do.ID = dd.DocumentID 
                      INNER JOIN TBL_CONF_Equipment eq ON eq.ID = dd.EquipmentID 
                      INNER JOIN TBL_CONF_EquipmentTypes et ON et.ID = eq.TypeID 
                      INNER JOIN TBL_CONF_Locations lo ON lo.ID = eq.LocationID 
                      LEFT JOIN TBL_CONF_Clients cl ON cl.ID = do.ClientID 
                      LEFT JOIN TBL_CONF_Employees em ON em.ID = do.EmployeeID";

            return await _conn.QueryToListAsync<EquipmentHistoryRecord>(sql);
        }
        public async Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryFromDbAsync() =>
            await _conn
                    .EquipmentHistoryRecords
                    .ToListAsync();

        public async Task<IEnumerable<EquipmentHistoryRecord>> GetEquipmentHistoryListAsyncByData(int id)
        {
            var sql = @"SELECT ROW_NUMBER() OVER(ORDER BY eq.Name ASC) AS ID, dd.ID as DocumentDetailsID, eq.Name AS Equipment,
                      et.Name AS EquipmentType, lo.Name AS Location, cl.Name AS Client, CONCAT(em.Name, em.Surname) AS Employee,
                      dd.DocumentNumber, dd.DocumentDateOut, dd.DocumentDateIn, dd.Quantity, dd.Sum, dd.TotalSum 
                      FROM TBL_DocumentDetails dd 
                      INNER JOIN TBL_Documents do ON do.ID = dd.DocumentID 
                      INNER JOIN TBL_CONF_Equipment eq ON eq.ID = dd.EquipmentID 
                      INNER JOIN TBL_CONF_EquipmentTypes et ON et.ID = eq.TypeID 
                      INNER JOIN TBL_CONF_Locations lo ON lo.ID = eq.LocationID 
                      LEFT JOIN TBL_CONF_Clients cl ON cl.ID = do.ClientID 
                      LEFT JOIN TBL_CONF_Employees em ON em.ID = do.EmployeeID
                      WHERE dd.ID = @id";

            return await _conn.QueryToListAsync<EquipmentHistoryRecord>(sql, id);
        }
        //public bool CompareRows(List<EquipmentHistoryRecord> list)
        //{
        //    var sql = @"SELECT 
        //                 (CASE WHEN EXISTS 
        //                   (SELECT NULL AS EMPTY
        //                      FROM TBL_EquipmentHistory";

        //    foreach (EquipmentHistoryRecord item in list) {
                
        //    }
        //}

        public async Task InsertEquipmentHistoryAsync(IEnumerable<EquipmentHistoryRecord> item)
        {
            IEnumerable<EquipmentHistoryRecord>? data = await GetEquipmentHistoryFromDbAsync().ConfigureAwait(false);
            
            foreach (EquipmentHistoryRecord record in item)
            {
                if (!data.Any() || !data.Equals(record))
                {
                    await _conn
                        .InsertAsync(record)
                        .ConfigureAwait(false);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
