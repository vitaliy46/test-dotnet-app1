using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using JetBrains.Annotations;
using Kis.Base.Services.Crud;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services;
using Kis.Organization.Api.Dto;
using Kis.Users.Dto;
using Newtonsoft.Json;

namespace Kis.Investors.WebHost.Seed.TestData
{
    /// <summary>
    /// Генерирует данные используя библиотеку Bogus
    /// </summary>
    public class PartnershipMemberDataGenerator : ApplicationService
    {
        private readonly IIocResolver _iocResolver;

        public PartnershipMemberDataGenerator([NotNull] IIocResolver iocResolver)
        {
            _iocResolver = iocResolver ?? throw new ArgumentNullException(nameof(iocResolver));
        }
        public void Create(string file)
        {
            var repo = _iocResolver.Resolve<IPartnershipMemberRepository>();

            //Если данные этого типа уже залиты в БД то тестовые данные не заливаются
            if (repo.GetAllListAsync().Result.Any()) return;

            Console.WriteLine($"Начата загрузка тестовых данных типа {typeof(PartnershipMemberDto).Name}");

            //Считываются данные из указанного файла каталога TestData в строковую переменную
            string data = "";
            using (StreamReader sr = new StreamReader(file, System.Text.Encoding.UTF8))
            {
                data = sr.ReadToEnd();
            }

            if (data != "")
            {
                var service = _iocResolver.Resolve<IPartnershipMemberCrudAppService>();

                //данные десерелизуются из json в переменную с указанным типом
                var dtos = JsonConvert.DeserializeObject<IList<CreatePartnershipMemberDto>>(data);
                foreach (var createDto in dtos)
                {
                    Console.Write(".");
                    var plane = createDto.MapTo<PlanePartnershipMemberDto>();

                    var dto = plane.MapTo<PartnershipMemberDto>();

                    dto.Contactor.Person.Contacts = new List<PersonContactDto>();
                    dto.Contactor.Person.PersonUser = new PersonUserDto
                    {
                        User = new UserDto
                        {
                            EmailAddress = createDto.Mail,
                            UserName = createDto.Login,
                            FullName = createDto.ContactorFio,
                            Surname = createDto.ContactorFio,
                            Name = createDto.ContactorFio,
                            IsActive = true
                        }
                    };

                    var c = dto.Contactor.PersonContact.Contact;
                    c.ContactType = ContactTypes.Email;
                    c.Value = createDto.Mail;

                    dto.Organization.Header.FullName = createDto.HeaderFio;
                    dto.Organization.Header.Contacts = new List<PersonContactDto>{
                        new PersonContactDto{
                             Contact = new ContactDto {ContactType = ContactTypes.Phone, Value = createDto.Phone}
                         }
                        };
                    dto.Organization.Name = createDto.Name;
                    dto.Organization.AccountingDetails.Inn = createDto.Inn;
                    dto.Organization.AccountingDetails.Ogrn = createDto.Ogrn;
                    dto.Organization.OrganizationUnitAddress.Address.FullAddress = createDto.Address;
                    dto.Organization.Header.FullName = createDto.HeaderFio;
                    dto.Contactor.PersonContact.Contact.Value = createDto.Mail;
                    dto.Contactor.PersonContact.Contact.ContactType = ContactTypes.Email;
                    dto.Contactor.Person.FullName = createDto.ContactorFio;

                    dto = service.Create(dto).Result;
                }

                //Логировать факт выгрузки данных
                Console.WriteLine();
                Console.WriteLine($"Данные типа {typeof(PartnershipMemberDto).Name} выгружены в БД");
            }
        }
    }
}

