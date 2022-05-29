using Abp.Application.Services;
using Kis.General.Api.Constant;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Services.Messenger
{
    /// <summary>
    /// Определяет подходящий провайдер для отправки сообщений
    /// </summary>
    public interface IDelivaryProviderQualifier : IApplicationService
    {
        /// <summary>
        /// На основе переданных параметров квалификатор подбирает тип провайдера
        /// отправки сообщений
        /// </summary>
        /// <param name="type"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        IMessageDeliveryProvider Define(ContactTypes type, Person person = null);

    }
}
