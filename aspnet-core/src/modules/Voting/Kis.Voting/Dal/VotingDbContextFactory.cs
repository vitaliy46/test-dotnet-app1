using System.Diagnostics;
using Kis.Configuration;
using Kis.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.Voting.Dao
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class VotingDbContextFactory : IDesignTimeDbContextFactory<VotingDbContext>
    {
        public VotingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VotingDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            VotingDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            var context = new VotingDbContext(builder.Options);

            //Debug.WriteLine(context.Database.GetDbConnection().ConnectionString);
            return context;
        }
    }
}
