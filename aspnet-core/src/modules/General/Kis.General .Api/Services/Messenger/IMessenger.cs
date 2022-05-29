using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Services.Messenger
{
    /// <summary>
    /// Универсалный доставщик сообщений.
    /// В его задачи входит возможность отправки сообщений наиболее удобным
    /// для пользователей способом и определение провайдера доставки сообщений
    /// </summary>
    public interface IMessenger : IApplicationService
    {
        /// <summary>
        /// Отправка сообщения персоне через указанную им систему отправки
        /// сообщений: sms|telegram|email|etc.
        /// </summary>
        /// <param name="messege"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        Task SendAsync(string messege, PersonDto to );

        /// <summary>
        /// Отправка сообщения персоне через указанный в пераметре тип системы отправки сообщений
        /// </summary>
        /// <param name="messege"></param>
        /// <param name="to"></param>
        /// <param name="ContactType">тип контакта</param>
        /// <returns></returns>
        Task SendAsync(string messege, PersonDto to, ContactTypes сontactType);

        /// <summary>
        /// Отправка сообщения по указанному контакту
        /// </summary>
        /// <param name="message"></param>
        void Send(Message message);
    }
}
