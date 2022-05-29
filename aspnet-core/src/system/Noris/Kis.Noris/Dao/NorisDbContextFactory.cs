using Kis.Core;
using Kis.Core.Configuration;
using Kis.Core.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.Hr.Dao
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class NorisDbContextFactory : IDesignTimeDbContextFactory<NorisDbContext>
    {
        public NorisDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NorisDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            NorisDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            return new NorisDbContext(builder.Options);
        }
    }
}
