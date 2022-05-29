using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JetBrains.Annotations;
using Kis.General.Api.Constant;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services;
using Kis.Investors.Api.Services.Bl;
using Kis.Investors.Api.Services.Crud;
using Kis.Organization.Api.Dal.Repositories;
using Kis.Users;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Investors.Service.Bl
{
    public class InvestorApplicationService : ApplicationService, IInvestorApplicationService
    {
        private readonly IInvestedProjectCrudAppService _investedProjectCrudService;
        private readonly IInvestorCrudAppService _investorCrudService;
        private readonly IPartnershipMemberCrudAppService _partnershipMemberCrudService;


        public InvestorApplicationService(
            [NotNull] IInvestorCrudAppService investorCrudService,
            [NotNull] IInvestedProjectCrudAppService investedProjectCrudService,
            [NotNull] IPartnershipMemberCrudAppService partnershipMemberCrudService)
        {
            _partnershipMemberCrudService = partnershipMemberCrudService ?? throw new ArgumentNullException(nameof(partnershipMemberCrudService));
            _investedProjectCrudService = investedProjectCrudService ?? throw new ArgumentNullException(nameof(investedProjectCrudService));
            _investorCrudService = investorCrudService ?? throw new ArgumentNullException(nameof(investorCrudService));
        }

        /// <summary>
        /// Подготавливается список участников голосований на основе инвесторов
        /// указанного проекта и управляющей компании проектом
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<IList<VoteMemberDto>> PrepareVoteMembers(Guid projectId)
        {
            InvestedProjectDto investedProjectDto = await _investedProjectCrudService.Get(projectId);

            IList<InvestorDto> investorsList = await GetByProjectId(investedProjectDto.Id);

            IList<VoteMemberDto> voteMemberDtos = new List<VoteMemberDto>();
            foreach (var investor in investorsList)
            {
                var investorDto = await _investorCrudService.Get(investor.Id);

                PersonDto person = investorDto.Member.Contactor.Person;

                VoteMemberDto voteMemberDto = new VoteMemberDto();
               
                if (person.PersonUser != null)
                {
                    voteMemberDto.UserId = person.PersonUser.UserId;
                }
                else
                {
                    throw new DllNotFoundException("не найдена учетная запись для члена товарищества");
                }

                voteMemberDto.Name = person.FullName;

                voteMemberDto.VoteMemberContact = new VoteMemberContactDto()
                {
                    ContactId = investorDto.Member.Contactor.PersonContact.Contact.Id
                };

                voteMemberDtos.Add(voteMemberDto);
            }

            //Добавление в список голосующих руководителя проектной организации
            PersonUserDto personUser = investedProjectDto.ManagingCompany.Header.PersonUser;
              
            if (personUser != null)
            {
                VoteMemberDto voteMemberDto = new VoteMemberDto();

                voteMemberDto.UserId = personUser.UserId;

                PersonDto director = investedProjectDto.ManagingCompany.Header;

                voteMemberDto.Name = director.FullName;

                PersonContactDto directorEmailContact =
                    director.Contacts.FirstOrDefault(x => x.Contact.ContactType == ContactTypes.Email);
                if (directorEmailContact != null)
                {
                    voteMemberDto.VoteMemberContact = new VoteMemberContactDto()
                    {
                        ContactId = directorEmailContact.Contact.Id
                    };
                }
                else
                {
                    throw new DllNotFoundException("не найден email руководителя проектной организации");
                }

                voteMemberDtos.Add(voteMemberDto);
            }
            else
            {
                throw new DllNotFoundException("не найдена учетная запись для руководителя проектной организации");
            }

            return voteMemberDtos;
        }
        
        public async Task<IList<InvestorDto>> GetByProjectId(Guid projectId)
        {
            //GetAll() не дает полностью схормированной сущности, поэтому нужно дополнитьельно 
            //поднять из БД все сведения об инвесторе
            var result = await _investorCrudService.GetAll(new PagedInvestorRequestDto(){InvestedProjectId = projectId});

            IList<InvestorDto>  investors = new List<InvestorDto>();

            foreach (var i in result.Items)
            {
                investors.Add(await _investorCrudService.Get(i.Id));
            }
 
            return investors;
        }

        public async Task<IList<InvestorsProjectDto>> GetProjects(Guid memberId)
        {
            var filter = new PagedInvestorRequestDto() {PartnershipMemberId = memberId };

            var investors = (await _investorCrudService.GetAll(filter)).Items;

            foreach (var i in investors)
            {
                i.Project = await _investedProjectCrudService.Get(i.ProjectId);
                i.Member = await _partnershipMemberCrudService.Get(i.MemberId);
            }

            return investors.Select(x=> x.MapTo<InvestorsProjectDto>()).ToList();
        }
        
    }
}
