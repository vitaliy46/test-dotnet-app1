using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using AutoMapper;
using JetBrains.Annotations;
using Kis.Authorization;
using Kis.Authorization.Users;
using Kis.Base.Web.Controller;
using Kis.Controllers;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.General.Services.Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kis.General.Web.Controllers
{
    [AbpAuthorize]
    [Route("api/[controller]")]
    public class OneTimePasswordController : KisControllerBase<IOneTimePasswordCrudAppService>
    {
        private readonly IOneTimePasswordAppService _oneTimePasswordAppService;

        public OneTimePasswordController(
                IOneTimePasswordCrudAppService crudAppService, 
                [NotNull] IOneTimePasswordAppService oneTimePasswordAppService) : base(crudAppService)
        {
            _oneTimePasswordAppService = oneTimePasswordAppService ?? throw new ArgumentNullException(nameof(oneTimePasswordAppService));
        }

        /// <summary>
        /// Запрос на одноразовый пароль, который будет отправлен на предпочтительнй контакт 
        /// текущего пользователя
        /// </summary>
        [HttpGet]
        public async Task PasswordRequest()
        {
            await _oneTimePasswordAppService.PasswordRequest();
        }

        /// <summary>
        /// Подтверждение одноразового пароля полученного на запрос по другому каналу связи:
        /// sms, email, telegram  и т.д.
        /// </summary>
        /// <param name="oneTimePassword"></param>
        /// <returns>true - если проверка одноразовым паролем прошла успешно, false - если одноразовый пароль введен неверно</returns>
        [HttpPost]
        public async Task<bool> PasswordConfirmation([FromBody]string oneTimePassword)
        {
            return await _oneTimePasswordAppService.PasswordConfirmation(oneTimePassword);
        }
    }
}
