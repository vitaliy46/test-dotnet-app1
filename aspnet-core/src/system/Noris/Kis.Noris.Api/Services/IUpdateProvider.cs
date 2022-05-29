using System.Collections.Generic;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// »нтерфейс провайдеров обновлений, в задачи которых 
    /// входит предоставл€ть доступные пакеты обновлений
    /// дл€ справочников с определЄнным типом записей
    /// ѕровайдеры используютс€ менеджером обновлений дл€ 
    /// выполнени€ процесса обновлени€ справочников
    /// </summary>
    /// <typeparam name="T">“ип записи справочника, дл€ которого провайдер предоставл€ет обновлени€</typeparam>
    public interface IUpdateProvider<T> 
        where T: ReferenceEntity
    {
        /// <summary>
        /// ¬озвращает список описаний доступных обновлений
        /// </summary>
        /// <returns>Ќабор описаний обновлений</returns>
        IEnumerable<UpdateInfo> GetAvailableUpdates();

        /// <summary>
        /// ¬озвращает пакет обновлени€ по переданному описанию обновлени€
        /// </summary>
        /// <param name="updateInfo">ќбъект, описывающий конкретное обновление</param>
        /// <returns>ѕакет с данными обновлени€</returns>
        UpdatePackage<T> GetUpdate(UpdateInfo updateInfo);
    }
}