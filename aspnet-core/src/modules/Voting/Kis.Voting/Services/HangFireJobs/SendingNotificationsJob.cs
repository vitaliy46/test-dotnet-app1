using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Messenger;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Services.Sender
{
    /// <summary>
    /// Фоновая задача на постановку фоновых задач отправки уведомлений
    /// всем участникам голосования
    /// </summary>
    public class SendingNotificationsJob : BackgroundJob<(IList<VoteMemberDto> voteMembers, string message)>, ITransientDependency
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public SendingNotificationsJob([NotNull] IBackgroundJobManager backgroundJobManager)
        {
            _backgroundJobManager = backgroundJobManager ?? throw new ArgumentNullException(nameof(backgroundJobManager));
        }

        [UnitOfWork]
        public override void Execute((IList<VoteMemberDto> voteMembers, string message) args)
        {
            foreach (var member in args.voteMembers)
            {
                var message = new Message()
                {
                    Subject = "Уведомление о голосовании",
                    Text = args.message,
                    To = member.VoteMemberContact.Contact
                };
                //var message = $"<h1>Уважаемый(ая) {member.Name}.</h1> {args.message}";
                //здесь нужно ставить в HangFire  задачи на отправку уведомдения участнику голосования
                _backgroundJobManager.Enqueue<SendingOneNotificationJob, Message>(message);

            }
            Logger.Debug("Задачи на уведомления учасникам голосований поставлены");
        }
    }
}
