using System;
using System.Collections.Generic;
using System.Linq;
using Kis.Noris.Api.Constants;

namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// Пакет-обновление справочника, содержит изменения записей
    /// справочника одной версии справочника относительно другой
    /// более ранней
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class UpdatePackage<T>
        where T : ReferenceEntity
    {
        // Список элементов обновления
        [NonSerialized]
        private readonly List<UpdatePackageItem<T>> _records = new List<UpdatePackageItem<T>>(); 
        public virtual IList<UpdatePackageItem<T>> Records {
            get { return _records; }
        }

        public UpdatePackage(DateTime? releaseDateFrom, DateTime releaseDateTo)
        {
            ReleaseDateFrom = releaseDateFrom != null 
                ? releaseDateFrom.Value : (DateTime?) null;

            ReleaseDateTo = releaseDateTo;
        }

        /// <summary>
        /// Дата релиза, с которой выполняется данное обновление
        /// </summary>
        public virtual DateTime? ReleaseDateFrom { get; private set; }

        /// <summary>
        /// Дата релиза, на которую выполняется данное обновление
        /// </summary>
        public virtual DateTime ReleaseDateTo { get; private set; }

        /// <summary>
        /// Возвращает список элементов обновлений с заданной операцией обновления
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public IEnumerable<UpdatePackageItem<T>> FindByOperation(UpdateOperation operation)
        {
            return Records.Where(o => o.Operation == operation);
        }
    }
}
