using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class DocumentsMigration : ISubMigration
    {
        private const string TableName = Tables.Document;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Document.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Document.ClientId).AsInt32().Nullable()
                .WithColumn(Document.EmployeeId).AsInt32().Nullable()
                .WithColumn(Document.DocumentNumber).AsString(50).NotNullable()
                .WithColumn(Document.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Create.Index($"IX_{TableName}_{Document.ClientId}")
                .OnTable(TableName)
                .OnColumn(Document.ClientId).Ascending();

            migration.Create.Index($"IX_{TableName}_{Document.EmployeeId}")
                .OnTable(TableName)
                .OnColumn(Document.EmployeeId).Ascending();
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
