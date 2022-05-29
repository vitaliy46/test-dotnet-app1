
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// Инструмент для работы с комментариями к ошибке
    /// </summary>
    public interface ICommentManager
    {
        /// <summary>
        /// Добавляется один комментарий к сделанным ранее
        ///  </summary>
        /// <param name="error">Ошибка в которую нужно добавить коммент</param>
        /// <param name="comment"></param>
        /// <returns></returns>
        void Add(ReferenceError error, string comment);

        /// <summary>
        /// Представление комментария в удобочитаемом формате
        /// </summary>
        /// <param name="error">Ошибка из которой нужно извлеч комментраии в Xml формате и представить их в удобочитаемом виде</param>
        /// <returns>Возвращает комментарии хранящийся в ошибке в форматированном виде, удобном для чтения</returns>
        string ReadAll(ReferenceError error);
    }
}
