using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.EntityFrameworkCore
{
    public static class KisDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<KisDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "core"))
                .UseLazyLoadingProxies();
            //Console.WriteLine($"Connection string: {connectionString}");

        }

        public static void Configure(DbContextOptionsBuilder<KisDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "core"))
                .UseLazyLoadingProxies();
            //Console.WriteLine($"Connection string: {connection.ConnectionString}");
        }
    }
}
