using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using JetBrains.Annotations;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Messenger;

namespace Kis.General.Services.Messenger
{
    public class Messenger : ApplicationService, IMessenger
    {
        private readonly IDelivaryProviderQualifier _deliveryProviderQualifier;

        public Messenger([NotNull] IDelivaryProviderQualifier deliveryProviderQualifier)
        {
            _deliveryProviderQualifier = deliveryProviderQualifier ?? throw new ArgumentNullException(nameof(deliveryProviderQualifier));
        }

        public async Task SendAsync(string messege, PersonDto to)
        {
            throw new NotImplementedException();
        }

        public async Task SendAsync(string messege, PersonDto to, ContactTypes сontactType)
        {
            throw new NotImplementedException();
        }

        public void Send(Message message)
        {
            var messageDeliveryProvider = _deliveryProviderQualifier.Define(message.To.ContactType);
            messageDeliveryProvider.Send(message);
        }
    }
}
