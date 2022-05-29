using System;

namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// Объект описания обновления, содержащегося в провайдере обновлений
    /// </summary>
    public class UpdateInfo
    {
        public UpdateInfo(Type referenceDataType, DateTime releaseDate)
        {
            ReferenceDataType = referenceDataType;
            ReleaseDate = releaseDate;
        }

        /// <summary>
        /// Тип записи справочника, который поддерживается данным обновлением
        /// </summary>
        public Type ReferenceDataType { get; private set; }
        /// <summary>
        /// Дата выпуска обновления
        /// </summary>
        public DateTime ReleaseDate { get; private set; }
    }
}