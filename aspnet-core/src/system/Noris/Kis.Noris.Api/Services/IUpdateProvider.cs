using System.Collections.Generic;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// ��������� ����������� ����������, � ������ ������� 
    /// ������ ������������� ��������� ������ ����������
    /// ��� ������������ � ����������� ����� �������
    /// ���������� ������������ ���������� ���������� ��� 
    /// ���������� �������� ���������� ������������
    /// </summary>
    /// <typeparam name="T">��� ������ �����������, ��� �������� ��������� ������������� ����������</typeparam>
    public interface IUpdateProvider<T> 
        where T: ReferenceEntity
    {
        /// <summary>
        /// ���������� ������ �������� ��������� ����������
        /// </summary>
        /// <returns>����� �������� ����������</returns>
        IEnumerable<UpdateInfo> GetAvailableUpdates();

        /// <summary>
        /// ���������� ����� ���������� �� ����������� �������� ����������
        /// </summary>
        /// <param name="updateInfo">������, ����������� ���������� ����������</param>
        /// <returns>����� � ������� ����������</returns>
        UpdatePackage<T> GetUpdate(UpdateInfo updateInfo);
    }
}