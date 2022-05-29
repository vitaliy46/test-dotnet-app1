using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Extensions;
using Abp.Net.Mail.Smtp;
using JetBrains.Annotations;
using Kis.General.Api.Services.Messenger;
using Microsoft.EntityFrameworkCore.Internal;
using SendPulse.SDK;
using SendPulse.SDK.Models;

namespace Kis.General.Services.Messenger.DeliveryProviders
{
    public class SendPulseMessageDeliveryProvider : ApplicationService, IMessageDeliveryProvider
    {
        private static string userId = "efe50e337a307f18d65aa04fe83d443f";
        private static string secret = "868ff9f3b7650f5e4d6e55defdde8199";
        private static string from_name = "itpanacea.ru";
        private static string from_email = "vote@itpanacea.ru";
        //private static string from_email = "zefslab@gmail.com";

        private static string login = "zefslab@gmail.com"; // System.Configuration.ConfigurationManager.AppSettings["Email"];
        private static string password = "ff4Ga3NBCsW6S"; //System.Configuration.ConfigurationManager.AppSettings["Sifre"];

        public void Send(Message message)
        {
            //SendPulseService sp = new SendPulseService(userId, secret);

            //EmailData emailData = new EmailData();
            //emailData.From = new EmailAddress
            //{
            //    Name = from_name,
            //    Address = from_email
            //};
            //emailData.To = new List<EmailAddress>
            //{
            //    new EmailAddress
            //    {
            //        Name = message.To,
            //        Address = message.To
            //    }
            //};
            //emailData.Subject = message.Subject;
            //emailData.HTML = message.Text;

            //bool result = sp.SendEmailAsync(emailData).Result;

            if (from_email.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                throw new Exception("Учетная запись для отправки уведомлений не определена");
            }
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from_email);
            mailMessage.To.Add(message.To.Value);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Text;
            mailMessage.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = "smtp-pulse.com";
                smtpClient.Port = 465;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(login, password);

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
