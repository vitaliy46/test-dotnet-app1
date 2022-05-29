using System;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// Описывает способы фиксирования ошибок, организует их накопление
    /// и управление ими в процессе обработки и отслеживания
    /// </summary>
    public interface IReferenceErrorQualifier
    {
        /// <summary>
        /// Фиксирование  ошибки обнаруженной в процессе поиска записи в справочнике по коду
        /// </summary>
        ReferenceError CodeEmptyError(IReferenceBook referenceBook, string[] recordCode, string fullDescription = "");

        /// <summary>
        /// Фиксирование  ошибки обнаруженной в процессе перекодировки записи в справочнике
        /// </summary>
        ReferenceError TranscodeEmptyError(IReferenceBook referenceBook, string[] recordCode,
            IReferenceBook masterReferenceBook, string fullDescription = "");

        /// <summary>
        /// Фиксирование ошибки обнаруженной в процессе  загрузки обновлений справочника
        /// Если потребуется выгрузка дополнительной информации об ошибке
        /// </summary>
        ReferenceError UpdateReferenceError(IReferenceBook referenceBook, Exception ex);

        /// <summary>
        /// Фиксирование ошибки, обнаруженной в процессе попытки обновления справочника и связанной
        /// с изменением структуры справочника
        /// </summary>
        ReferenceError ChangeReferenceBookStructureError(IReferenceBook referenceBook, Exception ex);
    }
}
