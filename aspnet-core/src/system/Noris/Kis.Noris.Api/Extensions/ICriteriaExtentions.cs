using System;
using Kis.Noris.Api.Criterias;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Extensions
{
    /// <summary>
    /// TODO прокомменитровать класс - обобщить назначение его методов
    ///  </summary>
    public static class ICriteriaExtentions
    {
        #region  Набор универсальных критериев пригодных для большинства справочников
        /// <summary>
        /// TODO прокомментировать каждый критерий
        /// </summary>
        
        #endregion

        /// <summary>
        /// Выбрать по заданному идентификатору записи
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> ByRecordId<T>(this ICriteria<T> criteria, Guid recordId) 
            where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new ByRecordIdCriteria(recordId));
        }

        /// <summary>
        /// Выбрать по заданному набору идентификаторов записей
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> ByRecordIds<T>(this ICriteria<T> criteria, params Guid[] recordIds)
            where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new ByRecordIdsCriteria(recordIds));
        }

        /// <summary>
        /// Выбрать по заданному идентификатору версии записи
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> ByVersionId<T>(this ICriteria<T> criteria, Guid versionId) 
            where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new ByVersionIdCriteria(versionId));
        }

        /// <summary>
        /// Выбрать по заданному набору идентификаторов версий записей
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> ByVersionIds<T>(this ICriteria<T> criteria, params Guid[] versionIds)
            where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new ByVersionIdsCriteria(versionIds));
        }

        /// <summary>
        /// Выбрать по заданному коду записи
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> ByCode<T>(this ICriteria<T> criteria, string code) 
            where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new ByCodeCriteria(code));
        }

        /// <summary>
        /// Выбрать по заданному составному коду записи
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> ByCode<T>(this ICriteria<T> criteria, params string[] codes) 
            where T:ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new ByCodeCriteria(ReferenceEntity.MergeCodes(codes)));
        }

        /// <summary>
        /// Выбрать по заданному набору кодов записей
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> ByCodes<T>(this ICriteria<T> criteria, params string[] codes)
            where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new ByCodesCriteria(codes));
        }

        /// <summary>
        /// Выбрать только из актуального справочника (последней имеющейся версии)
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> InActual<T>(this ICriteria<T> criteria) where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new InActualCriteria());
        }

        /// <summary>
        /// Выбрать только из справочника указанной даты релиза
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> InRelease<T>(this ICriteria<T> criteria, DateTime releaseDate) where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new InReleaseCriteria(releaseDate));
        }

        /// <summary>
        /// Выбрать включая удалённые версии записей
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public static ICriteria<T> WithDeleted<T>(this ICriteria<T> criteria) where T : ReferenceEntity
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return Criteria.And(criteria, new WithDeletedCriteria());
        }
    }
}