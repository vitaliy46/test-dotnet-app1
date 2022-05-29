using Kis.General.Api.Constant;
using Kis.General.Api.Dto;

namespace Kis.General.Api.Services.Messenger
{
    /// <summary>
    /// Унифицированная структура сообщения для передачи провайдеру отправки сообщений/
    /// Она формируется внутри Messenger и передается MessageDelivaryProvider
    /// </summary>
    public class Message
    {
        public string Subject { get; set; }

        public string Text { get; set; }

        public string From { get; set; }

        public ContactDto To { get; set; }
    }
}
