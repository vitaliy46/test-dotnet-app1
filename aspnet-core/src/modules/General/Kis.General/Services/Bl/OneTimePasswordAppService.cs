using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using JetBrains.Annotations;
using Kis.Authorization.Users;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.General.Api.Services.Messenger;
using Kis.General.Exceptions;

namespace Kis.General.Services.Bl
{
    public class OneTimePasswordAppService : ApplicationService, IOneTimePasswordAppService
    {
        private readonly UserManager _userManager;
        private readonly IOneTimePasswordCrudAppService _oneTimePasswordCrudAppService;
        //private readonly IPersonUserCrudAppService _personUserCrudAppService;
        //private readonly IPersonCrudAppService _personCrudAppService;
        //private readonly IPersonContactCrudAppService _personContactCrudAppService;
        private readonly IMessenger _messenger;

        public OneTimePasswordAppService(
            [NotNull] UserManager userManager, 
            [NotNull] IOneTimePasswordCrudAppService oneTimePasswordCrudAppService, 
            [NotNull] IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            _oneTimePasswordCrudAppService = oneTimePasswordCrudAppService ?? throw new ArgumentNullException(nameof(oneTimePasswordCrudAppService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task PasswordRequest()
        {
            long userId = CheckAuthorize();

            var savedPassword = (await _oneTimePasswordCrudAppService.GetAll(new PagedOneTimePasswordResultRequestDto() { UserId = userId })).Items.FirstOrDefault();
            if (savedPassword != null)
            {
                // Если одноразовый пароль запрашивается повторно, удаляем существующий и создаем новый (например не пришло сообщение на контакт пользователя, и он запросил новый пароль)
                await _oneTimePasswordCrudAppService.Delete(savedPassword.Id);
            }

            var password = new OneTimePasswordDto
            {
                Password = new Random().Next(1000, 9999).ToString("D4"),
                UserId = userId,
                NumberOfAttempts = 0,
                Confirmed = false
            };

            password = await _oneTimePasswordCrudAppService.Create(password);

            _messenger.Send(new Message()
            {
                Subject = "Пароль для подтверждения операции",
                Text = $"{password.Password}",
                To = new ContactDto() { Value = (await _userManager.FindByIdAsync(AbpSession.UserId.ToString())).EmailAddress, ContactType = ContactTypes.Email }
            });
        }

        public async Task<bool> PasswordConfirmation(string password)
        {
            long userId = CheckAuthorize();

            var savedPassword = (await _oneTimePasswordCrudAppService.GetAll(new PagedOneTimePasswordResultRequestDto(){ UserId = userId })).Items.FirstOrDefault();

            // Исключение если пароль не запрашивался
            if (savedPassword == null) throw new OneTimeNullPasswordException();

            if (AbpSession.UserId != savedPassword.UserId) throw new AbpAuthorizationException("Попытка несанкционированного доступа");

            // Исключение если пароль уже подтвержден
            if (savedPassword.Confirmed) throw new OneTimePasswordIsAlreadyConfirmedException();

            if (password == savedPassword.Password)
            {
                savedPassword.Confirmed = true;
                savedPassword.NumberOfAttempts++;
                await _oneTimePasswordCrudAppService.Update(savedPassword);
            }
            else
            {
                savedPassword.NumberOfAttempts++;
                await _oneTimePasswordCrudAppService.Update(savedPassword);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод, проверяющий подтверждение одноразового пароля, вызывается в коде, где необходима такая проверка
        /// </summary>
        /// <returns></returns>
        public async Task CheckPasswordConfirmed()
        {
            long userId = CheckAuthorize();

            var password = (await _oneTimePasswordCrudAppService.GetAll(new PagedOneTimePasswordResultRequestDto(){ UserId = userId })).Items.FirstOrDefault();

            // Исключение если пароль не запрашивался
            if (password == null) throw new OneTimeNullPasswordException();

            // Исключение если пароль не подтвержден
            if (password.Confirmed == false) throw new OneTimeNotConfirmedPasswordException();

            await _oneTimePasswordCrudAppService.Delete(password.Id);
        }

        private long CheckAuthorize()
        {
            long userId;

            if (AbpSession.UserId != null)
            {
                userId = (long)AbpSession.UserId;
            }
            else
            {
                throw new AbpAuthorizationException("Вы не вошли в систему");
            }

            return userId;
        }
    }
}
