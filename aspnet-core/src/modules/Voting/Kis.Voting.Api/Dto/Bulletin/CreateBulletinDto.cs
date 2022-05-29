using System;
using System.Collections.Generic;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.Voting.Api.Dto.BulletinSelectedOption;

namespace Kis.Voting.Api.Dto.Bulletin
{
    /// <summary>
    /// Бюллетень голосовавния заполненый участником голососвания
    /// </summary>
    public class CreateBulletinDto : IShouldNormalize
    {
        /// <summary>
        /// TODO возможно что не нужно передавать это значение.
        /// На беке можно по сочетанию пользователь-голосование найти
        /// VoteMember
        /// </summary>
        public Guid VoteMemberId { get; set; }

        /// <summary>
        /// Объявленное голосование
        /// </summary>
        public Guid VoteId { get; set; }

        public  IList<CreateBulletinSelectedOptionDto> BulletinSelectedOptions { get; set; }

        /// <summary>
        /// Подтверждение полномочий
        /// </summary>
        public bool  AuthoritiesConfirm { get; set; }

        /// <summary>
        /// Ознакомлен с информационными материалами
        /// </summary>
        public bool ReadInformation { get; set; }

        /// <summary>
        /// С повесткой голосования согласен
        /// </summary>
        public bool AgreeWithAgenda { get; set; }

        /// <summary>
        /// Xml документ c результатом голососвания по бюллетеню
        /// Этот документ будет подписан эл. подписью на стороне клиента.
        /// </summary>
        public string VotingResultXml { get; set; }

        public void Normalize()
        {
        }
    }
}
