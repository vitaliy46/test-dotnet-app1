using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Документ в самом широком смысле
    /// </summary>
    public abstract class Document : EntityBase<Guid>
    {
        /// <summary>
        /// Номер документа
        /// </summary>
        //[Index]
        public string Number { get; set; }

        /// <summary>
        /// Дата начала действия/выдачи документа
        /// </summary>
        public DateTime BeginDate { get; set; }
      
    }

 }
