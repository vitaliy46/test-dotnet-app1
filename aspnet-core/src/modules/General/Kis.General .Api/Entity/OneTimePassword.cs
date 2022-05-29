using System;
using System.Collections.Generic;
using Kis.Authorization.Users;
using Kis.Base.Entity;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Одноразовый пароль для подтверждения действий
    /// </summary>
    public class OneTimePassword : EntityBase<Guid>
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
    }

}
