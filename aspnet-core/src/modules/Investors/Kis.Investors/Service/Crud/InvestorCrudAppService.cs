using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services;
using System.Linq;
using Kis.Investors.Api.Services.Crud;

namespace Kis.Investors.Service.Crud
{
    public class InvestorCrudAppService : AsyncCrudAppServiceBase<Investor, InvestorDto, Guid, PagedInvestorRequestDto, InvestorDto, InvestorDto, InvestorDto, InvestorDto>, IInvestorCrudAppService
    {
        private readonly IPartnershipMemberCrudAppService _partnershipMemberCrudAppService;
        private readonly IInvestedProjectCrudAppService _investedProjectCrudAppService;

        public InvestorCrudAppService(
            [NotNull] IInvestorRepository investorRepository,
            [NotNull] IPartnershipMemberCrudAppService partnershipMemberCrudAppService, 
            [NotNull] IInvestedProjectCrudAppService investedProjectCrudAppService) : base(investorRepository)
        {
            _partnershipMemberCrudAppService = partnershipMemberCrudAppService ?? throw new ArgumentNullException(nameof(partnershipMemberCrudAppService));
            _investedProjectCrudAppService = investedProjectCrudAppService ?? throw new ArgumentNullException(nameof(investedProjectCrudAppService));
        }

        public override async Task<InvestorDto> Get(InvestorDto input)
        {
            var dto = await base.Get(input);

            dto.Member = await _partnershipMemberCrudAppService.Get(dto.MemberId);
            dto.Project = await _investedProjectCrudAppService.Get(dto.ProjectId);

            return dto;
        }

        public override async Task<InvestorDto> Get(Guid id)
        {
            return await this.Get(new InvestorDto() { Id = id });
        }
       
        public override async Task<InvestorDto> Create(InvestorDto input)
        {
            var dto = await base.Create(input);

            dto.Member = await _partnershipMemberCrudAppService.Get(dto.MemberId);

            return dto;
        }

        public override async Task<InvestorDto> Update(InvestorDto input)
        {
            var dto = await base.Get(input);
            dto.InvestmentShare = input.InvestmentShare;

            dto = await base.Update(dto);

            return dto;
        }

        protected override IQueryable<Investor> CreateFilteredQuery(PagedInvestorRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            if (input.InvestedProjectId != null)
            {
                query = query.Where(x => x.ProjectId == input.InvestedProjectId);
            }

            if (input.PartnershipMemberId != null)
            {
                query = query.Where(x => x.MemberId == input.PartnershipMemberId);
            }

            return query;
        }

        protected override IQueryable<Investor> ApplySorting(IQueryable<Investor> query, PagedInvestorRequestDto input)
        {
            if (input.OrderByProjectNameDecending != null)
            {
                if ((bool) input.OrderByProjectNameDecending)
                {
                    query = query.OrderByDescending(x => x.Project.Project.Title);
                }
                else
                {
                    query = query.OrderBy(x => x.Project.Project.Title);
                }

            }

            return query;
        }
    }
}
