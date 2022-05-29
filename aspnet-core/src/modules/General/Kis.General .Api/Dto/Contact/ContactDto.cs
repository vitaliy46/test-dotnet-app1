using System;
using Kis.Base.Dto;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Контактная информация: телефон/e-mail/Skype/ пр.
    /// </summary>
    public class ContactDto : BaseDto<Guid>
    {
        public string Value { get; set; }

        public ContactTypes ContactType { get; set; }
    }
}