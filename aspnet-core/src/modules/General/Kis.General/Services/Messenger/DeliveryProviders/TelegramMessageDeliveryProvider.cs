using System.Linq;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.General.Api.Services.Messenger;
using TeleSharp.TL;
using TLSharp.Core;
using TLSharp.Core;

namespace Kis.General.Services.Messenger.DeliveryProviders
{
    public class TelegramMessageDeliveryProvider : ApplicationService, IMessageDeliveryProvider
    {
        //public IConfiguration Configuration { get; }
        //private readonly int _apiId = int.Parse(System.Configuration.ConfigurationManager.GetSection("Telegram").ToString());
        //private readonly int _apiId = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ApiId"]);
        //private readonly string _apiHash = System.Configuration.ConfigurationManager.AppSettings["Telegram:ApiHash"];
        //private readonly string _phoneNumber = System.Configuration.ConfigurationManager.AppSettings["Telegram:PhoneNumber"];
        //private readonly string _code = System.Configuration.ConfigurationManager.AppSettings["Telegram:ConfirmationCode"];
        private readonly int _apiId = 894333;
        private readonly string _apiHash = "efdac5c8c99e43c8153118203251b28f";
        private readonly string _phoneNumber = "79081203709";
        private readonly string _code = "75105";

        public void Send(Message message)
        {
            var client = new TelegramClient(_apiId, _apiHash);
            client.ConnectAsync().Wait();

            if (!client.IsUserAuthorized())
            {
                var hash = client.SendCodeRequestAsync(_phoneNumber).Result;
                var user = client.MakeAuthAsync(_phoneNumber, hash, _code).Result; // создаем сессию
            }

            // Получаем доступные контакты
            var result = client.GetContactsAsync().Result;

            // Находим получателя в контактах
            var recipient = result.Users
                .Where(x => x.GetType() == typeof(TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => x.Phone == message.To.Value);

            // Посылаем сообщение
            if (recipient != null)
            {
                var sentResult = client.SendMessageAsync(new TLInputPeerUser() { UserId = recipient.Id }, message.Text);
            }
        }
    }
}
