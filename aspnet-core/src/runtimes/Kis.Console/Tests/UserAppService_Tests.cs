using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Kis.Application.Users;
using Kis.Application.Users.Dto;
using Kis.Tests;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Kis.Console.Tests
{
    public class UserAppService_Tests : KisTestBase
    {
        private IUserAppService _userAppService;

        public UserAppService_Tests()
        {
           
        }

       
        public async Task<UserDto> GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetAll(new PagedResultRequestDto{MaxResultCount=20, SkipCount=0} );

            return output.Items[0];
        }

       
        public void CreateUser_Test(IIocManager ioc)
        {
            _userAppService = ioc.Resolve<IUserAppService>();

            // Act
            _userAppService.Create(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }
    }
}
