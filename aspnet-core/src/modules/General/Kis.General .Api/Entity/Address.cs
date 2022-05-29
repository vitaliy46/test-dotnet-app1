using System;
using Kis.Base.Entity;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Entity
{
    public class Address : EntityBase<Guid>
    {
        
        public  AddressTypes? AddressType { get; set; }

        //Полный адрес, компилируемый и декомпилируемый из его составных частей
        public string FullAddress { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Населенный пункт
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        public string House { get; set; }

        /// <summary>
        /// Корпус
        /// </summary>
        public string Housing { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        public string Flat { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string PostCode { get; set; }
    }

   
}