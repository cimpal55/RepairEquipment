using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class DocumentDetailsMigration : ISubMigration
    {
        private const string TableName = Tables.DocumentDetail;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(DocumentDetail.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(DocumentDetail.DocumentId).AsInt32().NotNullable().ForeignKey(Tables.Document, Document.Id)
                .WithColumn(DocumentDetail.EquipmentId).AsInt32().NotNullable().ForeignKey(Tables.Equipment, Equipment.Id)
                .WithColumn(DocumentDetail.DocumentNumber).AsString(50).NotNullable()
                .WithColumn(DocumentDetail.DocumentDateOut).AsDate().NotNullable()
                .WithColumn(DocumentDetail.DocumentDateIn).AsDate().Nullable()
                .WithColumn(DocumentDetail.Quantity).AsDecimal(7, 2).NotNullable()
                .WithColumn(DocumentDetail.Sum).AsDecimal(7, 2).NotNullable()
                .WithColumn(DocumentDetail.TotalSum).AsDecimal(7, 2).NotNullable()
                .WithColumn(DocumentDetail.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Create.Index($"IX_{TableName}_{DocumentDetail.EquipmentId}")
                .OnTable(TableName)
                .OnColumn(DocumentDetail.EquipmentId).Ascending();
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
