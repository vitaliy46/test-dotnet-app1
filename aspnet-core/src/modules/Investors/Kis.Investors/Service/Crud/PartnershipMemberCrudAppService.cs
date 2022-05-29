using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using JetBrains.Annotations;
using Kis.Authorization.Users;
using Kis.Base.Services.Bl;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.General.Api.Services.Messenger;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Services;
using Kis.Voting.Api.Roles;

namespace Kis.Investors.Service.Crud
{
    public class PartnershipMemberCrudAppService : AsyncCrudAppServiceBase<PartnershipMember, PartnershipMemberDto, Guid, PagedPartnershipMemberResultRequestDto, PartnershipMemberDto, PartnershipMemberDto, PartnershipMemberDto, PartnershipMemberDto>, IPartnershipMemberCrudAppService
    {

        private readonly IOrganizationUnitCrudAppService _organizationUnitCrudAppService;
        private readonly IMemberContactorCrudAppService _memberContactorCrudService;
        private readonly IPersonContactCrudAppService _personContactCrudAppService;
        private readonly IPersonAppService _personAppService;
        private readonly UserManager _userManager;
        private readonly IMessenger _messenger;

        public PartnershipMemberCrudAppService(
            [NotNull] IPartnershipMemberRepository partnershipMemberRepository,
            [NotNull] IOrganizationUnitCrudAppService organizationUnitCrudAppService,
            [NotNull] IMemberContactorCrudAppService memberContactorCrudService,
            [NotNull] IPersonAppService personAppService,
            [NotNull] IPersonContactCrudAppService personContactCrudAppService, 
            [NotNull] UserManager userManager,
            [NotNull] IMessenger messenger) 
            : base(partnershipMemberRepository)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _personAppService = personAppService ?? throw new ArgumentNullException(nameof(personAppService));
            _organizationUnitCrudAppService = organizationUnitCrudAppService ?? throw new ArgumentNullException(nameof(organizationUnitCrudAppService));
            _memberContactorCrudService = memberContactorCrudService ?? throw new ArgumentNullException(nameof(memberContactorCrudService));
            _personContactCrudAppService = personContactCrudAppService ?? throw new ArgumentNullException(nameof(personContactCrudAppService));
        }

        public override async Task<PartnershipMemberDto> Get(PartnershipMemberDto input)
        {
            var dto = await base.Get(input);

            dto.Organization = await _organizationUnitCrudAppService.Get(dto.OrganizationId);
            dto.Contactor = await _memberContactorCrudService.Get(dto.Contactor.Id);

            return dto;
        }

        public override async Task<PartnershipMemberDto> Get(Guid id)
        {
            return await this.Get(new PartnershipMemberDto() { Id = id });
        }

        public override async Task<PagedResultDto<PartnershipMemberDto>> GetAll(PagedPartnershipMemberResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<PartnershipMemberDto>();

            foreach (var item in result.Items)
            {
                list.Add(await Get(item.Id));
            }

            result.Items = list;

            return result;
        }

        public override async Task<PartnershipMemberDto> Create(PartnershipMemberDto input)
        {
            OrganizationUnitDto organizationUnit = await _organizationUnitCrudAppService.Create(input.Organization);
            input.OrganizationId = organizationUnit.Id;

            // без OrganizationUnit PartnershipMember не сохранится
            var dto = await base.Create(input);

            // MemberContactor необязателен, поэтому создаем после PartnershipMember
            if (input.Contactor != null)
            {
                input.Contactor.PartnershipMemberId = dto.Id;
                dto.Contactor = await _memberContactorCrudService.Create(input.Contactor);

                var user = await _userManager.GetUserByIdAsync(dto.Contactor.Person.PersonUser.User.Id);
                await _userManager.AddToRolesAsync(user, new List<string>()
                {
                    VotingStaticRoleNames.Tenants.VoteMember
                });
            }

            dto.Organization = organizationUnit;

            // TODO взять пароль из CreateUserDto
            // TODO указать ссылку страницу смены пароля
            var message = new Message()
            {
                Subject = "Регистрация в системе",
                Text = $"Вы зарегистрированы в системе, логин {dto.Contactor.Person.PersonUser.User.UserName}",
                To = new ContactDto() { Value = dto.Contactor.Person.PersonUser.User.EmailAddress, ContactType = ContactTypes.Email }
            };

            _messenger.Send(message);

            return dto;
        }

        public override async Task<PartnershipMemberDto> Update(PartnershipMemberDto input)
        {
            var partnershipMemberDto = await base.Update(input);

            partnershipMemberDto.Organization = await _organizationUnitCrudAppService.Update(input.Organization);

            if (input.Contactor != null)
            {
                partnershipMemberDto.Contactor = await _memberContactorCrudService.Update(input.Contactor);
                partnershipMemberDto.Contactor.PersonContact = await _personContactCrudAppService.Update(input.Contactor.PersonContact);
            }

            return partnershipMemberDto;
        }

        public override async Task Delete(Guid id)
        {
            var dto = await Get(id);

            await base.Delete(id);
           
            //Отключаем пользователя контактного лица
            if (dto.Contactor != null)
            {
                await _personAppService.DeactivateUserFromPerson(dto.Contactor.PersonId);
            }
        }
    }

}
