using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.General.Api.Services.Messenger;

namespace Kis.General.Services.Messenger.DeliveryProviders
{
    //
    public class NullMessageDeliveryProvider : ApplicationService, IMessageDeliveryProvider
    {
        public void Send(Message message)
        {
            var task = new Task(() => Logger.Debug($"Иммитация отправки сообщения {message.ToString()}"));
        }
    }
}
