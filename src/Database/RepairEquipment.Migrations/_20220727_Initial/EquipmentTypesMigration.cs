using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class EquipmentTypesMigration : ISubMigration
    {
        private const string TableName = Tables.EquipmentType;

        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(EquipmentType.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(EquipmentType.Name).AsString(30).NotNullable().WithDefaultValue(0)
                .WithColumn(EquipmentType.FixedAssetNeeded).AsBoolean().NotNullable()
                .WithColumn(EquipmentType.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Nomas iekarta", FixedAssetNeeded = false, Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Pamatlīdzeklis", FixedAssetNeeded = false, Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Mazvērtīgais inventārs", FixedAssetNeeded = true, Created = DateTime.Now });
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
