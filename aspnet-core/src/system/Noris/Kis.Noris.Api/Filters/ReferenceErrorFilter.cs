using System;
using System.Collections.Generic;
using Kis.Noris.Api.Constants;

namespace Kis.Noris.Api.Filters
{
    public class ReferenceErrorFilter : BaseFilter
    {
        /// <summary>
        /// Определяет принадлежность ошибки к одному из типов
        /// </summary>
        public ReferenceErrors? ErrorType { get; set; }
        
        /// <summary>
        /// Определяет принадлежность ошибок к справочнику
        /// </summary>
        public Guid? Reference { get; set; }
        
        /// <summary>
        /// Определяет принадлежность
        /// </summary>
        public IList<ReferenceErrorStates> States { get; set; }

        /// <summary>
        /// Позволяет найти ошибки которые не принадлежат указанному состоянию.
        /// Используется при проверке наличия уже зарегистрированной ранее ошибки.
        /// Этот критерий работает в паре с критерием States
        /// </summary>
        public bool IsExcludeStates { get; set; } = false;
        
        /// <summary>
        /// Дата регистрации ошибки больше указанной даты
        /// </summary>
        public DateTime? Begin { get; set; }

        /// <summary>
        /// Дата регистрации ошибки меньше указанной даты
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Идентификатор ошибки по которому определяется ее наличие
        /// среди ранее зарегистрированных
        /// </summary>
        public string Idenifier { get; set; }
    }
}
