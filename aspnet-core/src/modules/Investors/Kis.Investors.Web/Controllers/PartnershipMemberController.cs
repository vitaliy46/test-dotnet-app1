using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Services;
using Kis.Investors.Authorization;
using Kis.Organization.Api.Dto;
using Kis.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Investors.Web.Controllers
{
    [AbpAuthorize(PermissionNames.PartnershipMemberManagement)]
    [Route("api/[controller]")]
    public class PartnershipMemberController : KisControllerBase<IPartnershipMemberCrudAppService>
    {
        private readonly IInvestorRepository _investorRepository;

        public PartnershipMemberController(
            IPartnershipMemberCrudAppService crudAppService,
            [NotNull] IInvestorRepository investorRepository) : base(crudAppService)
        {
            _investorRepository = investorRepository ?? throw new ArgumentNullException(nameof(investorRepository));
        }

        [HttpGet]
        public async Task<PagedResultDto<PartnershipMemberShortDto>> Get()
        {
            var result = await CrudService.GetAll(new PagedPartnershipMemberResultRequestDto());

            IList<PartnershipMemberShortDto> members = new List<PartnershipMemberShortDto>();

            foreach (var item in result.Items)
            {
                var member = item.MapTo<PartnershipMemberShortDto>();
                member.ContactorName = item.Contactor.Person.FullName;//Почему то маппинг не срабатывает, хотя и прописан. Убрать после того как устранится проблема.
                member.ProjectsCount = _investorRepository.GetAll().Count(z => z.MemberId == member.Id);
                members.Add(member);
            }

            var pageResultDto = new PagedResultDto<PartnershipMemberShortDto>()
            {
                TotalCount = result.TotalCount,
                Items = (IReadOnlyList<PartnershipMemberShortDto>)members
            };

            return pageResultDto;
        }

        [HttpGet("{id}")]
        public async Task<PlanePartnershipMemberDto> Get([FromRoute]Guid id)
        {
            var dto = await CrudService.Get(id);

            return dto.MapTo<PlanePartnershipMemberDto>();
        }

        [HttpPut("{id}")]
        public async Task<PlanePartnershipMemberDto> Put([FromRoute]Guid id, [FromBody]PlanePartnershipMemberDto value)
        {
            var existDto = await CrudService.Get(id);

            if (existDto != null && existDto.Id == id)
            {
                existDto = ObjectMapper.Map(value, existDto);

                var personContactDto = existDto.Organization.Header.Contacts.FirstOrDefault(c => c.Id == value.PhoneId);
                if (personContactDto != null)
                {
                    personContactDto.Contact.Value = value.Phone;
                }

                existDto = await CrudService.Update(existDto);

                return existDto.MapTo<PlanePartnershipMemberDto>();
            }

            return null;

        }

        [HttpPost]
        public virtual async Task<PlanePartnershipMemberDto> Post([FromBody] CreatePartnershipMemberDto value)
        {
            var plane = value.MapTo<PlanePartnershipMemberDto>();
            var dto = plane.MapTo<PartnershipMemberDto>();
            dto.Contactor = new MemberContactorDto();
            dto.Contactor.Person = new PersonDto();
            dto.Contactor.Person.Contacts= new List<PersonContactDto>();
            dto.Contactor.Person.PersonUser = new PersonUserDto();
            dto.Contactor.Person.PersonUser.User = new UserDto()
            {
                EmailAddress = value.Mail,
                UserName = value.Mail,
                FullName = value.ContactorFio,
                Surname = value.ContactorFio,
                Name = value.ContactorFio,
                IsActive = true
            };
            dto.Contactor.PersonContact = new PersonContactDto()
            {
                Contact = new ContactDto {ContactType = ContactTypes.Email, Value = value.Mail}
            };
            dto.Organization = new OrganizationUnitDto();
            dto.Organization.Header = new PersonDto(){FullName = value.HeaderFio};
            dto.Organization.Header.Contacts = new List<PersonContactDto>{
                new PersonContactDto{
                    Contact = new ContactDto {ContactType = ContactTypes.Phone, Value = value.Phone}
                }
            };
            
            dto.Organization.OrganizationUnitAddress = new OrganizationUnitAddressDto { Address = new AddressDto() };
            dto.Organization.AccountingDetails = new AccountingDetailsDto();

           // ObjectMapper.Map(value, dto);
           //Маппинг временно перенесен сюда, пока не разобрался с ошибкой
            dto.Organization.Name =value.Name;
            dto.Organization.AccountingDetails.Inn = value.Inn;
            dto.Organization.AccountingDetails.Ogrn = value.Ogrn;
            dto.Organization.OrganizationUnitAddress.Address.FullAddress = value.Address;
            dto.Organization.Header.FullName = value.HeaderFio;
            dto.Contactor.PersonContact.Contact.Value = value.Mail;
            dto.Contactor.PersonContact.Contact.ContactType =  ContactTypes.Email;
            dto.Contactor.Person.FullName = value.ContactorFio;

            dto = await CrudService.Create(dto);

            return dto.MapTo<PlanePartnershipMemberDto>();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            await CrudService.Delete(id);
            
            return new OkResult();
        }
    }
}
