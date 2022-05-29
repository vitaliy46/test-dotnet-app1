using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Kis.Hr.Dao
{
    public static class NorisDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NorisDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NorisDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
