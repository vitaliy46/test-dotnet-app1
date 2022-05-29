namespace Kis.General.Api.Constant
{
    /// <summary>
    /// Тип прикрепления гражданина к МО
    /// </summary>
    public enum PatientAttachmentType
    {
        /// <summary>
        /// Территориальное прикрепление (на основе распределения жилых домов по МО фондом ОМС)
        /// </summary>
        Territorial = 1,

        /// <summary>
        /// Фактическое прикрепление на основании заявления гражданина
        /// </summary>
        Manual = 2
    }
}