using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Voting.Dao
{
    public static class VotingDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<VotingDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "voting"))
                .UseLazyLoadingProxies();
        }

        public static void Configure(DbContextOptionsBuilder<VotingDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection,
                //https://stackoverflow.com/questions/38507861/entity-framework-core-change-schema-of-efmigrationshistory-table
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "voting"))
                .UseLazyLoadingProxies();
        }
    }
}
