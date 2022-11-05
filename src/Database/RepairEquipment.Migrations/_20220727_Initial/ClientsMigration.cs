using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class ClientsMigration : ISubMigration
    {
        private const string TableName = Tables.Client;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Client.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Client.Name).AsString(50).NotNullable()
                .WithColumn(Client.Code).AsString(20).NotNullable()
                .WithColumn(Client.RegistrationNr).AsString(20).NotNullable()
                .WithColumn(Client.LegalAddress).AsString(100).NotNullable()
                .WithColumn(Client.Phone).AsString(20).NotNullable()
                .WithColumn(Client.Email).AsString(50).NotNullable()
                .WithColumn(Client.ContactPersonName).AsString(50).NotNullable()
                .WithColumn(Client.ContactPersonAddress).AsString(100).NotNullable()
                .WithColumn(Client.ContactPersonPhone).AsString(20).NotNullable()
                .WithColumn(Client.ContactPersonEmail).AsString(50).NotNullable()
                .WithColumn(Client.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
