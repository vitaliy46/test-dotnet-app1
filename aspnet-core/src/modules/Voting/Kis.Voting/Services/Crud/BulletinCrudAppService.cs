using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Crypto.Api.Services;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class BulletinCrudAppService : AsyncCrudAppServiceBase<Bulletin, BulletinDto, Guid, PagedBulletinResultRequestDto, BulletinDto, BulletinDto, BulletinDto, BulletinDto>, IBulletinCrudAppService
    {
        private readonly IBulletinSelectedOptionCrudAppService _selectedOptionCrudService;

        public BulletinCrudAppService([NotNull]IRepository<Bulletin, Guid> repository,
            [NotNull] IBulletinSelectedOptionCrudAppService selectedOptionCrudService) : base(repository)
        {
            _selectedOptionCrudService = selectedOptionCrudService ?? throw new ArgumentNullException(nameof(selectedOptionCrudService));
        }

        public override async Task<BulletinDto> Create(BulletinDto input)
        {
            //TODO проверить на null свойство SelectedOptions и
            //решить что в таком случае делать

            var dto = await base.Create(input);

            foreach (var option in input.BulletinSelectedOptions)
            {
                //TODO попробовать сгенерировать эксепшин и посмотреть сохранится ли бюллетень без опций, чего быть не должно
                option.BulletinId = dto.Id;
                dto.BulletinSelectedOptions.Add(await _selectedOptionCrudService.Create(option));
            }

            return dto;
        }
       

        protected override IQueryable<Bulletin> CreateFilteredQuery(PagedBulletinResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);
            if (input.UserId != null)
            {
                query = query.Where(x => x.VoteMember.UserId == input.UserId);
            }

            if (input.VoteMemberId != null)
            {
                query = query.Where(x => x.VoteMemberId == input.VoteMemberId);
            }

            if (input.VoteId != null)
            {
                query = query.Where(x => x.VoteMember.VoteId == input.VoteId);
            }

            return query;
        }
    }
    
}
