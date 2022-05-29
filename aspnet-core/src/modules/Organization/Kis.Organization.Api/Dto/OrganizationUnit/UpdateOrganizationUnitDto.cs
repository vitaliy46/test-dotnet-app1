using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;

namespace Kis.Organization.Api.Dto
{
    /// <summary>
    /// Организационная единица
    /// </summary>
    public class UpdateOrganizationUnitDto :  IShouldNormalize
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
        public UpdatePersonDto Header { get; set; }

        // 2 свойства добавлены для простоты работы на фронтенде
        public UpdateContactDto HeaderPhone { get; set; }
        public UpdateContactDto HeaderMail { get; set; }

        public UpdateOrganizationUnitAddressDto OrganizationUnitAddress { get; set; }

        public void Normalize()
        {
        }
    }
}
