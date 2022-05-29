using Kis.Noris.Api.Constants;

namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// ������� ������ ���������� �����������. �������� � ���� 
    /// ������ ����������� � ��������, ������� ���� ��� ��� ���������
    /// � ��������� ����������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UpdatePackageItem<T> where T : ReferenceEntity
    {       
        public UpdatePackageItem(T record, UpdateOperation operation)
        {
            Operation = operation;
            Record = record;
        }

        /// <summary>
        /// ������ �����������, ����������� � ������ ����������
        /// </summary>
        public T Record { get; private set; }

        /// <summary>
        /// �������� (����������, ���������, ��������, ��.), ��������������� � 
        /// ������ ������� ����������
        /// </summary>
        public UpdateOperation Operation { get; private set; }
    }
}