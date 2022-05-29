using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Kis.Authorization.Users;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.Users;
using Kis.Users.Dto;

namespace Kis.General.Services.Bl
{
    public class PersonAppService : KisApplicationServiceBase, IPersonAppService
    {
        private readonly IUserAppService _userAppService;
        private readonly UserManager _userManager;
        private readonly IPersonRepository _personRepository;

        public PersonAppService([NotNull] IUserAppService userAppService,
            [NotNull] IPersonRepository personRepository, [NotNull] UserManager userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _userAppService = userAppService ?? throw new ArgumentNullException(nameof(userAppService));
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        public async Task DeactivateUserFromPerson(Guid personId)
        {
            var person = await _personRepository.GetAsync(personId);
            if (person.PersonUser != null)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == person.PersonUser.UserId);

                user.IsActive = false;

                await _userAppService.Update(ObjectMapper.Map<UserDto>(user));
            }
        }
    }
}
