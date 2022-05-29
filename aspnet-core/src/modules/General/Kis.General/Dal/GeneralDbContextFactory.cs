
using Kis.Configuration;
using Kis.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.General.Dao
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class GeneralDbContextFactory : IDesignTimeDbContextFactory<GeneralDbContext>
    {
        public GeneralDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GeneralDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            GeneralDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            var context = new GeneralDbContext(builder.Options);

            return context;
        }
    }
}
