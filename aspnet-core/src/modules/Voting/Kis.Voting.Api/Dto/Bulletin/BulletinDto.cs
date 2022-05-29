using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Kis.Base.Dto;
using Kis.Voting.Api.Dto.BulletinSelectedOption;

namespace Kis.Voting.Api.Dto.Bulletin
{
    /// <summary>
    /// Бюллетень голосовавния заполненый участником голососвания
    /// </summary>
    [XmlRoot("BulletinDto", Namespace="http://vote.itpatacea.ru", IsNullable = false)]
    //[Serializable]
    public class BulletinDto : BaseDto<Guid>
    {
        public Guid VoteMemberId { get; set; }

        public Guid VoteId { get; set; }

        public List<BulletinSelectedOptionDto> BulletinSelectedOptions { get; set; }

        /// <summary>
        /// Xml документ c результатом голососвания по бюллетеню
        /// Эти данные в формате xml подписаны эл. подписью.
        /// </summary>
        public string VotingResultXml { get; set; }
    }
}
