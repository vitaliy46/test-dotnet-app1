using System;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Подтверждение получения уведомления
    /// </summary>
    public class NoticeReceiptConfimationDto : BaseDto<Guid>
    {
        /// <summary>
        /// Подписанное эл. подписью подтверждение об уведомлении начала голосования
        /// </summary>
        public string ConfimationXml { get; set; }

        public Guid VoteId { get; set; }

        /// <summary>
        /// Участник голосования
        /// </summary>
        public Guid MemberId { get; set; }
    }
}
