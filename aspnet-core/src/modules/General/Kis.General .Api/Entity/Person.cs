using System;
using System.Collections.Generic;
using Kis.Authorization.Users;
using Kis.Base.Entity;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Персона - физическое лицо
    /// </summary>
    public class Person : EntityBase<Guid>
    {
        /// <summary>
        /// Скомпилированное ФИО
        /// </summary>
        public string FullName { get; set; }

        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Половая принадлежность
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Ссылка на файл с фотографией
        /// </summary>
        public string PhotoUri { get; set; }

        /// <summary>
        /// Пенсионное страховое свидетельство
        /// </summary>
        public string Snils { get; set; }

        /// <summary>
        /// Страховые полисы (позможны ОМС, ДМС и пр.)
        /// </summary>
        public virtual IList<Policy> Policies { get; set; }

        /// <summary>
        /// Адрес проживания
        /// </summary>
        public Guid? AddressId { get; set; }
        public virtual PersonAddress Address { get; set; }

        /// <summary>
        /// Всевозможные контакты: email, тел., факс, skype и др.
        /// </summary>
        public virtual IList<PersonContact> Contacts { get; set; }

        /// <summary>
        /// Учетная запись, под которой зарегистрирована персона в системе
        /// </summary>
        public virtual PersonUser PersonUser { get; set; }
    }

}
