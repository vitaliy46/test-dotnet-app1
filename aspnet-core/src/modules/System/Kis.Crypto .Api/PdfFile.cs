using System;
using System.Collections.Generic;
using System.Text;

namespace Kis.Crypto.Api
{
    /// <summary>
    /// Класс для получения подписанных данных
    /// </summary>
    public class PdfFile
    {
        /// <summary>
        /// Имя файла для хранения в файловой системе
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Данные в Pdf формате, котрые нужно подписать
        /// для передачи в формате json массив byte[] конвертируем в строку Base64String
        /// </summary>
        public string Data { get; set; }
    }
}
