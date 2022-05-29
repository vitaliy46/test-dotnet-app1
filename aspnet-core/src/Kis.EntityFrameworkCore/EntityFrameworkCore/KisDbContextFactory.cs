using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Kis.Configuration;
using Kis.Web;

namespace Kis.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class KisDbContextFactory : IDesignTimeDbContextFactory<KisDbContext>
    {
        public KisDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<KisDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            KisDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            return new KisDbContext(builder.Options);
        }
    }
}
