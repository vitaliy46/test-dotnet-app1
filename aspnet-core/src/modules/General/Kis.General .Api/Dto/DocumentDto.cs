using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Документ в самом широком смысле
    /// </summary>
    public abstract class DocumentDto : BaseDto<Guid>
    {
        /// <summary>
        /// Номер документа
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата начала действия/выдачи документа
        /// </summary>
        public DateTime BeginDate { get; set; }
      
    }

 }
