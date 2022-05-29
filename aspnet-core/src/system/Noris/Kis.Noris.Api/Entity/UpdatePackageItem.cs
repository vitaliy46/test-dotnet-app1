using Kis.Noris.Api.Constants;

namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// Элемент пакета обновления справочника. Содержит в себе 
    /// запись справочника и операцию, которая была над ней выполнена
    /// в контексте обновления
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UpdatePackageItem<T> where T : ReferenceEntity
    {       
        public UpdatePackageItem(T record, UpdateOperation operation)
        {
            Operation = operation;
            Record = record;
        }

        /// <summary>
        /// Запись справочника, участвующая в пакете обновления
        /// </summary>
        public T Record { get; private set; }

        /// <summary>
        /// Действие (добавление, изменение, удаление, др.), ассоциированное с 
        /// данной записью обновления
        /// </summary>
        public UpdateOperation Operation { get; private set; }
    }
}