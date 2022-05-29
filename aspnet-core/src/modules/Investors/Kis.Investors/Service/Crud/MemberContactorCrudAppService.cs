using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Services.Crud;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services;

namespace Kis.Investors.Service.Crud
{
    public class MemberContactorCrudAppService : AsyncCrudAppServiceBase<MemberContactor, MemberContactorDto, Guid, PagedMemberContactorResultRequestDto, MemberContactorDto, MemberContactorDto, MemberContactorDto, MemberContactorDto>, IMemberContactorCrudAppService
    {
        private readonly IPersonCrudAppService _personCrudAppService;
        private readonly IPersonContactCrudAppService _personContactCrudAppService;

        public MemberContactorCrudAppService(
            [NotNull] IMemberContactorRepository memberContactorRepository, 
            [NotNull] IPersonCrudAppService personCrudAppService,
            [NotNull] IPersonContactCrudAppService personContactCrudAppService) : base(
            memberContactorRepository)
        {
            _personCrudAppService = personCrudAppService ?? throw new ArgumentNullException(nameof(personCrudAppService));
            _personContactCrudAppService = personContactCrudAppService ?? throw new ArgumentNullException(nameof(personContactCrudAppService));
        }

        public override async Task<MemberContactorDto> Get(MemberContactorDto input)
        {
            var dto = await base.Get(input);

            dto.Person = await _personCrudAppService.Get(dto.PersonId);
            dto.PersonContact = await _personContactCrudAppService.Get(dto.PersonContactId);

            return dto;
        }

        public override async Task<MemberContactorDto> Get(Guid id)
        {
            return await this.Get(new MemberContactorDto{ Id = id });
        }

        public override async Task<PagedResultDto<MemberContactorDto>> GetAll(PagedMemberContactorResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<MemberContactorDto>();

            foreach (var item in result.Items)
            {
                item.Person = await _personCrudAppService.Get(new PersonDto(){Id = item.PersonId});
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<MemberContactorDto> Create(MemberContactorDto input)
        {
            var contactValue = input.PersonContact.Contact.Value;

            input.Person.Contacts.Add(input.PersonContact);
            var personDto = await _personCrudAppService.Create(input.Person);

            input.PersonId = personDto.Id;
            var contact = personDto.Contacts.FirstOrDefault(x=> x.Contact.Value == contactValue);

            if (contact != null)
            {
                input.PersonContactId = contact.Id;
            }

            var dto = await base.Create(input);

            dto.Person = personDto;
            dto.PersonContact = contact;

            return dto;
        }

        public override async Task<MemberContactorDto> Update(MemberContactorDto input)
        {
            var personDto = await _personCrudAppService.Update(input.Person);

            input.PersonId = personDto.Id;

            var memberContactorDto = await base.Update(input);

            return memberContactorDto;
        }
    }
}
