using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using RepairEquipment.Migrations;

var serviceProvider = CreateServices();

using var scope = serviceProvider.CreateScope();
UpdateDatabase(scope.ServiceProvider);

static IServiceProvider CreateServices()
{
    return new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            .AddSqlServer()
            .WithGlobalConnectionString(Environment.GetCommandLineArgs()[1])
            .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        .BuildServiceProvider(false);
}
static bool CheckDatabaseExists(string connectionString)
{
    using (var connection = new SqlConnection(connectionString))
    {
        using (var command = new SqlCommand($"SELECT db_id('RepairEquipment')", connection))
        {
            connection.Open();
            return (command.ExecuteScalar() != DBNull.Value);
        }
    }
}

static void CreateDb()
{
    var cs = "Server=.\\SQLEXPRESS;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False";
    using var con = new SqlConnection(cs);

    if (CheckDatabaseExists(cs) == false)
    {
        string query = "CREATE DATABASE RepairEquipment";
        con.Execute(query);
    }
    else
    {
        return;
    }
}

static void UpdateDatabase(IServiceProvider serviceProvider)
{
    CreateDb();
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}