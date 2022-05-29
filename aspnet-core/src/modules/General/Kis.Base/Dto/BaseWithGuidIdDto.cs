using System;
using Abp.Application.Services.Dto;

namespace Kis.Base.Dto
{
    /// <summary>
    /// Базовый класс для посредническиой инфраструктуры между entity и различными представлениями
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class BaseWithGuidIdDto : BaseDto<Guid?>
    {
    }
}
