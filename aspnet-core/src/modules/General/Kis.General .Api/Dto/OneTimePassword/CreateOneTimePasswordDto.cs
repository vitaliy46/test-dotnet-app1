using System;
using System.Collections.Generic;
using Abp.Runtime.Validation;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto.PersonUser;

namespace Kis.General.Api.Dto.Person
{
    /// <summary>
    /// Персона - физическое лицо
    /// </summary>
    public class CreateOneTimePasswordDto : IShouldNormalize
    {
        /// <summary>
        /// 4-х символьный одноразовый пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Пользователь, который запросил одноразовый пароль и он же должен его подтвердить
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Количество попыток которые пользователь сделал вводя одноразовый пароль
        /// </summary>
        public uint NumberOfAttempts { get; set; }

        /// <summary>
        /// true - если пароль был успешно подтвержден, false - если нет
        /// </summary>
        public bool Confirmed { get; set; }

        public void Normalize()
        {
        }
    }

}
