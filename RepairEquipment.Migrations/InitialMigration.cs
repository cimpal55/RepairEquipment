using RepairEquipment.Migrations._20220727_Initial;
using RepairEquipment.Migrations.Interfaces;

namespace RepairEquipment.Migrations
{
    public sealed class InitialMigration : CompositeMigration
    {
        public override ISubMigration[] GetMigrations() =>
            new ISubMigration[]
            {
                new EmployeesMigration()
            };
    }
}