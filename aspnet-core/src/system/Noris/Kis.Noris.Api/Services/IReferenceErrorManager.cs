using System;
using System.Collections.Generic;
using Kis.Noris.Api.Constants;
using Kis.Noris.Api.Dpo;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Filters;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// Интерфейс управления ошибками, котрый основан на базовых интерфейсах crud операций
    /// расширяемый до операций бизнес-логики. Такое совмещение позволительно в связи с
    /// не очень сложной бизнес-логикой.
    /// </summary>
    public interface IReferenceErrorManager : IGetSingleSupport<ReferenceError>, IGetListSupport<ReferenceError>,
                                              ICreateSupport<ReferenceError>, IUpdateSupport<ReferenceError>
    {
        /// <summary>
        /// Добавление комментария к ошибке
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        ReferenceErrorDetailDpo AddComment(Guid id, string comment);

        /// <summary>
        /// Изменение состояния ошибки. В последствии может потребоваться отслеживать переходы
        /// между состояниями. Тогда потребуются специализированные методы перевода ошибки 
        /// из одного состояния в другое
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        ReferenceErrorDetailDpo ChangeState(Guid id, ReferenceErrorStates state);

        /// <summary>
        /// Чтение списка ошибок для отображения их на UI. Все параметры могут быть использованы для формирования фильтра.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IList<ReferenceErrorDpo> ReadErrors(ReferenceErrorFilter filter);

        /// <summary>
        /// Возвращает список ошибок с детальной информацией относительно ее
        /// </summary>
        /// <param name="filter"></param>
        IList<ReferenceErrorDetailDpo> ReadDetailErrors(ReferenceErrorFilter filter);
        /// <summary>
        /// Чтение ошибки для для детального просмотра ее содержимого на UI
        /// </summary>
        /// <returns></returns>
        ReferenceErrorDetailDpo ReadError(Guid id);

        /// <summary>
        /// Метод, выполняющий проверку определенной ошибки указанного типа на ее исправление
        /// </summary>
        /// <param name="errorType">Тип ошибки</param>
        /// <param name="id">ID ошибки</param>
        /// <returns>true - если ошибка исправлена, false - если ошибка не исправлена</returns>
        bool CheckErrorCorrection(ReferenceErrors errorType, Guid id);

        /// <summary>
        /// Возвращает ошибку указанного типа с указанным идентификатором
        /// </summary>
        /// <param name="identifier">Идентификатор ошибки</param>
        /// <param name="errorType">Тип ошибки</param>
        ReferenceErrorDpo FindError(string identifier, ReferenceErrors errorType);
    }
}
