using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class EquipmentsMigration : ISubMigration
    {
        private const string TableName = Tables.Equipment;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Equipment.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Equipment.Name).AsString(200).NotNullable()
                .WithColumn(Equipment.TypeId).AsInt32().NotNullable().ForeignKey(Tables.EquipmentType, EquipmentType.Id)
                .WithColumn(Equipment.Location).AsString(50).NotNullable()
                .WithColumn(Equipment.SerialNumber).AsString(20).Nullable()
                .WithColumn(Equipment.FixedAssetNr).AsInt32().Nullable()
                .WithColumn(Equipment.PurchaseDate).AsDateTime().NotNullable()
                .WithColumn(Equipment.PurchaseSum).AsDecimal(7, 2).NotNullable()
                .WithColumn(Equipment.PurchaseInvoiceNr).AsString(20).NotNullable()
                .WithColumn(Equipment.PurchaseInvoiceLink).AsString(100).NotNullable()
                .WithColumn(Equipment.DepreciationPeriod).AsInt32().NotNullable()
                .WithColumn(Equipment.Depreciation).AsDecimal(7, 2).NotNullable()
                .WithColumn(Equipment.Notes).AsString(500).NotNullable()
                .WithColumn(Equipment.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Create.Index($"IX_{TableName}_{Equipment.TypeId}")
                .OnTable(TableName)
                .OnColumn(Equipment.TypeId).Ascending();
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
