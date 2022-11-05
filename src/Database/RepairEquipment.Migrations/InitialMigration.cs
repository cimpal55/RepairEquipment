using FluentMigrator;
using RepairEquipment.Migrations._20220727_Initial;
using RepairEquipment.Migrations.Interfaces;

namespace RepairEquipment.Migrations
{
    [TimestampedMigration(2022, 07, 27, 0, 0, "Initial migration")]
    public sealed class InitialMigration : CompositeMigration
    {
        public override ISubMigration[] GetMigrations() =>
            new ISubMigration[]
            {
                new EquipmentTypesMigration(),
                new EmployeesMigration(),
                new ClientsMigration(),
                new EquipmentsMigration(),
                new DocumentsMigration(),
                new DocumentDetailsMigration(),
                new EquipmentHistoryMigration()
            };
    }
}