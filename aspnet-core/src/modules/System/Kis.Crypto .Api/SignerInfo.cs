namespace Kis.Crypto.Api
{
    /// <summary>
    /// Тот, кто запросил подписание данных электронной подписью
    /// Эта информация будет использована для запроса одноразового пароля
    /// </summary>
    public class SignerInfo
    {
        public string Name { get; set; }

        public string Contact { get; set; }

        public int ContactType { get; set; }
    }
}
