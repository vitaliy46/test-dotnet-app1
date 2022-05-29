using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto.PersonUser;

namespace Kis.General.Api.Dto.Person
{
    /// <summary>
    /// Персона - физическое лицо
    /// </summary>
    public class PersonDto : BaseDto<Guid>
    {
        public string FullName { get; set; }

        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        //[Index]
        public string Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        //[Index]
        public string Patronymic { get; set; }

        /// <summary>
        /// Половая принадлежность
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        //[Index]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Пенсионное страховое свидетельство
        /// </summary>
        //[Index]
        public string Snils { get; set; }

        ///// <summary>
        ///// Страховые полисы
        ///// </summary>
        public  IList<Guid> Policies { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Всевозможные контакты: email, тел., факс, skype и др.
        /// </summary>
        public IList<PersonContactDto> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  PersonUserDto PersonUser { get; set; }

        public override string ToString()
        {
            return $"{Patronymic} {Name} {Surname} {BirthDate} {Snils} ";
        }


    }

}
