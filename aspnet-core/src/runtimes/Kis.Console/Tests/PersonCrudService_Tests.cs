using System;
using System.Diagnostics;
using System.Transactions;
using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Uow;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Crud;

namespace Kis.Console.Tests
{
    class PersonCrudService_Tests : ApplicationService
    {
        private IPersonCrudAppService service { get; set; }

        public void CreatePerson (IIocManager ioc)
        {

            //foreach (var handler in ioc.IocContainer.Kernel.GetAssignableHandlers(typeof(object)))
            //{
            //    Debug.WriteLine("{0} {1}",
            //        String.Join(",", handler.ComponentModel.Services.Select(s=>s.FullName)),
            //        handler.ComponentModel.Implementation);
            //}
            using (var uow = ioc.IocContainer.Resolve<IUnitOfWorkManager>().Begin(new UnitOfWorkOptions(){Scope = new TransactionScopeOption()}))
            {
                service = ioc.IocContainer.Resolve<IPersonCrudAppService>();
                var person = service.Create(new PersonDto
                {
                    Name = "Павел",
                    Surname = "Зорин",
                    Patronymic = "Семенович",
                    Gender = Gender.Female,
                    BirthDate = DateTime.Now,
                    Snils = "122112121212",

                }).Result;
                Debug.WriteLine(person.ToString() + "/n/r");



                //var repo = ioc.IocContainer.Resolve<IRepository<Person, Guid>>();
                //repo.Insert(new Person()
                //{
                //    Id = new Guid(),
                //    CreatedDate = DateTime.Now,
                //    ModifiedDate = DateTime.Now,
                //    Name = "Анна",
                //    Surname = "Зорина",
                //    Patronymic = "Набрудершафт",
                //    Gender = General.Api.Entity.Gender.Female,
                //    BirthDate = DateTime.Now,
                //    Snils = "122112121212",
                //});

                uow.Complete();
            }

            //var context = ioc.IocContainer.Resolve<GeneralDbContext>();
            //var p = new Person()
            //{
            //    Id = new Guid(),
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    Name = "Иван",
            //    Surname = "Скоропер",
            //    Patronymic = "Семенович",
            //    Gender = General.Api.Entity.Gender.Female,
            //    BirthDate = DateTime.Now,
            //    Snils = "122112121212",
            //};
            //context.Piople.Add(p);
            //context.SaveChanges();
        }
    }
}
