using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto.BulletinSelectedOption
{
    /// <summary>
    /// Варианты ответов в бюллетене пользователя по голосованию
    /// </summary>
    public class CreateBulletinSelectedOptionDto : IShouldNormalize
    {
        /// <summary>
        /// Выбранный вариант в бюллетене
        /// </summary>
        public Guid SelectedOptionId { get; set; }

        public void Normalize()
        {
        }
    }
}
