namespace Kis.Noris.Api.Constants
{
    /// <summary>
    /// ’арактер операции, выполненной над записью в контексте обновлени€ справочника
    /// </summary>
    public enum UpdateOperation
    {
        /// <summary>
        /// «апись не изменилась
        /// </summary>
        NoChange = 0,
        /// <summary>
        /// «апись была добавлена
        /// </summary>
        Addition = 1,
        /// <summary>
        /// «апись была изменена
        /// </summary>
        Modification = 2,
        /// <summary>
        /// «апись была удалена
        /// </summary>
        Removal = 3,
        /// <summary>
        /// ќпераци€ не определена и определ€етс€ в процессе обновлени€ справочника
        /// относительно текущей обновл€емой версии
        /// </summary>
        Auto = -1
    }
}