using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Configuration;
using Abp.Extensions;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Session;
using JetBrains.Annotations;
using Kis.General.Api.Services.Messenger;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace Kis.General.Services.Messenger.DeliveryProviders
{
    public class MailMessageDeliveryProvider : ApplicationService, IMessageDeliveryProvider
    {
        private static string _mail; // System.Configuration.ConfigurationManager.AppSettings["Email"];
        private static string _pass; //System.Configuration.ConfigurationManager.AppSettings["Sifre"];

        private readonly IAbpSession _session;
        private readonly IConfiguration _configuration;

        public MailMessageDeliveryProvider([NotNull] IAbpSession session, [NotNull] IConfiguration configuration)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Send(Message message)
        {
            _mail = _configuration.GetValue<string>("App:Mail");
            _pass = _configuration.GetValue<string>("App:Sifre");

            if (_mail.IsNullOrEmpty() || _pass.IsNullOrEmpty())
            {
                throw new Exception("Учетная запись для отправки уведомлений не определена");
            }

            if (_session.TenantId == null)
            {
                //throw new Exception("Незарегистрированный пользователь пытается отправить уведомления");
            }

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_mail);
            mailMessage.To.Add(message.To.Value);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Text;
            mailMessage.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient())
            {

                smtpClient.Host = SettingManager.GetSettingValue("SmtpServerAddress"); //"smtp.yandex.ru"; 
                smtpClient.Port = SettingManager.GetSettingValue<int>("SmtpServerPort");
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(_mail, _pass);

                try
                {
                   smtpClient.Send(mailMessage);
                }
                catch (Exception e)
                {
                    Logger.Error($"Перехвачено исключение {e}");
                }
            }

            mailMessage.Dispose();

            Logger.Debug($"Отправленно уведомление {mailMessage.Body} по адресу {mailMessage.To.FirstOrDefault()}");
        }
    }
}
