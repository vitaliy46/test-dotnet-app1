using Kis.Core;
using Kis.Core.Configuration;
using Kis.Core.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.Staff.Dao
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class StaffDbContextFactory : IDesignTimeDbContextFactory<StaffDbContext>
    {
        public StaffDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<StaffDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            StaffDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            return new StaffDbContext(builder.Options);
        }
    }
}
