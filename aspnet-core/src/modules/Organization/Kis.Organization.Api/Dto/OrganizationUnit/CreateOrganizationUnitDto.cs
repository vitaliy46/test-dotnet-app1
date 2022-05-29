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
    public class CreateOrganizationUnitDto : IShouldNormalize
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
        public CreatePersonDto Header { get; set; }

        public CreateOrganizationUnitAddressDto OrganizationUnitAddress { get; set; }

        public CreateAccountingDetailsDto AccountingDetails { get; set; }

        public void Normalize()
        {
        }
    }
}
