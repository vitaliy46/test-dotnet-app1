using System.Diagnostics;
using Kis.Core;
using Kis.Core.Configuration;
using Kis.Core.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.Crm.Dao
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CrmDbContextFactory : IDesignTimeDbContextFactory<CrmDbContext>
    {
        public CrmDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CrmDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CrmDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            var context = new CrmDbContext(builder.Options);

            Debug.WriteLine(context.Database.GetDbConnection().ConnectionString);
            return context;
        }
    }
}
