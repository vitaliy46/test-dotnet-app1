using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.PersonUser;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;
using Kis.Users;
using Kis.Users.Dto;

namespace Kis.General.Services.Crud
{
    public class PersonUserCrudAppService : AsyncCrudAppService<PersonUser, PersonUserDto, Guid, PagedPersonUserResultRequestDto, PersonUserDto, PersonUserDto>, IPersonUserCrudAppService
    {
        private readonly IUserAppService _userAppService;

        public PersonUserCrudAppService([NotNull]IRepository<PersonUser, Guid> repository,
            [NotNull] IUserAppService userAppService) : base(repository)
        {
            _userAppService = userAppService ?? throw new ArgumentNullException(nameof(userAppService));
        }

        public async Task<PersonUserDto> GetByPersonId(Guid personId)
        {
            PersonUserDto personUserDto = (await Repository.GetAllListAsync()).Where(x => x.PersonId == personId).MapTo<PersonUserDto>();

            return personUserDto;
        }

        public override async Task<PersonUserDto> Create(PersonUserDto input)
        {
            // TODO Решить вопрос с потерей пароля при маппинге
            var user = await _userAppService.Create(ObjectMapper.Map<CreateUserDto>(input.User));

            input.UserId = user.Id;

            var output = await base.Create(input);

            output.User = user;

            return output;
        }

        public override async Task<PersonUserDto> Update(PersonUserDto input)
        {
            var user = await _userAppService.Update(input.User);

            input.User = user;

            return input;
        }
    }
    
}
