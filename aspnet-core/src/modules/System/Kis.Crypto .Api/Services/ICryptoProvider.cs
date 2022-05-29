using System.Threading.Tasks;
using System.Xml.Linq;
using Abp.Application.Services;

namespace Kis.Crypto.Api.Services
{
    /// <summary>
    /// Предоставляет возможность подписания документов
    /// средствами вынесенного функционала для криптозащиты.
    /// Может быть несколько реализаций для подключения к различным 
    /// инструментам криптозащиты
    /// </summary>

    public interface ICryptoProvider : IApplicationService
    {
        /// <summary>
        /// Подписывается документ в Xml формате
        /// </summary>
        /// <param name="document">документ на подпись</param>
        /// <param name="signerInfo"></param>
        /// <returns></returns>
        Task<string> SingXml(string document, SignerInfo signerInfo);

        /// <summary>
        /// Подписывается документ в Pdf формате
        /// </summary>
        /// <param name="document">документ на подпись</param>
        /// <param name="signerInfo"></param>
        /// <returns></returns>
        Task<PdfFile> SingPdf(string document, SignerInfo signerInfo);
    }
}
