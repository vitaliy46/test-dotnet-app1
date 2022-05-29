using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.General.Dao
{
    public static class GeneralDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<GeneralDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "general"))
                .UseLazyLoadingProxies();

        }

        public static void Configure(DbContextOptionsBuilder<GeneralDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "general"))
                .UseLazyLoadingProxies();
        }
    }
}
