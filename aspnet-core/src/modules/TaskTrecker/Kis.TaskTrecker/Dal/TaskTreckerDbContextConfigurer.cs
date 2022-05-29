using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.TaskTrecker.Dal
{
    public static class TaskTreckerDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TaskTreckerDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "task_tracker"))
                .UseLazyLoadingProxies();
        }

        public static void Configure(DbContextOptionsBuilder<TaskTreckerDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "task_tracker"))
                .UseLazyLoadingProxies();
        }
    }
}
