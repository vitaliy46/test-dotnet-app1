using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using JetBrains.Annotations;
using Kis.Authorization.Users;
using Kis.Base.Services.Bl;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Services.Bl;
using Kis.General.Api.Services.Messenger;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services.Crud;
using Kis.Organization.Api.Services;
using Kis.TaskTrecker.Api.Services;
using Kis.Voting.Api.Roles;


namespace Kis.Investors.Service.Crud
{
    public class InvestedProjectCrudAppService :
        AsyncCrudAppServiceBase<InvestedProject, InvestedProjectDto, Guid,
            PagedInvestedProjectResultRequestDto, InvestedProjectDto,
            InvestedProjectDto, InvestedProjectDto, InvestedProjectDto>,
        IInvestedProjectCrudAppService
    {
        private readonly IProjectCrudAppService _projectCrudService;
        private readonly IOrganizationUnitCrudAppService _organizationUnitCrudService;
        private readonly IPersonAppService _personAppService;
        private readonly UserManager _userManager;
        private readonly IMessenger _messenger;

        public InvestedProjectCrudAppService(
            [NotNull] IInvestedProjectRepository investedProjectRepository,
            [NotNull] IProjectCrudAppService projectCrudService,
            [NotNull] IOrganizationUnitCrudAppService organizationUnitCrudService,
            [NotNull] IPersonAppService personAppService, 
            [NotNull] UserManager userManager,
            [NotNull] IMessenger messenger) : base(investedProjectRepository)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _personAppService = personAppService ?? throw new ArgumentNullException(nameof(personAppService));
            _organizationUnitCrudService = organizationUnitCrudService ?? throw new ArgumentNullException(nameof(organizationUnitCrudService));
            _projectCrudService = projectCrudService ?? throw new ArgumentNullException(nameof(projectCrudService));
        }

        public override async Task<InvestedProjectDto> Get(InvestedProjectDto input)
        {
            var dto = await base.Get(input);

            dto.Project = await _projectCrudService.Get(dto.ProjectId);

            dto.ManagingCompany = await _organizationUnitCrudService.Get(dto.ManagingCompanyId);

            //dto.Investors = await _investorCrudService.GetByProjectId(dto.ProjectId);

            return dto;
        }

        public override async Task<InvestedProjectDto> Get(Guid id)
        {
            return await this.Get(new InvestedProjectDto() { Id = id });
        }

        public override async Task<PagedResultDto<InvestedProjectDto>> GetAll(PagedInvestedProjectResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<InvestedProjectDto>();

            foreach (var item in result.Items)
            {
                item.Project = await _projectCrudService.Get(item.ProjectId);

                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        protected override IQueryable<InvestedProject> CreateFilteredQuery(PagedInvestedProjectResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);
            
            if (input.PartnershipMemberId.HasValue || input.PartnershipMemberId == default(Guid))
            {
                query = query.Where(x => x.Investors.Any(y => y.MemberId == input.PartnershipMemberId));
            }
            return query;
        }

        public override async Task<InvestedProjectDto> Create(InvestedProjectDto input)
        {
            var projectDto = await _projectCrudService.Create(input.Project);
            input.ProjectId = projectDto.Id;

            var managinCompanyDto = await _organizationUnitCrudService.Create(input.ManagingCompany);
            input.ManagingCompanyId = managinCompanyDto.Id;

            var dto = await base.Create(input);

            var userId = dto.ManagingCompany.Header.PersonUser.UserId;
            if (userId != 0)
            {
                var user = await _userManager.GetUserByIdAsync(userId);
                await _userManager.AddToRolesAsync(user,
                    new List<string>()
                    {
                        VotingStaticRoleNames.Tenants.VoteMember
                    });
            }

            dto.Project = projectDto;
            dto.ManagingCompany = managinCompanyDto;

            // TODO взять пароль из CreateUserDto
            // TODO указать ссылку страницу смены пароля
            var message = new Message()
            {
                Subject = "Регистрация в системе",
                Text = $"Вы зарегистрированы в системе, логин {dto.ManagingCompany.Header.PersonUser.User.UserName}",
                To = new ContactDto() { Value = dto.ManagingCompany.Header.PersonUser.User.EmailAddress, ContactType = ContactTypes.Email }
            };

            _messenger.Send(message);

            return dto;
        }

        public override async Task<InvestedProjectDto> Update(InvestedProjectDto input)
        {
            //при обновлении инвестируемого проекта, теоретически
            //может смениться управляющая компания. 
            //TODO Но это учтем позже
            var managingCompany = await _organizationUnitCrudService.Update(input.ManagingCompany);
            var project = await _projectCrudService.Update(input.Project);

            input.ManagingCompanyId = managingCompany.Id;
            input.ProjectId = project.Id;

            var output = await base.Update(input);

            output.ManagingCompany = managingCompany;
            output.Project = project;

            return output;
        }

        public override async Task Delete(Guid id)
        {
            var dto = await base.Get(id);

            if (dto == null)
            {
                throw new Exception("Попытка удалить несуществующую запись");
            }
            await base.Delete(id);

            var headerId = (await _organizationUnitCrudService.Get(dto.ManagingCompanyId)).HeaderId;
            //Отключаем пользователя контактного лица
            if (headerId != null)
            {
                await _personAppService.DeactivateUserFromPerson((Guid)headerId);

            }
        }
    }

}
