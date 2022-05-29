using System;

namespace Kis.Noris.Api.Services
{
    public interface IReferenceBookFactory
    {
        /// <summary>
        /// Регистрируется соответствие типа справочного свойства dto модели справочнику
        /// </summary>
        bool RegisterReference(Type dtoPropertyType, Type referenceRecordType);

        /// <summary>
        /// Выбор соответствия типа справочного свойства в dto какому либо справочнику.
        /// Это может быть, как локальный, так и мастер-справочник
        /// В общем случае выбор локального справочника зависит и от типа МИС.
        /// Но пока данные принимаются только из систем КОМИАЦ, то указание на тип не используется.
        /// </summary>
        /// <param name="referencePropertyDtoType">тип справочного свойства в dto объекте</param>
        /// <param name="infomationSystemType">тип информационной системы, из которой приходят данные кодов</param>
        /// <returns></returns>
        IReferenceBook GetReferenceBook(Type referencePropertyDtoType, string infomationSystemType);
        /// <summary>
        /// По типу записи-мастер справочника возвращается сам мастер-справочник
        /// </summary>
        /// <param name="referencePropertyType"></param>
        /// <returns></returns>
        IReferenceBook GetMasterReferenceBook(Type referencePropertyType);
        Type GetReferenceType(Type dtoType);
    }
}