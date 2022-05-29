using System;
using System.ComponentModel.DataAnnotations;
using Kis.Noris.Api.Constants;

namespace Kis.Noris.Api.Dpo
{
    /// <summary>
    /// Описание ошибки, возникшей при обращении со справочником.
    ///  </summary>
    public class ReferenceErrorDpo : BaseDpo
    {

        /// <summary>
        /// Наименование справочника для оператора АРМ. 
        /// </summary>
        [Display(Name = "Справочник")]
        public string ReferenceName { get; set; }

        /// <summary>
        /// Человеко-читабельное описание ошибки. Может содержать
        /// код справочной записи или др. полезную информацию.
        /// О структуре описания можно договориться с оператором АРМ.
        /// В ошибках, связанных  с перекодировкой в это свойство добавляется информация о 
        /// мастер справочнике, на который перекодируется локальный справочник
        /// </summary>
        [Display(Name = "Описание ошибки")]
        public string Description { get; set; }

        [Display(Name = "Тип ошибки")]
        public string ReferenceErrorType { get; set; }

        //Дата постановки ошибки
        [Display(Name = "Зарегистрирована")]
        public  DateTime CreatedDate { get; set; }

        //Дата исправления ошибки
        [Display(Name = "Исправлена")]
        public DateTime? FixDate { get; set; }

        /// <summary>
        /// Состояние ошибки
        /// </summary>
        [Display(Name="Статус ошибки")]
        public ReferenceErrorStates State { get; set; }

        /// <summary>
        /// Комметрарии, добавляемые сотрудниками при необходимости.
        /// Предлагается в первое время содержимое этого свойства структурировать в виде Xml файла,
        /// на тот случай если потребуется добавлять более одного комментария. Пока не
        /// видится насколько это свойство будет активно использовано для переписки.
        /// </summary>
        [Display(Name = "Есть комментарий")]
        public bool HasComments { get;  set; }
    }
}
