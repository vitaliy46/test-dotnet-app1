using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Authorization.Users;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;
using Kis.Users;
using Kis.Users.Dto;

namespace Kis.General.Services.Crud
{
    public class PersonCrudAppService : AsyncCrudAppServiceBase<
        Person, PersonDto, Guid, PagedPersonResultRequestDto, PersonDto,
        PersonDto, PersonDto, PersonDto>, IPersonCrudAppService
    {
        private readonly IPersonContactCrudAppService _personContactCrudAppService;
        private readonly IPersonUserCrudAppService _personUserCrudService;
        private readonly UserManager _userManager;
        private readonly IContactCrudAppService _contactCrudService;

        public PersonCrudAppService(
            [NotNull]IRepository<Person, Guid> repository,
            [NotNull] IPersonContactCrudAppService personContactCrudAppService,
            [NotNull] IPersonUserCrudAppService personUserCrudService,
            [NotNull] UserManager userManager,
            [NotNull] IContactCrudAppService contactCrudService) : base(repository)

        {
            _contactCrudService = contactCrudService ?? throw new ArgumentNullException(nameof(contactCrudService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _personUserCrudService = personUserCrudService ?? throw new ArgumentNullException(nameof(personUserCrudService));
            _personContactCrudAppService = personContactCrudAppService ?? throw new ArgumentNullException(nameof(personContactCrudAppService));
        }

        public override async Task<PersonDto> Get(PersonDto input)
        {
            var dto = await base.Get(input);

            if (dto != null)
            {
                foreach (var contact in dto.Contacts)
                {
                    contact.Contact = await _contactCrudService.Get(contact.ContactId);
                }

                if (dto.PersonUser != null)
                {
                    dto.PersonUser.User =
                        ObjectMapper.Map<UserDto>(
                            _userManager.Users.FirstOrDefault(x => x.Id == dto.PersonUser.UserId));
                }
            }

            return dto;
        }

        public override async Task<PersonDto> Get(Guid id)
        {
            return await this.Get(new PersonDto() { Id = id });
        }

        public override async Task<PagedResultDto<PersonDto>> GetAll(PagedPersonResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<PersonDto>();

            foreach (var item in result.Items)
            {
                foreach (var contact in item.Contacts)
                {
                    contact.Contact = await _contactCrudService.Get(contact.ContactId);
                }

                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<PersonDto> Create(PersonDto input)
        {
            var output = await base.Create(input);

            output.Contacts = new List<PersonContactDto>();

            foreach (var personContactDto in input.Contacts)
            {
                personContactDto.PersonId = output.Id;
                output.Contacts.Add(await _personContactCrudAppService.Create(personContactDto));
            }

            if (input.PersonUser != null)
            {
                input.PersonUser.PersonId = output.Id;
                output.PersonUser = await _personUserCrudService.Create(input.PersonUser);
            }

            return output;
        }

        public override async Task<PersonDto> Update(PersonDto input)
        {
            PersonUserDto personUserDto = null;
            if (input.PersonUser != null)
            {
                input.PersonUser.PersonId = input.Id;
                personUserDto = await _personUserCrudService.Update(input.PersonUser);
            }

            var personDto = await base.Update(input);

            IList<PersonContactDto> personContactDtos = new List<PersonContactDto>();
            foreach (var personContactDto in input.Contacts)
            {
                personContactDto.PersonId = personDto.Id;
                personContactDtos.Add(await _personContactCrudAppService.Update(personContactDto));
            }

            personDto.Contacts = personContactDtos;
            personDto.PersonUser = personUserDto;
           

            return personDto;
        }

    }
}
