using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class EmployeesMigration : ISubMigration
    {
        private const string TableName = Tables.Employee;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Employee.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Employee.Name).AsString(20).NotNullable()
                .WithColumn(Employee.Surname).AsString(20).NotNullable()
                .WithColumn(Employee.Code).AsString(10).NotNullable().Unique()
                .WithColumn(Employee.PersonalCode).AsString(15).NotNullable().Unique()
                .WithColumn(Employee.Address).AsString(100).NotNullable()
                .WithColumn(Employee.Phone).AsString(20).NotNullable()
                .WithColumn(Employee.Email).AsString(50).NotNullable()
                .WithColumn(Employee.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
