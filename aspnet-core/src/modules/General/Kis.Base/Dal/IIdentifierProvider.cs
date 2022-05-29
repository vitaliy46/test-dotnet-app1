using System.Collections.Generic;

namespace Kis.Base.Dao
{
    /// <summary>
    /// Интерфейс провайдера идентификаторов сущностей.
    /// При реализации выполняет создание уникального идентификатора, который
    /// гарантированно не повторяется при генерации одним и тем же провайдером.
    /// </summary>
    /// <typeparam name="TId">Тип идентификатора</typeparam>
    public interface IIdentifierProvider<out TId>
        where TId : struct
    {
        /// <summary>
        /// Создаёт новый идентификатор
        /// </summary>
        /// <returns>Идентификатор</returns>
        TId NewIdentifier();

        /// <summary>
        /// Создаёт набор из указанного количества идентификаторов
        /// </summary>
        /// <returns>Набор идентификаторов</returns>
        IEnumerable<TId> NewIdentifiers(int count);
    }
}
