using System.Diagnostics;
using Kis.Configuration;
using Kis.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kis.TaskTrecker.Dal
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TaskTreckerDbContextFactory : IDesignTimeDbContextFactory<TaskTreckerDbContext>
    {
        public TaskTreckerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TaskTreckerDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TaskTreckerDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KisConsts.ConnectionStringName));

            var context = new TaskTreckerDbContext(builder.Options);

            //Debug.WriteLine(context.Database.GetDbConnection().ConnectionString);
            return context;
        }
    }
}
