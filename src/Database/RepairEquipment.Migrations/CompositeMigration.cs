using FluentMigrator;
using RepairEquipment.Migrations.Interfaces;
using RepairEquipment.Migrations.Utils.Extensions;

namespace RepairEquipment.Migrations
{
    public abstract class CompositeMigration : Migration, ICompositeMigration
    {
        public sealed override void Up() =>
            this.RunUp(this);
        public sealed override void Down() =>
            this.RunDown(this);
        public abstract ISubMigration[] GetMigrations();
    }
}