using System;
using System.Linq;
using System.Text;
using Abp.AspNetCore;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.BackgroundJobs;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Abp.Extensions;
using Castle.Facilities.Logging;
using Hangfire;
using Hangfire.PostgreSql;
using Kis.Configuration;
using Kis.Identity;
using Kis.Investors.WebHost.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
#if FEATURE_SIGNALR
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using Abp.Owin;
using It2g.Owin;
#elif FEATURE_SIGNALR_ASPNETCORE

#endif

namespace Kis.Web.Host.Startup
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhostPolicy";
        private const string _testingCorsPolicyName = "testingPolicy";

        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            //_appConfiguration = env.GetAppConfiguration();
            // Console.WriteLine($"Выбрана конфигурация {env.EnvironmentName}");
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            //Console.WriteLine($"Выбрана конфигурация {env.EnvironmentName}");

            _appConfiguration = builder.Build();

        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName))
            );

            //services.Clear(typeof(IModelValidatorProvider));

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

#if FEATURE_SIGNALR_ASPNETCORE
            services.AddSignalR();
#endif
            
            // Configure CORS for angular2 UI
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        _testingCorsPolicyName,
                        builder => builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                    );
                    options.AddPolicy(
                        _defaultCorsPolicyName,
                        builder => builder
                            .WithOrigins(
                                // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                                _appConfiguration["App:CorsOrigins"]
                                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(o => o.RemovePostFix("/"))
                                    .ToArray()
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                    );

                });

            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Vote API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);

                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                // Assign scope requirements to operations based on AuthorizeAttribute
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddHangfire(config => 
            {
                config.UsePostgreSqlStorage(_appConfiguration.GetConnectionString("Default"));
            });

            
            // Configure Abp and Dependency Injection
            return services.AddAbp<WebHostModule>(
                    // Configure Log4Net logging
                    options =>
                   options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                        f => f.UseAbpLog4Net().WithConfig("log4net.config")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(options =>{options.UseAbpRequestLocalization = false;}); // Initializes ABP framework.
           
            /// Enable CORS!
            /// https://habr.com/company/pentestit/blog/337146/ - уязвимости
            app.UseCors(_testingCorsPolicyName); 

            app.UseStaticFiles();

            app.UseAuthentication();
            
            app.UseAbpRequestLocalization();

#if FEATURE_SIGNALR
            // Integrate with OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#elif FEATURE_SIGNALR_ASPNETCORE
            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });
#endif
            app.UseHangfireServer();

            app.UseHangfireDashboard("/hangfire");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.InjectJavascript("/swagger/ui/abp.js");
                options.InjectJavascript("/swagger/ui/on-complete.js");
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Kis API V1");
            }); // URL: /swagger

            //Публикует тестовые данные в БД 
            var ioCManager = app.ApplicationServices.GetService<IIocManager>();
            var bjm = ioCManager.Resolve<IBackgroundJobManager>();
            bjm.Enqueue<SeedTestDataJob, int>(0);

        }

#if FEATURE_SIGNALR
        private static void ConfigureOwinServices(IAppBuilder app)
        {
            app.Properties["host.AppName"] = "Kis";

            app.UseAbp();
            
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };
                map.RunSignalR(hubConfiguration);
            });
        }
#endif
    }
}
