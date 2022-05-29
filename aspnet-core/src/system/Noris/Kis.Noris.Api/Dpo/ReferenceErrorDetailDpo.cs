using System.ComponentModel.DataAnnotations;

namespace Kis.Noris.Api.Dpo
{
    /// <summary>
    /// Описание ошибки, возникшей при обращении со справочником.
    ///  </summary>
    public class ReferenceErrorDetailDpo : ReferenceErrorDpo
    {
        /// <summary>
        /// Наименование типа справочника зарегистрированного в системе
        /// для разработчиков системы
        /// </summary>
        [Display(Name = ".net тип справочника")]
        public string ReferenceTypeName { get; set; }

        /// <summary>
        /// Состояние ошибки
        /// </summary>

        [Display(Name = "Полное описание ошибки")]
        public string FullDescription { get; set; }

        /// <summary>
        /// Комметрарии, добавляемые сотрудниками при необходимости.
        /// Предлагается в первое время содержимое этого свойства структурировать в виде Xml файла,
        /// на тот случай если потребуется добавлять более одного комментария. Пока не
        /// видится насколько это свойство будет активно использовано для переписки.
        /// </summary>
        [Display(Name = "Комментарии к ошибке")]
        public  string Comments { get; set; }

        /// <summary>
        /// Поле, в котором содержится различная важная информация об ошибке. Информация, ее формат и 
        /// семантика могут различаться в зависимости от типа ошибки
        /// </summary>
        public string ErrorData { get; set; }
    }
}
