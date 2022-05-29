using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.Users.Dto;

namespace Kis.Investors.Api.Dto
{
    /// <summary>
    /// Представитель члена товарищества, с которым осуществляется контакт
    /// </summary>
    public class CreateMemberContactorDto : IShouldNormalize
    {
        public CreatePersonDto Person { get; set; }

        public CreatePersonContactDto PersonContact { get; set; }
        

        public void Normalize()
        {
        }
    }
}
