using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kis.Base.Constant
{
    /// <summary>
    /// Принадлежность к полу
    /// </summary>
    public enum Genders
    {
        [Description("Мужчина")]
        [Display(Name = "Male")]
        Male = 1,

        [Description("Женщина")]
        [Display(Name = "Female")]
        Female = 2,

        [Description("Неизвестен")]
        [Display(Name = "Unknown")]
        Unknown = 3
    }
}
