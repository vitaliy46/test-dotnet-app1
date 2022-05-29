using System.Threading.Tasks;
using Abp.Application.Services;

namespace Kis.General.Api.Services.Messenger
{
    /// <summary>
    /// Реализуется конкретным доставщиком сообщения
    /// </summary>
    public interface IMessageDeliveryProvider : IApplicationService
    {
        void Send(Message message);
    }
}
