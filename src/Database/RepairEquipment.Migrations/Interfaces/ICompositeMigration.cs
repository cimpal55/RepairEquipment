namespace RepairEquipment.Migrations.Interfaces
{
    public interface ICompositeMigration
    {
        ISubMigration[] GetMigrations();
    }
}
