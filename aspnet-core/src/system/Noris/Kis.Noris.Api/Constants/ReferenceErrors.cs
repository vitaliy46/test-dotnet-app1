using System.ComponentModel;

namespace Kis.Noris.Api.Constants
{
    /// <summary>
    /// Возможные типы ошибок при работе со справочниками
    /// </summary>
    public enum ReferenceErrors
    {
        [Description("Нет кода")]
        CodeIsMissing = 1,

        [Description("Ошибка перекодировки")]
        TranscodeIsMissing = 2,

        [Description("Ошибка обновления")]
        UpdateError = 3,

        [Description("Структура справочника изменена")]
        ChangedStructure = 4
    }
}
