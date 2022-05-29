using System;
using Kis.Base.Dto;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// ���������� ����������: �������/e-mail/Skype/ ��.
    /// </summary>
    public class ContactDto : BaseDto<Guid>
    {
        public string Value { get; set; }

        public ContactTypes ContactType { get; set; }
    }
}