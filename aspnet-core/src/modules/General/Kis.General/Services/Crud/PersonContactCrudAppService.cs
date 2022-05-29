using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;

namespace Kis.General.Services.Crud
{
    public class PersonContactCrudAppService : AsyncCrudAppServiceBase<PersonContact, PersonContactDto, Guid>, IPersonContactCrudAppService
    {
        private readonly IContactCrudAppService _contactCrudService;

        public PersonContactCrudAppService(
            [NotNull]IRepository<PersonContact, Guid> repository,
            [NotNull] IContactCrudAppService contactCrudService) : base(repository)
        {
            _contactCrudService = contactCrudService ?? throw new ArgumentNullException(nameof(contactCrudService));
        }

        public override async Task<PersonContactDto> Get(PersonContactDto input)
        {
            var dto = await base.Get(input);

            dto.Contact = await _contactCrudService.Get(dto.ContactId);

            return dto;
        }

        public override async Task<PersonContactDto> Get(Guid id)
        {
            return await this.Get(new PersonContactDto() { Id = id });
        }

        public override async Task<PagedResultDto<PersonContactDto>> GetAll(PagedAndSortedResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<PersonContactDto>();

            foreach (var item in result.Items)
            {
                item.Contact = await _contactCrudService.Get(item.ContactId);
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<PersonContactDto> Create(PersonContactDto input)
        {
            input.ContactId = (await _contactCrudService.Create(input.Contact)).Id;

            return await base.Create(input);
        }

        public override async Task<PersonContactDto> Update(PersonContactDto input)
        {
            var contact = await _contactCrudService.Update(input.Contact);

            input.Contact = contact;

            return input;
        }

        public override async Task Delete(PersonContactDto input)
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
