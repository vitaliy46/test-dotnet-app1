using System;
using Kis.Base.Entity;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// ���������� ����������: �������/e-mail/Skype/ ��.
    /// </summary>
    public class Contact : EntityBase<Guid>
    {
        /// <summary>
        /// ��� �������. ��������  adam@gmail.com ���� � �������� ���� ������ ��. �����
        /// </summary>
        public string Value { get; set; }
        
        public ContactTypes ContactType { get; set; }
   
    }
}