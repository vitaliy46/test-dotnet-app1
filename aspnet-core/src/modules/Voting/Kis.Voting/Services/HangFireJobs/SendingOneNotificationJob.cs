using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Uow;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using JetBrains.Annotations;
using Kis.Base.Utilities;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Messenger;

namespace Kis.Voting.Services.Sender
{
    /// <summary>
    /// Фоновая задача на отправку контакту сообщения
    /// </summary>
    public class SendingOneNotificationJob : BackgroundJob<Message>, ITransientDependency
    {
        private readonly IMessenger _messenger;

        public SendingOneNotificationJob([NotNull] IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        [UnitOfWork]
        public override void Execute(Message message)
        {
            try
            {
                _messenger.Send(message);
            }
            catch (Exception e)
            {
                Logger.Debug($"Перехвачено исключение {e}");
            }

            Logger.Debug($"Отправленно уведомление {message} по адресу {message.To.Value}");
        }
    }
}
