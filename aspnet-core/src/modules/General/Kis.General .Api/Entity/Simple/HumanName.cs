namespace Kis.General.Api.Entity.Simple
{
    /// <summary>
    /// Имя человека с указанием текстового представления, частей имени и информации об использовании.
    /// https://fhir-ru.github.io/datatypes.html#humanname
    /// </summary>
    public class HumanName
    {
        /// <summary>
        /// Текстовое представление полного имени
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Родовое имя (часто называемое фамилией)
        /// </summary>
        public string[] Family { get; set; }

        /// <summary>
        /// Имена (не обязательно 'первое'). Включает второе имя (middle names)
        /// </summary>
        public string[] Given { get; set; }

        /// <summary>
        /// Компоненты, идущие перед именем
        /// </summary>
        public string[] Prefix { get; set; }

        /// <summary>
        /// Компоненты, идущие после имени
        /// </summary>
        public string[] Suffix { get; set; }

    }
}
