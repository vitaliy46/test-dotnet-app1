using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.VoteMember;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteMemberCrudAppService : AsyncCrudAppServiceBase<VoteMember, VoteMemberDto, Guid, PagedVoteMemberResultRequestDto, VoteMemberDto, VoteMemberDto, VoteMemberDto, VoteMemberDto>,
                         IVoteMemberCrudAppService
    {
        private readonly IVoteMemberContactCrudAppService _voteMemberContactCrudService;

        public VoteMemberCrudAppService(
            [NotNull] IRepository<VoteMember, Guid> repository,
            [NotNull] IVoteMemberContactCrudAppService voteMemberContactCrudService) : base(repository)
        {
            _voteMemberContactCrudService = voteMemberContactCrudService ??
                                            throw new ArgumentNullException(nameof(voteMemberContactCrudService));
        }

        public override async Task<VoteMemberDto> Get(VoteMemberDto input)
        {
            var dto = await base.Get(input);

            dto.VoteMemberContact = await _voteMemberContactCrudService.Get(dto.VoteMemberContactId);

            return dto;
        }

        public override async Task<VoteMemberDto> Get(Guid id)
        {
            return await this.Get(new VoteMemberDto() {Id = id});
        }

        public override async Task<PagedResultDto<VoteMemberDto>> GetAll(PagedVoteMemberResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<VoteMemberDto>();

            foreach (var item in result.Items)
            {
                item.VoteMemberContact = await _voteMemberContactCrudService.Get(item.VoteMemberContactId);
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<VoteMemberDto> Create(VoteMemberDto input)
        {
            //Выделяется из данных input часть, которая соответсвует VoteMemberContact
            //и сохраняется с помощью voteMemberContactCrudService
            var voteMemberContact = await _voteMemberContactCrudService.Create(input.VoteMemberContact);

            input.VoteMemberContactId = voteMemberContact.Id;
            var dto = await base.Create(input);
            dto.VoteMemberContact = voteMemberContact;

            return dto;
        }

        public override async Task<VoteMemberDto> Update(VoteMemberDto input)
        {
            var voteMemberDto = await base.Update(input);
            voteMemberDto.VoteMemberContact = await _voteMemberContactCrudService.Update(input.VoteMemberContact);

            return voteMemberDto;
        }

        public override async Task Delete(VoteMemberDto input)
        {
            await base.Delete(input.Id);

            await _voteMemberContactCrudService.Delete(input.VoteMemberContactId);
        }

        public override async Task Delete(Guid id)
        {
            var dto = await base.Get(id);

            if (dto == null)
            {
                throw new Exception("Попытка удалить несуществующую запись");
            }
            await base.Delete(id);

            await _voteMemberContactCrudService.Delete(dto.VoteMemberContactId);
        }

        /// <summary>
        /// Сохраняет изменения в составе учасников  голосования.
        /// Список учасников может изменяться (пополняться или уменьшаться)
        /// Поэтому внутри этого метода нужно добавлять новых и удалять отсутсвующих
        /// в списке участников голосования
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<VoteMemberDto> SaveVoteMembersAsync(IList<VoteMemberDto> members)
        {
            throw new NotImplementedException();
            {

            }

        }

        protected override IQueryable<VoteMember> CreateFilteredQuery(PagedVoteMemberResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            if (input.VoteId != null)
            {
                query = query.Where(x => x.VoteId == input.VoteId);
            }

            if (input.UserId != null)
            {
                query = query.Where(x => x.UserId == input.UserId);
            }

            return query;
        }
    }
}
