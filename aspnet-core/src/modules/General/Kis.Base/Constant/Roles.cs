using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kis.Base.Constant
{
    public enum Roles
    {
        [Description("Администратор")]
        [Display(Name = "Admin")]
        Admin = 1,

        [Description("САВИ агент")]
        [Display(Name = "SAVI")]
        SAVI,

        [Description("Департамен КО")]
        [Display(Name = "DOZNKO")]
        DOZNMO,
        

        [Description("Гость")]
        [Display(Name = "Guest")]
        Guest,

        //Присваивается вновь добавленому пользователю с минимальными правами,
        //если у него указан код роли не соответветсвующей ни одной из известных в системе ролей.
        [Description("Неопределенная роль")]
        [Display(Name = "NotDefine")]
        NotDefine

    }
}
