using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class EquipmentHistoryMigration : ISubMigration
    {
        private const string TableName = Tables.EquipmentHistory;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(EquipmentHistory.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(EquipmentHistory.EquipmentId).AsInt32().NotNullable().ForeignKey(Tables.Equipment, Equipment.Id)
                .WithColumn(EquipmentHistory.ClientId).AsInt32().Nullable()
                .WithColumn(EquipmentHistory.EmployeeId).AsInt32().Nullable()
                .WithColumn(EquipmentHistory.Location).AsString(50).NotNullable()
                .WithColumn(EquipmentHistory.DateOut).AsDateTime().NotNullable()
                .WithColumn(EquipmentHistory.DateIn).AsDateTime().Nullable()
                .WithColumn(EquipmentHistory.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Create.Index($"IX_{TableName}_{EquipmentHistory.EquipmentId}")
                .OnTable(TableName)
                .OnColumn(EquipmentHistory.EquipmentId).Ascending();
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
