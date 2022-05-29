namespace Kis.Noris.Api.Constants
{
    /// <summary>
    /// �������� ��������, ����������� ��� ������� � ��������� ���������� �����������
    /// </summary>
    public enum UpdateOperation
    {
        /// <summary>
        /// ������ �� ����������
        /// </summary>
        NoChange = 0,
        /// <summary>
        /// ������ ���� ���������
        /// </summary>
        Addition = 1,
        /// <summary>
        /// ������ ���� ��������
        /// </summary>
        Modification = 2,
        /// <summary>
        /// ������ ���� �������
        /// </summary>
        Removal = 3,
        /// <summary>
        /// �������� �� ���������� � ������������ � �������� ���������� �����������
        /// ������������ ������� ����������� ������
        /// </summary>
        Auto = -1
    }
}