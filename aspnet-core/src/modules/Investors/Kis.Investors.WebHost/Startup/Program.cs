using Microsoft.AspNetCore.Hosting;

namespace Kis.Investors.WebHost.Startup
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
                //.UseConfiguration(config)
                .UseKestrel()
                .UseUrls("http://0.0.0.0:21021") //https://github.com/dotnet/core/issues/948  http://take.ms/VaudN
                .UseStartup<Kis.Web.Host.Startup.Startup>();
            //.UseContentRoot(contentDirectory)

            return builder;
        }
    }
}
