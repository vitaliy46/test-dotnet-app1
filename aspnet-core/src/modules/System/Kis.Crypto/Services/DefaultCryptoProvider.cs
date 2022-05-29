using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;
using Abp.Application.Services;
using JetBrains.Annotations;
using Kis.Crypto.Api;
using Kis.Crypto.Api.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Kis.Crypto.Services.Bl
{
    public class DefaultCryptoProvider : ApplicationService, ICryptoProvider

    {
        private string _baseUrl = "";
        string _resource = Path.Combine("api", "sign", "Xml");
        string _signPdfResource = Path.Combine("api", "sign", "Pdf");

        private readonly IConfiguration _configuration;

        public DefaultCryptoProvider([NotNull] IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _baseUrl = _configuration.GetValue<string>("App:DssAddress");
        }

        /// <summary>
        /// Обращается по rest api  на dss за подписью документа в Xml формате
        /// </summary>
        /// <param name="xmlDocument">документ на подпись</param>
        /// <param name="signerInfo"></param>
        /// <returns></returns>
        public Task<string> SingXml(string xmlDocument, SignerInfo signerInfo)
        {
            
            var client = new RestClient(_baseUrl);
            
            var request = new RestRequest(_resource, Method.POST, DataFormat.Json);

            var viewModel = new SingXmlModelView
            {
                XmlData = xmlDocument,
                SignerName = signerInfo.Name,
                Contact =  signerInfo.Contact,
                ContactType =  signerInfo.ContactType
            };

            request.AddJsonBody(viewModel);
           
            //Action
            IRestResponse response = client.Execute(request);

            if (response.Content != "")
            {
                var responseContent = JsonConvert.DeserializeObject<ResponseContent<string>>(response.Content);

                if (responseContent.success)
                {
                    xmlDocument = responseContent.result;
                }
            }

            return Task.FromResult(xmlDocument);
        }

        public class SingXmlModelView
        {
            public string XmlData { get; set; }

            public string SignerName { get; set; }

            public string Contact { get; set; }

            public int ContactType { get; set; }
        }

        /// <summary>
        /// Обращается по rest api  на dss за подписью документа в Pdf формате
        /// </summary>
        /// <param name="fileName">Имя документа на подпись в папке Temp в WebHost</param>
        /// <param name="signerInfo"></param>
        /// <returns></returns>
        public Task<PdfFile> SingPdf(string fileName, SignerInfo signerInfo)
        {
            PdfFile pdfFile = null;

            var client = new RestClient(_baseUrl);

            var request = new RestRequest(_signPdfResource, Method.POST, DataFormat.Json);

            string filepath = Path.Combine(Path.GetFullPath("./Temp"), fileName);
            byte[] fileData = File.ReadAllBytes(filepath);
            string base64String = Convert.ToBase64String(fileData);

            var viewModel = new SingPdfModelView
            {
                PdfFileName = fileName,
                PdfData = base64String,
                SignerName = signerInfo.Name,
                Contact = signerInfo.Contact,
                ContactType = signerInfo.ContactType
            };

            request.AddJsonBody(viewModel);

            //Action
            IRestResponse response = client.Execute(request);

            if (response.Content != "")
            {
                var responseContent = JsonConvert.DeserializeObject<ResponseContent<string>>(response.Content);

                if (responseContent.success)
                {
                    pdfFile = JsonConvert.DeserializeObject<PdfFile>(responseContent.result);
                }
            }

            return Task.FromResult(pdfFile);
        }

        public class SingPdfModelView
        {
            /// <summary>
            /// Имя файла для хранения в файловой системе
            /// </summary>
            public string PdfFileName { get; set; }

            /// <summary>
            /// Данные в Pdf формате, котрые нужно подписать
            /// для передачи в формате json массив byte[] конвертируем в строку Base64String
            /// </summary>
            public string PdfData { get; set; }

            /// <summary>
            /// Персона, которая запросила подпись данных.
            /// Имя нужно для отправки обращения
            /// </summary>
            public string SignerName { get; set; }

            /// <summary>
            /// Контакт, на который нужно отправлять запрос 
            /// одноразового пароля для подтверждения
            /// </summary>
            public string Contact { get; set; }

            /// <summary>
            /// Тип контакта, для выбора соответсвующего провайдера
            /// чтобы отправить уведомления (sms, telegram, email)
            /// </summary>
            public int ContactType { get; set; }
        }

        class ResponseContent<TDto>
        {
            public TDto result { get; set; }
            public object targetUrl { get; set; }
            public bool success { get; set; }
            public object error { get; set; }
            public bool unAuthorizedRequest { get; set; }
            public bool __abp { get; set; }

        }
    }
}
