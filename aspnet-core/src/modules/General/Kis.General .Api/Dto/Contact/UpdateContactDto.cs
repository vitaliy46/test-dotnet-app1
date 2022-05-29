using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// ���������� ����������: �������/e-mail/Skype/ ��.
    /// </summary>
    public class UpdateContactDto : BaseDto<Guid> 
    {
        public string Value { get; set; }

    }
}