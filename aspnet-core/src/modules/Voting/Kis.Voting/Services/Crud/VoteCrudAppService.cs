using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Castle.Core.Internal;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Voting.Api.Constant;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Dto.VoteMember;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteCrudAppService : AsyncCrudAppServiceBase<Vote, VoteDto, Guid, VotePagedAndSortedResultRequestDto, VoteDto, VoteDto, VoteDto, VoteDto>, IVoteCrudAppService
    {
        private IVoteContextProvider _voteContextProvider;
        private readonly IVoteMemberCrudAppService _voteMemberCrudAppService;
        private readonly IVoteOptionCrudAppService _voteOptionCrudService;
        private readonly IBulletinCrudAppService _bulletinCrudService;

        public VoteCrudAppService([NotNull]IRepository<Vote, Guid> repository,
            [NotNull] IVoteContextProvider voteContextProvider,
            [NotNull] IVoteOptionCrudAppService voteOptionCrudService,
            [NotNull] IVoteMemberCrudAppService voteMemberCrudAppService,
            [NotNull] IBulletinCrudAppService bulletinCrudService) : base(repository)
        {
            _voteOptionCrudService = voteOptionCrudService ?? throw new ArgumentNullException(nameof(voteOptionCrudService));
            _voteMemberCrudAppService = voteMemberCrudAppService ?? throw new ArgumentNullException(nameof(voteMemberCrudAppService));
            _bulletinCrudService = bulletinCrudService ?? throw new ArgumentNullException(nameof(bulletinCrudService));
            _voteContextProvider = voteContextProvider ?? throw new ArgumentNullException(nameof(voteContextProvider));
        }

        public override async Task<VoteDto> Get(VoteDto input)
        {
            var dto = await base.Get(input);

            dto.ContextName = await _voteContextProvider.GetVoteContext(dto.ContextId);
            dto.Options = (await _voteOptionCrudService.GetAll(
                new PagedVoteOptionResultRequestDto() {VoteId = input.Id})).Items.ToList();

            return dto;
        }

        public override async Task<PagedResultDto<VoteDto>> GetAll(VotePagedAndSortedResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var votes = result.Items;

            if (!votes.IsNullOrEmpty())
            {
                foreach (var vote in votes)
                {
                    vote.ContextName = await _voteContextProvider.GetVoteContext(vote.ContextId);
                }
            
                // Получаем все бюллетени для текущего пользователя
                var bulletinDtos = (await _bulletinCrudService.GetAll(new PagedBulletinResultRequestDto() { UserId = AbpSession.UserId })).Items;
                
                //Получаем id-шники голосований которые уже проголосованы участником
                var votedVoteIds = bulletinDtos.Select(b => b.VoteId).ToList();

                //Среди всех голосований в котрых пользователь отмечен как участник
                //находим те, в котрых он уже принял участие (проголосовал)
                var votedVotes = votes.Where(v=> votedVoteIds.Contains(v.Id)).ToList();

                votedVotes.ForEach(v => v.IsVoted = true);
            }

            result.Items = votes;

            return result;
        }
        
        /// <summary>
        /// Формат строки сортировки "Name ASC, Age DESC"
        /// </summary>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override IQueryable<Vote> ApplySorting(IQueryable<Vote> query, VotePagedAndSortedResultRequestDto input)
        {
            query = base.ApplySorting(query, input);
            
            if (input.Sorting.IsNullOrEmpty())
            {
               query = query.OrderByDescending(x => x.BeginDateTime);
            }

            return query;
        }

        protected override IQueryable<Vote> CreateFilteredQuery(VotePagedAndSortedResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            // Выбираются все голосования в которых пользователь является организатором
            if (input.InitiatorId != null)
            {
                query = query.Where(x => x.InitiatorId == input.InitiatorId);
            }

            // Формируется список голосований, где текущий пользователь является участником
            if (input.UserId != null)
            {
                var voteIdsOfCurrentUser = _voteMemberCrudAppService.GetAll(
                    new PagedVoteMemberResultRequestDto()
                    {
                        UserId = AbpSession.UserId
                    }).Result.Items.Select(m=> m.VoteId).ToList();

                query = query.Where(v => voteIdsOfCurrentUser.Contains(v.Id) && v.IsPublished);
            }

            return query;
        }

        public override async Task<VoteDto> Create(VoteDto input)
        {
            input.Number = await GetVoteNumber();

            input.InitiatorId = AbpSession.UserId ?? default(long);
            input.VotingCalculationType = VotingCalculationTypes.Majority; // TODO  пока один единственный

            var dto = await base.Create(input);

            foreach (var option in input.Options)
            {
                option.VoteId = dto.Id;
                dto.Options.Add(await _voteOptionCrudService.Create(option));
            }

            return dto;
        }

        //Вычисляет новый, уникальный номер голосования
        private async Task<long> GetVoteNumber()
        {
            var vote =  (await Repository.GetAllListAsync())
                    .OrderByDescending(x=>x.Number).FirstOrDefault();
           
            if(vote == null)
                return  1;

            return vote.Number++;
        }

        public override async Task<VoteDto> Update(VoteDto input)
        {
            var dto = await Get(input);
            //Эти свойства обнуляются, т.к. отсутвуют в UpdateDto. Их нужно восстанавливать.
            input.Number = dto.Number;
            input.InitiatorId = dto.InitiatorId;
            input.VotingCalculationType = dto.VotingCalculationType;


            //Не возможно вносить изменения в опубликованное голосование
            if (dto.IsPublished) return dto;

            dto = await base.Update(input);
            await UpdateVoteOptions(dto, input.Options);

            return dto;
        }

        public override async Task Delete(VoteDto input)
        {
            var dto = await Get(input.Id);

            //Не возможно удалить опубликованное голосование
            if (dto.IsPublished) return;

            await base.Delete(input);
        }


        private async Task UpdateVoteOptions(VoteDto vote, IList<VoteOptionDto> inputVoteOptions)
        {
            //Выявляются идентификаторы удаленных опций
            var deletedOptionIds = vote.Options.Select(x => x.Id).Except(inputVoteOptions.Select(x => x.Id)).ToList();
            //Удаление удаленных опций
            foreach (var id in deletedOptionIds)
            {
                await _voteOptionCrudService.Delete(id);
                vote.Options.Remove(vote.Options.First(x => x.Id == id));
            }

            foreach (var inputOption in inputVoteOptions)
            {
                if (inputOption.Id.Equals(Guid.Empty))
                {
                    //Добавляются вновь добавленные опции
                    inputOption.VoteId = vote.Id;
                    vote.Options.Add(await _voteOptionCrudService.Create(inputOption));
                }
                else
                {
                    //Обновление существующих
                    var option = vote.Options.FirstOrDefault(x => x.Id == inputOption.Id);
                    if (option != null && !option.Text.Equals(inputOption.Text))
                    {
                        option.Text = inputOption.Text;
                        await _voteOptionCrudService.Update(inputOption);
                    }
                }
            }
        }
    }
    
}
