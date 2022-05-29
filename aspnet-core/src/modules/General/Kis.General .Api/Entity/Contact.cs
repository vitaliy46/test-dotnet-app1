using System;
using Kis.Base.Entity;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Контактная информация: телефон/e-mail/Skype/ пр.
    /// </summary>
    public class Contact : EntityBase<Guid>
    {
        /// <summary>
        /// Сам контакт. Например  adam@gmail.com если в качестве типа указан эл. адрес
        /// </summary>
        public string Value { get; set; }
        
        public ContactTypes ContactType { get; set; }
   
    }
}