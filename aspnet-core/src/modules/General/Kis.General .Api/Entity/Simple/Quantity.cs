namespace Kis.General.Api.Entity.Simple
{
    public class Quantity
    {
        public decimal? Value { get; set; }

        /// <summary>
        /// Единицы измерения
        /// TODO в последствии ввести в обиход справочник единиц измерения
        /// </summary>
        public  string Measure { get; set; }
       
    }
}
