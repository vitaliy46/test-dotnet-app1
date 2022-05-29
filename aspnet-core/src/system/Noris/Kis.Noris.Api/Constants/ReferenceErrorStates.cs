using System.ComponentModel.DataAnnotations;

namespace Kis.Noris.Api.Constants
{
    /// <summary>
    /// Возможные состояния ошибок в процессе их обработки
    /// </summary>
    public enum ReferenceErrorStates
    {
        /// <summary>
        /// Вновь добавленная ошибка в процессе импорта данных
        /// </summary>
        
        [Display(Name="Новая")]
        New = 1,
        /// <summary>
        /// Отвергнутая ошибка по причине невозможности ее исправления
        /// </summary>
        [Display(Name="Отвергнута")]
        Rejected = 2,
        /// <summary>
        /// Исправление ошибки временно приостановлено
        /// </summary>
        [Display(Name = "На паузе")]
        OnPause = 3,
        /// <summary>
        /// Ошибка взята в работу
        /// </summary>
        [Display(Name = "В работе")]
        InWork = 4,
        /// <summary>
        /// Решенная ошибка
        /// </summary>
        [Display(Name = "Решена")]
        Resolved = 5,
        /// <summary>
        /// Проверенная и закрытая ошибка
        /// </summary>
        [Display(Name = "Закрыта")]
        Closed = 6
    }

    
      
  

}
