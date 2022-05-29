using System;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Kis.Voting.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Voting.Web.Controllers
{
    //[Authorize("Pages.Bulletins")]
    [Route("api/[controller]")]
    public class BulletinController : KisControllerBase<IBulletinCrudAppService>
    {

        private readonly IBulletinCrudAppService _bulletinCrudService;
        private readonly IBulletinApplicationService _bulletinApplicationService;

        public BulletinController(IBulletinCrudAppService crudAppService,
            [NotNull] IBulletinCrudAppService bulletinCrudService,
            [NotNull] IBulletinApplicationService bulletinApplicationService) : base(crudAppService)
        {
            _bulletinApplicationService = bulletinApplicationService ?? throw new ArgumentNullException(nameof(bulletinApplicationService));
            _bulletinCrudService = bulletinCrudService ?? throw new ArgumentNullException(nameof(bulletinCrudService));
            ////Пример проверки прав на выполенение операций внутри метода
            /// https://aspnetboilerplate.com/Pages/Documents/Authorization
            //if (!PermissionChecker.IsGranted("Administration.UserManagement.CreateUser"))
            //{
            //    throw new AbpAuthorizationException("You are not authorized to create user!");
            //}
        }


        //[HttpGet("{id}")]
        //public async Task<BulletinDto> Get([FromRoute]Guid id)
        //{
        //    var dto = await CrudService.Get(id);

        //    return dto;
        //}

        // По указанному голосованию и для текущего пользователя находится бюллетень голосования
        [AbpAuthorize(PermissionNames.BulletinForVote)]
        [HttpGet("/GetForVote/{voteId}")]
        public async Task<BulletinDto> GetForVote([FromRoute]Guid voteId)
        {
            var dto = await _bulletinApplicationService.GetForVote(voteId);

            return dto;
        }
    }
}
