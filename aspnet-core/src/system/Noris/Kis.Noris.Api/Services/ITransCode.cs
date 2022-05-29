namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// Интерфейс указывающий на то, что записи справочника должны
    /// содержать  код перекодировки на мастер справочник
    /// </summary>
    public interface ITransCode
    {
        string TransCode { get; }
    }

}
