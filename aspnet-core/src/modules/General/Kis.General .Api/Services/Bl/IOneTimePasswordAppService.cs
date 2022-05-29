using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Authorization.Users;
using Kis.General.Api.Dto;

namespace Kis.General.Api.Services.Bl
{
    /// <summary>
    /// Описание см. в разделе "Подтверждение операций одноразовым паролем"
    /// </summary>
    public interface IOneTimePasswordAppService : IApplicationService
    {
        /// <summary>
        /// Пользователю на его предпочтительный контакт отправляетс сгенерированный
        /// одноразовый пароль
        /// </summary>
        /// /// <param name="contactDto"></param>
        /// <returns></returns>
        Task PasswordRequest();

        /// <summary>
        /// Принимает одноразовый пароль введенный на клиенте и проверяет его
        /// на совпадение с тем, котрый был сгенерирован и выслан клиенту.
        ///  </summary>
        /// <param name="oneTimePassword"></param>
        /// <returns>В случае совпадения, считается что клиент подтвердил свою идентичность
        /// и ему высылается true</returns>
        Task<bool> PasswordConfirmation(string oneTimePassword);

        /// <summary>
        /// Метод, проверяющий подтверждение одноразового пароля, в том месте кода где
        /// необходима усиленная защита проверки идентичности
        /// </summary>
        /// <returns>В случае неподтверждения генерируются эксепшены и таким
        /// образом клиент узнает о причине неавполнения операции</returns>
        Task CheckPasswordConfirmed();
    }
}
