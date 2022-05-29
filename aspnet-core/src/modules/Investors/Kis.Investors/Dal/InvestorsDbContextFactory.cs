using System.Diagnostics;
using Kis.Configuration;
using Kis.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.Investors.Dao
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class InvestorsDbContextFactory : IDesignTimeDbContextFactory<InvestorsDbContext>
    {
        public InvestorsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<InvestorsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            InvestorsDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            var context = new InvestorsDbContext(builder.Options);

            //Debug.WriteLine(context.Database.GetDbConnection().ConnectionString);
            return context;
        }
    }
}
