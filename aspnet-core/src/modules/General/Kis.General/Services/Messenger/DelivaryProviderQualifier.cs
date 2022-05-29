using Abp.Dependency;
using Kis.General.Api.Constant;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Messenger;
using Kis.General.Services.Messenger.DeliveryProviders;

namespace Kis.General.Services.Messenger
{
    /// <summary>
    /// Определяет подходящий провайдер для отправки сообщений
    /// </summary>
    public class DelivaryProviderQualifier : IDelivaryProviderQualifier
    {
        private readonly IIocResolver _iocResolver;

        public DelivaryProviderQualifier(IIocResolver iocResolver)
        {
            if (iocResolver != null) _iocResolver = iocResolver;
        }

        public IMessageDeliveryProvider Define(ContactTypes type, Person person = null)
        {
            //По умолчанию используем отправку mail
            var messenger = (IMessageDeliveryProvider) _iocResolver.Resolve(typeof(MailMessageDeliveryProvider));

            switch (type)
            {
                case ContactTypes.MobilePhone:
                    // TODO Реализовать отправку SMS
                    break;
                case ContactTypes.Telegram:
                    //messenger = (IMessageDeliveryProvider)_iocResolver.Resolve(typeof(TelegramMessageDeliveryProvider));
                    break;
            }

            return messenger;
        }

    }
}
