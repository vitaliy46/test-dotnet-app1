using System.Diagnostics;
using Kis.Core;
using Kis.Core.Configuration;
using Kis.Core.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.ServiceDesk.Dao
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ServiceDeskDbContextFactory : IDesignTimeDbContextFactory<ServiceDeskDbContext>
    {
        public ServiceDeskDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ServiceDeskDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ServiceDeskDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            var context = new ServiceDeskDbContext(builder.Options);

            Debug.WriteLine(context.Database.GetDbConnection().ConnectionString);
            return context;
        }
    }
}
