namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// Базовый класс для именованых элемента справочника. Содержит общий набор
    /// полей для всех записей.
    /// </summary>
    public abstract class ReferenceNamedEntity : ReferenceEntity
    {
        /// <summary>
        /// Имя/наименование записи
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {

            return string.Format("{0}", Name);
        }

    }
}
