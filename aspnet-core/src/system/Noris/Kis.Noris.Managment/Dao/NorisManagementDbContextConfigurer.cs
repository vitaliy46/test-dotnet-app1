using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Kis.Hr.Dao
{
    public static class NorisManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NorisManagementDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NorisManagementDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
