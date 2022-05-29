using Kis.Core;
using Kis.Core.Configuration;
using Kis.Core.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.Hr.Dao
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class NorisManagementDbContextFactory : IDesignTimeDbContextFactory<NorisManagementDbContext>
    {
        public NorisManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NorisManagementDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            NorisManagementDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            return new NorisManagementDbContext(builder.Options);
        }
    }
}
