using System;
using System.Linq;
using Abp.Application.Services;
using Abp.Configuration;
using Abp.Dependency;
using JetBrains.Annotations;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Entity;
using Kis.Organization.Api.Dao.Repositories;
using Kis.Organization.Api.Entity;

namespace Kis.Investors.WebHost.Seed.TestData
{
    /// <summary>
    /// Генерирует данные используя библиотеку Bogus
    /// </summary>
    public class PartnershipDataGenerator : ApplicationService
    {
        private readonly IIocResolver _iocResolver;

        public PartnershipDataGenerator([NotNull] IIocResolver iocResolver)
        {
            _iocResolver = iocResolver ?? throw new ArgumentNullException(nameof(iocResolver));
        }

        public void Generate()
        {

            //Если данные этого типа уже залиты в БД то тестовые данные не заливаются
            var partnershipRepository = _iocResolver.Resolve<IPartnershipRepository>();
            if (partnershipRepository.GetAllListAsync().Result.Any()) return;

            Console.WriteLine($"Начата загрузка тестовых данных типа {typeof(Partnership).Name}");
            
            Console.Write(".");
            var organization = _iocResolver.Resolve<IOrganizationUnitRepository>()
                .Insert(new OrganizationUnit()
                {
                    Name = "no name",
                    Parent = null
                });
            var partnership = partnershipRepository.Insert(new Partnership()
            {
                OrganizationId = organization.Id
            });

            //В настройки приложения добавить значение
            _iocResolver.Resolve<ISettingManager>().ChangeSettingForApplicationAsync("PartnershipId", partnership.Id.ToString());


            //Логировать факт выгрузки данных
            Console.WriteLine();
            Console.WriteLine($"Данные типа {typeof(Partnership).Name} выгружены в БД");
        }
    }
}

