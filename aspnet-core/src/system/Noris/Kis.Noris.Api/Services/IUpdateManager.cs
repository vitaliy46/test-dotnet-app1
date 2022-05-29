using System;
using System.Collections.Generic;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    public interface IUpdateManager
    {
        /// <summary>
        /// Регистрирует переданный провайдер обновлений в менеджере. На каждый тип
        /// справочника может быть зарегистрирован только один провайдер.
        /// Регистрация второго с тем же типом заменяет регистрацию первого.
        /// </summary>
        /// <typeparam name="T">Тип записи справочника, связанный с провайдером</typeparam>
        /// <param name="provider">Объект регистрируемого провайдера</param>
        /// <exception cref="ArgumentNullException"><paramref name="provider"/> is <see langword="null" />.</exception>
        void AddUpdateProvider<T>(IUpdateProvider<T> provider)
            where T : ReferenceEntity;

        /// <summary>
        /// Отменяет регистрацию переданного провайдера в менеджере.
        /// </summary>
        /// <typeparam name="T">Тип записи справочника, связанный с провайдером</typeparam>
        /// <param name="provider">Объект отменяемого провайдера</param>
        void RemoveUpdateProvider<T>(IUpdateProvider<T> provider)
            where T : ReferenceEntity;

        /// <summary>
        /// Возвращает список всех провайдеров, зарегистрированных в менеджере
        /// </summary>
        /// <typeparam name="T">Тип записи справочника, связанный с провайдером</typeparam>
        /// <returns>Список объектов провайдеров, или пустой список</returns>
        IReadOnlyCollection<object> GetUpdateProviders();

        /// <summary>
        /// Выполняет обновление указанного справочника на основе данных доступных 
        /// обновлений в соответственном провайдере. Справочник обновляется по 
        /// наиболее актуальной из доступных релизов в порядке возростания даты релиза.
        /// Релизы, которые уже имеются в справочнике, повторно не применяются, также как
        /// и пропущенные релизы.
        /// </summary>
        /// <typeparam name="T">Тип записи справочника, связанный с провайдером</typeparam>
        /// <param name="referenceBook">Объект обновляемого справочника</param>
        /// <exception cref="ReferenceException">Ошибка при обновлении справочника</exception>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        void UpdateReferenceBook<T>(IReferenceBook<T> referenceBook)
            where T : ReferenceEntity;

        /// <summary>
        /// Метод с помощью рефлексии вызывает метод UpdateReferenceBook<T>
        /// </summary>
        /// <param name="referenceBook">Объект IReferenceBook для вызова метода</param>
        void InvokeUpdateReferenceBookRef(IReferenceBook referenceBook);

        /// <summary>
        /// Возвращает провайдер, зарегистрированный в менеджере и связанный с указанным типом записи справочника
        /// </summary>
        /// <typeparam name="T">Тип записи справочника, связанный с провайдером</typeparam>
        IUpdateProvider<T> GetProvider<T>() where T : ReferenceEntity;
    }
}