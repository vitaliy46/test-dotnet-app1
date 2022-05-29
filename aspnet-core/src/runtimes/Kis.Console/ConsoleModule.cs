using Abp.AutoMapper;
using Abp.Modules;
using Kis.Application;
using Kis.EntityFrameworkCore.EntityFrameworkCore;
using Kis.Hr;
using Kis.Staff;

namespace Kis.Console
{
    [DependsOn(
        //typeof(TestModule), 
        typeof(ApplicationModule),
        typeof(EntityFrameworkModule),
        typeof(HrModule),
        typeof(StaffModule))]
    public class ConsoleModule : AbpModule
    {
        public ConsoleModule(EntityFrameworkModule it2gEntityFrameworkModule)
        {
            it2gEntityFrameworkModule.SkipDbContextRegistration = true;
            it2gEntityFrameworkModule.SkipDbSeed = true;
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

        }

        public override void Initialize()
        {
            
        }
       
    }
}
