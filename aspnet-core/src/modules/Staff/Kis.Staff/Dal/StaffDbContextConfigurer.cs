using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Staff.Dao
{
    public static class StaffDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<StaffDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "staff"));
        }

        public static void Configure(DbContextOptionsBuilder<StaffDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "staff"));
        }
    }
}
