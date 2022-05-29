using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Api.Dto
{
    /// <summary>
    /// Организационная единица
    /// </summary>
    public class OrganizationUnitDto : BaseDto<Guid>
    {
        /// <summary>
        /// Название подразделения (Организации)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Родительская организационная единица, чьим структурным подразделением является
        /// текущий OrganizationUnit. Если null, то является высшей формой организационной единицы - юр.лицом
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// руководитель 
        /// </summary>
        public PersonDto Header { get; set; }
        public Guid? HeaderId { get; set; }

        public IList<OrganizationUnitContactDto> Contacts { get; set; }

        public OrganizationUnitAddressDto OrganizationUnitAddress { get; set; }

        /// <summary>
        /// Чаще всего сканкопии каких либо документов, но не исключается и другое.
        /// Выбор из этих медиа файлов осуществляется по типам
        /// </summary>
        public IList<OrganizationUnitMediaDto> Medias { get; set; }

        /// <summary>
        /// Бухгалтерские реквизиты
        /// </summary>
        public AccountingDetailsDto AccountingDetails { get; set; }
    }
}
