using System.Reflection;
using Abp.Modules;
using Abp.Resources.Embedded;
using Abp.WebApi;

namespace It2g.Reporter.Web
{
    [DependsOn(typeof(AbpWebApiModule))]
    [DependsOn(typeof(ReporterModule))]
    public class ReporterWebModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ReporterWebModule).Assembly);

            //IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}