using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.General.Api.Services.Crud;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Dto.InvestedProject;
using Kis.Investors.Api.Services;
using Kis.Investors.Api.Services.Crud;
using Kis.Investors.Authorization;
using Kis.Organization.Api.Dto;
using Kis.TaskTrecker.Api.Dto;
using Kis.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Investors.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class InvestedProjectController : KisControllerBase<IInvestedProjectCrudAppService>
    {
        private readonly IInvestorCrudAppService _investorCrudAppService;
        private readonly IPersonCrudAppService _personCrudAppService;

        public InvestedProjectController(IInvestedProjectCrudAppService crudAppService, 
            [NotNull] IInvestorCrudAppService investorCrudAppService,
            [NotNull] IPersonCrudAppService personCrudAppService) : base(crudAppService)
        {
            _investorCrudAppService = investorCrudAppService ?? throw new ArgumentNullException(nameof(investorCrudAppService));
            _personCrudAppService = personCrudAppService ?? throw new ArgumentNullException(nameof(personCrudAppService));
        }

        [AbpAuthorize(PermissionNames.InvestedProjectList)]
        [HttpGet]
        public async Task<PagedResultDto<InvestedProjectShortDto>> Get(PagedInvestedProjectResultRequestDto input)
        {
            var result = await CrudService.GetAll(input);

            var pageResultDto = new PagedResultDto<InvestedProjectShortDto>
            {
                TotalCount = result.TotalCount,
                Items = result.Items.ToList().Select(x => x.MapTo<InvestedProjectShortDto>()).ToList()
            };

            return pageResultDto;
        }

        [AbpAuthorize(PermissionNames.InvestedProjectDetails)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaneInvestedProjectDto>> Get([FromRoute]Guid id)
        {
            var investors = (await _investorCrudAppService.GetAll(new PagedInvestorRequestDto() { InvestedProjectId = id })).Items;

            foreach (var investor in investors)
            {
                investor.Member.Contactor.Person = await _personCrudAppService.Get(investor.Member.Contactor.PersonId);
            }

            var investorOfCurentUser = investors.FirstOrDefault(x => x.Member.Contactor.Person.PersonUser.User.Id == AbpSession.UserId);

            if (!PermissionChecker.IsGranted(PermissionNames.InvestedProjectDetails) && investorOfCurentUser == null)
            {
                return new InvestedProjectPermissionViolation();
            }

            var dto = await CrudService.Get(id);

            return dto.MapTo<PlaneInvestedProjectDto>();
        }

        public class InvestedProjectPermissionViolation : ObjectResult
        {
            public InvestedProjectPermissionViolation() : base(new { error = "Вы не являетесь инвестором данного проекта." })
            {
                StatusCode = 500;
            }
        }

        [AbpAuthorize(PermissionNames.InvestedProjectManagement)]
        [HttpPut("{id}")]
        public async Task<PlaneInvestedProjectDto> Put([FromRoute]Guid id, [FromBody]PlaneInvestedProjectDto value)
        {
            var existDto = await CrudService.Get(id);

            if(existDto != null && existDto.Id == id)
            {
                existDto = ObjectMapper.Map(value, existDto);

                var phone = existDto.ManagingCompany.Header.Contacts
                    .FirstOrDefault(c =>c.Contact.Id == value.PhoneId);

                if (phone != null)
                {
                    phone.Contact.Value = value.Phone;
                }

                var mail = existDto.ManagingCompany.Header.Contacts.FirstOrDefault(c =>
                    c.Contact.Id == value.MailId);

                if (mail != null)
                {
                    mail.Contact.Value = value.Mail;
                }

                existDto = await CrudService.Update(existDto);

                return existDto.MapTo<PlaneInvestedProjectDto>();
            }

            return null;
            
        }

        [AbpAuthorize(PermissionNames.InvestedProjectManagement)]
        [HttpPost]
        public virtual async Task<PlaneInvestedProjectDto> Post([FromBody] PlaneCreateInvestedProjectDto value)
        {
            var dto = new InvestedProjectDto {Project = new ProjectDto() };
            dto.ManagingCompany = new OrganizationUnitDto();
            dto.ManagingCompany.Header = new PersonDto();
            dto.ManagingCompany.Header.Contacts = new List<PersonContactDto>{
                new PersonContactDto{
                    Contact = new ContactDto {ContactType = ContactTypes.Email, Value = value.Mail}
                },
                new PersonContactDto{
                    Contact = new ContactDto {ContactType = ContactTypes.Phone, Value = value.Phone}
                }
            };
            dto.ManagingCompany.Header.PersonUser = new PersonUserDto();
            dto.ManagingCompany.Header.PersonUser.User = new UserDto()
            {
                EmailAddress = value.Mail,
                UserName = value.Mail,
                FullName = value.HeaderFio,
                Surname = value.HeaderFio,
                Name = value.HeaderFio,
                IsActive = true
            };
            dto.ManagingCompany.OrganizationUnitAddress = new OrganizationUnitAddressDto {Address = new AddressDto()};
            dto.ManagingCompany.AccountingDetails = new AccountingDetailsDto();

            ObjectMapper.Map(value, dto);

            dto = await CrudService.Create(dto);

            return dto.MapTo<PlaneInvestedProjectDto>();
        }

        [AbpAuthorize(PermissionNames.InvestedProjectManagement)]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            await CrudService.Delete(id);

            return new OkResult();
        }
    }
}
