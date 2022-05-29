using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.General.Api.Services.Messenger;

namespace Kis.General.Services.Messenger.DeliveryProviders
{
    public class SmsMessageDeliveryProvider : ApplicationService, IMessageDeliveryProvider
    {
        public void Send(Message message)
        {
            //TODO реализовать
            var task = new Task(() => { });
        }
    }
}
