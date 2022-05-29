using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Dto.VoteMember;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteMemberContactCrudAppService : AsyncCrudAppServiceBase<VoteMemberContact, VoteMemberContactDto, Guid, PagedVoteMemberContactResultRequestDto, VoteMemberContactDto, VoteMemberContactDto, VoteMemberContactDto, VoteMemberContactDto>, IVoteMemberContactCrudAppService
    {
        private readonly IContactCrudAppService _contactCrudService;

        public VoteMemberContactCrudAppService(
            [NotNull] IRepository<VoteMemberContact, Guid> repository,
            [NotNull] IContactCrudAppService contactCrudService) : base(
            repository)
        {
            _contactCrudService = contactCrudService ?? throw new ArgumentNullException(nameof(contactCrudService));
        }

        public override async Task<VoteMemberContactDto> Get(VoteMemberContactDto input)
        {
            var dto = await base.Get(input);

            dto.Contact = await _contactCrudService.Get(dto.ContactId);

            return dto;
        }

        public override async Task<VoteMemberContactDto> Get(Guid id)
        {
            return await this.Get(new VoteMemberContactDto() { Id = id });
        }

        public override async Task<PagedResultDto<VoteMemberContactDto>> GetAll(PagedVoteMemberContactResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<VoteMemberContactDto>();

            foreach (var item in result.Items)
            {
                item.Contact = await _contactCrudService.Get(item.ContactId);
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<VoteMemberContactDto> Create(VoteMemberContactDto input)
        {
            //Выделяется из данных input часть, которая соответсвует Contact
            //и сохраняется с помощью contactCrudService
            var dto = await base.Create(input);
            dto.Contact = await _contactCrudService.Get(dto.ContactId);

            return dto;
        }

        public override async Task<VoteMemberContactDto> Update(VoteMemberContactDto input)
        {
            var voteMemberContactDto = await base.Update(input);
            voteMemberContactDto.Contact = await _contactCrudService.Update(input.Contact);

            return voteMemberContactDto;
        }

        public override async Task Delete(VoteMemberContactDto input)
        {
            await base.Delete(input.Id);

            await _contactCrudService.Delete(input.Contact.Id);
        }

        public override async Task Delete(Guid id)
        {
            var dto = await base.Get(id);

            if (dto == null)
            {
                throw new Exception("Попытка удалить несуществующую запись");
            }
            await base.Delete(id);

            await _contactCrudService.Delete(dto.ContactId);
        }
    }
}