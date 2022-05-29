using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Abp.Application.Services.Dto;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Runtime.Session;
using Kis.Crypto.Api;
using Kis.Crypto.Api.Services;
using Kis.Crypto.Services.Bl;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Moq;


namespace Kis.Voting.Tests
{
    /// <summary>
    /// модульные тесты для метода посдчета процента проголосовавших GetVotedPercent класса VotingApplicationService.cs 
    /// 1 тест результат голосования должен быть 80%
    /// </summary>
    [TestClass]
    public class DefaultCryptoProviderTests
    {
        private static readonly IConfiguration Configuration = IocManager.Instance.IocContainer.Resolve<IConfiguration>();
        readonly ICryptoProvider _cryptoProvider = new DefaultCryptoProvider(Configuration);

        /// <summary>
        /// Интеграционный тест наобращение к DSS для подписания документа электронной подписью.
        /// </summary>
        [TestMethod]
        public void SingXml_Successful()
        {
            //Подготовка данных
            var xDocument = new XDocument();

            xDocument.Add(new XElement("Xml", new XElement("Text", "Какой либо текст.")));

            var signerInfo = new SignerInfo
            {
                Contact = "8 908 947 8948",
                ContactType = 3, // Telegram
                Name = "Евгений федорович"
            };
            //Тестирование

            var signedDocument = _cryptoProvider.SingXml(xDocument.ToString(), signerInfo).Result;

            xDocument = XDocument.Parse(signedDocument);

            //проверка  результатов теста
            Assert.IsNotNull(xDocument.Descendants().FirstOrDefault(p => p.Name.LocalName == "Signature"));
        }
    }

    
}
