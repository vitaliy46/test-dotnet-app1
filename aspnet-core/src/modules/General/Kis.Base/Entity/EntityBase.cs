using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Kis.Base.Entity
{
    /// <summary>
    /// Базовый класс для сущностей модели данных в системе
    /// Вводит уникальный идентификатор записи, а также данные о дате создания,
    /// изменения и удаления сущности и субъектах этих операций
    /// </summary>
    /// <typeparam name="TId">Тип уникального идентификатора записи</typeparam>
    public abstract class EntityBase<TId> : FullAuditedEntity<TId>, IEntity<TId> 
    {
    }
}