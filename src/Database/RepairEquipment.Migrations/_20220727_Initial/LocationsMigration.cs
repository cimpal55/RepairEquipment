using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using RepairEquipment.Shared.Models.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class LocationsMigration : ISubMigration
    {
        private const string TableName = Tables.Location;

        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Location.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Location.Name).AsString(30).NotNullable()
                .WithColumn(Location.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Noliktavā", Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Pie klienta", Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Norakstīts", Created = DateTime.Now });
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
