using System;
using System.Diagnostics;
using System.Reflection;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Kis.Console.Tests;

namespace Kis.Console
{
    class Program
    {
        private static AbpBootstrapper _abpBootstrapper;

        static void Main(string[] args)
        {
            
            try
            {
                // инициализация основного модуля приложения и всех его зависимых модулей
                _abpBootstrapper = AbpBootstrapper.Create<ConsoleModule>();
                _abpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig("log4net.config"));
                _abpBootstrapper.Initialize();

                var ioc = _abpBootstrapper.IocManager;

                //DatabaseInitializer.CheckMigrations(ioc);

                MenuBuilder.Show(
                    items: new[]
                    {
                        new MenuItem("Создание персоны",
                            () =>
                            {
                                var test = new PersonCrudService_Tests();
                                ioc.Release(test);
                                test.CreatePerson(ioc);
                            }),
                        new MenuItem("Создать пользователя",
                            () => new UserAppService_Tests().CreateUser_Test(ioc)),
                        new MenuItem("Создание ссылки",
                            () => LinkCrudService_Tests.CreateLink(ioc)),
                        //new MenuItem("Загрузка данных",
                        //    () => TestImport.DataLoad(ioc)),
                        //new MenuItem("Импорт данных: парсинг и систематизация",
                        //    () => new TestImport(ioc).ImportDialog()),
                        //new MenuItem("Тестирование записи MedicalRecords",
                        //    () => TestCreateMedicalRecords.RunCreating(ioc)),
                        //new MenuItem("Подготовка СЭМД документы",
                        //    () => new TestCdaCreation(ioc).CreateCdaDialogStep1()),
                        //new MenuItem("Регистрация СЭМД и EHR в ФИЭМК",
                        //    () => { ioc.Resolve<ICdaDocumentSendingToFederal>().Execute(new WorkContext()); }),
                        //new MenuItem("Тест сервера распределённых блокировок",
                        //    () => TestDistributedLocks.Test(ioc)),
                        //new MenuItem(" Дополнительные действия", () => AdditionalActionsMenu(ioc)),
                    },
                    
                    menuHeader: "ГЛАВНОЕ МЕНЮ",
                    exitAction: () => _abpBootstrapper.Dispose(),
                    exceptionHandler: ex => _abpBootstrapper.IocManager.Resolve<ILogger>().Fatal(ex.Message, ex)
                    );
            }
            catch (Exception exception)// when (!Debugger.IsAttached)
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName();
                var applicationName = assemblyName.Name.ToLower() + assemblyName.Version.ToString(3);
                
                Debug.WriteLine(applicationName, $"Exception occurred when application run!{Environment.NewLine}{exception}");
            }
        }
    }
}
