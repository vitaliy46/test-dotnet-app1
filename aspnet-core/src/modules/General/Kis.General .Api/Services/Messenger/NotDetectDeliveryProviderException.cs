using System;
using Kis.General.Api.Constant;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Services.Messenger
{
    /// <summary>
    /// В случае если не одалось определить провайдер для доставки сообщения
    /// </summary>
    public class NotDetectDeliveryProviderException : ApplicationException
    {
        public NotDetectDeliveryProviderException() : base("Не удалось определить провайдера для отправки сообщения")
        {
        }
        public NotDetectDeliveryProviderException(ContactTypes type) 
            : base($"Не удалось определить провайдера для отправки сообщения для типа контакта {type}")
        {
        }


    }
}
