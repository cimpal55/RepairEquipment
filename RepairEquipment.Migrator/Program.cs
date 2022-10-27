using RepairEquipment.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

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

static void UpdateDatabase(IServiceProvider serviceProvider)
{
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}