using System;
using System.Collections.Generic;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    public interface IUpdateManager
    {
        /// <summary>
        /// ������������ ���������� ��������� ���������� � ���������. �� ������ ���
        /// ����������� ����� ���� ��������������� ������ ���� ���������.
        /// ����������� ������� � ��� �� ����� �������� ����������� �������.
        /// </summary>
        /// <typeparam name="T">��� ������ �����������, ��������� � �����������</typeparam>
        /// <param name="provider">������ ��������������� ����������</param>
        /// <exception cref="ArgumentNullException"><paramref name="provider"/> is <see langword="null" />.</exception>
        void AddUpdateProvider<T>(IUpdateProvider<T> provider)
            where T : ReferenceEntity;

        /// <summary>
        /// �������� ����������� ����������� ���������� � ���������.
        /// </summary>
        /// <typeparam name="T">��� ������ �����������, ��������� � �����������</typeparam>
        /// <param name="provider">������ ����������� ����������</param>
        void RemoveUpdateProvider<T>(IUpdateProvider<T> provider)
            where T : ReferenceEntity;

        /// <summary>
        /// ���������� ������ ���� �����������, ������������������ � ���������
        /// </summary>
        /// <typeparam name="T">��� ������ �����������, ��������� � �����������</typeparam>
        /// <returns>������ �������� �����������, ��� ������ ������</returns>
        IReadOnlyCollection<object> GetUpdateProviders();

        /// <summary>
        /// ��������� ���������� ���������� ����������� �� ������ ������ ��������� 
        /// ���������� � ��������������� ����������. ���������� ����������� �� 
        /// �������� ���������� �� ��������� ������� � ������� ����������� ���� ������.
        /// ������, ������� ��� ������� � �����������, �������� �� �����������, ����� ���
        /// � ����������� ������.
        /// </summary>
        /// <typeparam name="T">��� ������ �����������, ��������� � �����������</typeparam>
        /// <param name="referenceBook">������ ������������ �����������</param>
        /// <exception cref="ReferenceException">������ ��� ���������� �����������</exception>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        void UpdateReferenceBook<T>(IReferenceBook<T> referenceBook)
            where T : ReferenceEntity;

        /// <summary>
        /// ����� � ������� ��������� �������� ����� UpdateReferenceBook<T>
        /// </summary>
        /// <param name="referenceBook">������ IReferenceBook ��� ������ ������</param>
        void InvokeUpdateReferenceBookRef(IReferenceBook referenceBook);

        /// <summary>
        /// ���������� ���������, ������������������ � ��������� � ��������� � ��������� ����� ������ �����������
        /// </summary>
        /// <typeparam name="T">��� ������ �����������, ��������� � �����������</typeparam>
        IUpdateProvider<T> GetProvider<T>() where T : ReferenceEntity;
    }
}