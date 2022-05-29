using System;
using System.Diagnostics;
using Abp.Application.Services;
using Abp.Dependency;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Crud;

namespace Kis.Console.Tests
{
    class LinkCrudService_Tests : IApplicationService
    {
        private static ILinkAppCrudService _crudService;

        public static void CreateLink (IIocManager ioc)
        {
            _crudService = ioc.IocContainer.Resolve<ILinkAppCrudService>();

                var Link = _crudService.Create(new LinkDto
                {
                    Id = new Guid(),
                    Description = "Корпоративный сайт",
                    Url= "http://it2g.ru"
                    
                }).Result;

                Debug.WriteLine(Link.Url + "/n/r");
           
        }
    }
}
