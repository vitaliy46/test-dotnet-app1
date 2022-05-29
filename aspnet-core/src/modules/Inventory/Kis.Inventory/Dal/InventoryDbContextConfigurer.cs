using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Inventory.Dao
{
    public static class InventoryDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<InventoryDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "inventory"));
        }

        public static void Configure(DbContextOptionsBuilder<InventoryDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "inventory"));
        }
    }
}
