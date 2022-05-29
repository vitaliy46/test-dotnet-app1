using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// ���������� ����������: �������/e-mail/Skype/ ��.
    /// </summary>
    public class CreateContactDto : IShouldNormalize
    {
        public string Value { get; set; }

        public ContactTypes ContactType { get; set; }

        public void Normalize()
        {
        }
    }
}