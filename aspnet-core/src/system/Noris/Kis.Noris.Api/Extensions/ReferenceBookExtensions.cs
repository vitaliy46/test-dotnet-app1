using System;
using System.Collections.Generic;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Extensions
{
    public static class ReferenceBookExtensions
    {
        /// <summary>
        /// Возвращает запись из справочника по её идентификатору из справочника 
        /// актуального релиза
        /// </summary>
        /// <typeparam name="TRefData">Тип записи справочника</typeparam>
        /// <param name="referenceBook">Объект справочника, из которого запрашиваются данные</param>
        /// <param name="recordId">Ид записи в справочнике</param>
        /// <returns>Объект записи справочника актуальной версии или null, если записи с таким <paramref name="recordId"/> не удалось найти</returns>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Данный тип запроса не поддерживается экземпляром <see cref="ReferenceBookBase{TReferenceEntity,TDataContext}"/></exception>
        public static TRefData Get<TRefData>(this IReferenceBook<TRefData> referenceBook, Guid recordId)
            where TRefData : ReferenceEntity
        {
            if (referenceBook == null) throw new ArgumentNullException(nameof(referenceBook));

            return referenceBook.QueryRecord(Criteria.For<TRefData>().InActual().ByRecordId(recordId));
        }

        /// <summary>
        /// Возвращает запись из актуальной версии справочника по её коду
        /// </summary>
        /// <typeparam name="TRefData">Тип записи справочника</typeparam>
        /// <param name="referenceBook">Объект справочника, из которого запрашиваются данные</param>
        /// <param name="code">Код записи в справочнике</param>
        /// <returns>Объект записи справочника актуальной версии или null, если записи с таким <paramref name="recordId"/> не удалось найти</returns>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Данный тип запроса не поддерживается экземпляром <see cref="ReferenceBookBase{TReferenceEntity,TDataContext}"/></exception>
        public static TRefData Get<TRefData>(this IReferenceBook<TRefData> referenceBook, string code)
            where TRefData : ReferenceEntity
        {
            if (referenceBook == null) throw new ArgumentNullException(nameof(referenceBook));

            return referenceBook.QueryRecord(Criteria.For<TRefData>().InActual().ByCode(code));
        }

        /// <summary>
        /// Возвращает запись из актуальной версии справочника по её составному коду
        /// </summary>
        /// <typeparam name="TRefData">Тип записи справочника</typeparam>
        /// <param name="referenceBook">Объект справочника, из которого запрашиваются данные</param>
        /// <param name="code">Составной код записи в справочнике</param>
        /// <returns>Объект записи справочника актуальной версии или null, если записи с таким <paramref name="recordId"/> не удалось найти</returns>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Данный тип запроса не поддерживается экземпляром <see cref="ReferenceBookBase{TReferenceEntity,TDataContext}"/></exception>
        public static TRefData Get<TRefData>(this IReferenceBook<TRefData> referenceBook, params string[] code)
            where TRefData : ReferenceEntity
        {
            if (referenceBook == null) throw new ArgumentNullException(nameof(referenceBook));

            return referenceBook.QueryRecord(Criteria.For<TRefData>().InActual().ByCode(code));
        }


        /// <summary>
        /// Возвращает запись из справочника по её идентификатору из справочника с
        /// указанной датой релиза
        /// </summary>
        /// <typeparam name="TRefData">Тип записи справочника</typeparam>
        /// <param name="referenceBook">Объект справочника, из которого запрашиваются данные</param>
        /// <param name="recordId">Ид записи в справочнике</param>
        /// <param name="releaseDate">Дата выпуска релиза справочника (версия справочника)</param>
        /// <returns>Объект записи справочника заданной версии или null, если записи с таким <paramref name="recordId"/> не удалось найти</returns>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Данный тип запроса не поддерживается экземпляром <see cref="ReferenceBookBase{TReferenceEntity,TDataContext}"/></exception>
        public static TRefData Get<TRefData>(this IReferenceBook<TRefData> referenceBook, Guid recordId, DateTime releaseDate)
            where TRefData : ReferenceEntity 
        {
            if (referenceBook == null) throw new ArgumentNullException(nameof(referenceBook));

            return referenceBook.QueryRecord(Criteria.For<TRefData>().InRelease(releaseDate).ByRecordId(recordId));
        }

        /// <summary>
        /// Возвращает все записи из справочника актуального релиза
        /// </summary>
        /// <typeparam name="TRefData">Тип записи справочника</typeparam>
        /// <param name="referenceBook">Объект справочника, из которого запрашиваются данные</param>
        /// <returns>Набор объектов записей актуального справочника</returns>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Данный тип запроса не поддерживается экземпляром <see cref="ReferenceBookBase{TReferenceEntity,TDataContext}"/></exception>
        public static IEnumerable<TRefData> Get<TRefData>(this IReferenceBook<TRefData> referenceBook)
            where TRefData : ReferenceEntity
        {
            if (referenceBook == null) throw new ArgumentNullException(nameof(referenceBook));

            return referenceBook.QueryRecords(Criteria.For<TRefData>().InActual());
        }

        /// <summary>
        /// Возвращает все записи из справочника с указанной датой релиза
        /// </summary>
        /// <typeparam name="TRefData">Тип записи справочника</typeparam>
        /// <param name="referenceBook">Объект справочника, из которого запрашиваются данные</param>
        /// <param name="releaseDate">Дата выпуска релиза справочника (версия справочника)</param>
        /// <returns>Набор объектов записей справочника заданной версии</returns>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Данный тип запроса не поддерживается экземпляром <see cref="ReferenceBookBase{TReferenceEntity,TDataContext}"/></exception>
        public static IEnumerable<TRefData> Get<TRefData>(this IReferenceBook<TRefData> referenceBook, DateTime releaseDate)
            where TRefData : ReferenceEntity
        {
            if (referenceBook == null) throw new ArgumentNullException(nameof(referenceBook));

            return referenceBook.QueryRecords(Criteria.For<TRefData>().InRelease(releaseDate));
        }

        /// <summary>
        /// Возвращает все версии одной записи по её идентификатору, от изначально добавленной версии до последней актуальной или удалённой (если она имеется)
        /// </summary>
        /// <typeparam name="TRefData">Тип записи справочника</typeparam>
        /// <param name="referenceBook">Объект справочника, из которого запрашиваются данные</param>
        /// <param name="recordId">Ид записи в справочнике</param>
        /// <returns>Объекты всех версий записи справочника или пустой список, если записи с таким <paramref name="recordId"/> не удалось найти</returns>
        /// <exception cref="ArgumentNullException"><paramref name="referenceBook"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Данный тип запроса не поддерживается экземпляром <see cref="ReferenceBookBase{TReferenceEntity,TDataContext}"/></exception>
        public static IEnumerable<TRefData> GetRecordHistory<TRefData>(this IReferenceBook<TRefData> referenceBook,
            Guid recordId) where TRefData : ReferenceEntity
        {
            if (referenceBook == null) throw new ArgumentNullException(nameof(referenceBook));

            return referenceBook.QueryRecords(Criteria.For<TRefData>().ByRecordId(recordId).WithDeleted());
        }
    }
}
