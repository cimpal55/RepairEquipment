using Dapper;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Microsoft.Extensions.Configuration;
using RepairEquipment.Shared.Models.Data;
using System.Data;
using System.Data.SqlClient;

namespace RepairEquipment.Client.DbAccess
{
    public class SqlDataAccess : DataConnection
    {
        public SqlDataAccess(LinqToDBConnectionOptions<SqlDataAccess> options)
            : base(options)
        {
        }
        public ITable<ClientRecord> ClientsRecords => this.GetTable<ClientRecord>();
        public ITable<EmployeeRecord> EmployeesRecords => this.GetTable<EmployeeRecord>();
        public ITable<EquipmentRecord> EquipmentRecords => this.GetTable<EquipmentRecord>();
        public ITable<EquipmentTypeRecord> EquipmentTypeRecords => this.GetTable<EquipmentTypeRecord>();
        public ITable<DocumentRecord> DocumentsRecords => this.GetTable<DocumentRecord>();
        public ITable<DocumentDetailRecord> DocumentDetailsRecords => this.GetTable<DocumentDetailRecord>();
        public ITable<LocationRecord> LocationRecords => this.GetTable<LocationRecord>();
        public ITable<EquipmentHistoryRecord> EquipmentHistoryRecords => this.GetTable<EquipmentHistoryRecord>();
    }
}
