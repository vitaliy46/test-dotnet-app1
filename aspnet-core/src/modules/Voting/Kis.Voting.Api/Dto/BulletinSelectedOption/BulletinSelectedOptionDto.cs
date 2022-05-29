using System;
using System.Xml.Serialization;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto.BulletinSelectedOption
{
    /// <summary>
    /// Варианты ответов в бюллетене пользователя по голосованию
    /// </summary>
    [XmlRoot("BulletinSelectedOptionDto", Namespace = "http://vote.itpatacea.ru", IsNullable = false)]
    //[Serializable]
    public class BulletinSelectedOptionDto : BaseDto<Guid>
    {
        /// <summary>
        /// Бюллетень пользователя
        /// </summary>
        public Guid BulletinId { get; set; }
        
        /// <summary>
        /// Выбранный вариант в бюллетене
        /// </summary>
        public Guid SelectedOptionId { get; set; }

    }
}
