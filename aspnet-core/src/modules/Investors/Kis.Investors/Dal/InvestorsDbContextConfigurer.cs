using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Investors.Dao
{
    public static class InvestorsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<InvestorsDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString,
                    //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                    x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "investor"))
                .UseLazyLoadingProxies();
           // Console.WriteLine($"Connection string: {connectionString}");
        }

        public static void Configure(DbContextOptionsBuilder<InvestorsDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "investor"))
                .UseLazyLoadingProxies();
           // Console.WriteLine($"Connection string: {connection.ConnectionString}");
        }
    }
}
