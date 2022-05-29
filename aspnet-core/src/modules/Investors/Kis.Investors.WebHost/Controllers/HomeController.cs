using System;
using System.Threading.Tasks;
using Abp;
using Abp.Extensions;
using Abp.Notifications;
using Abp.Timing;
using Kis.Controllers;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Web.Host.Controllers
{
    public class HomeController : KisControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IOrganizationUnitCrudAppService _organizationUnitCrudAppService;

        public HomeController(INotificationPublisher notificationPublisher,
            IOrganizationUnitCrudAppService organizationUnitCrudAppService)
        {
            _notificationPublisher = notificationPublisher ?? throw new System.ArgumentNullException(nameof(notificationPublisher));
            this._organizationUnitCrudAppService = organizationUnitCrudAppService ?? throw new System.ArgumentNullException(nameof(organizationUnitCrudAppService));
        }

        public IActionResult Index() => Redirect("/swagger");

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestNotification(string message = "")
        {
            await _organizationUnitCrudAppService.Create(new OrganizationUnitDto()
            {
                Id = Guid.NewGuid(),
                Name = "Организация 1",
                //Header = new PersonDto()
                //{
                //    Id = Guid.NewGuid(),
                //    BirthDate = DateTime.Now,
                //    Gender = Gender.Male,
                //    Name = "Василий",
                //    Surname = "Иванов",
                //    Patronymic = "Петрович",
                //    Snils = "123-456-789 88",
                //    //Address = new AddressDto()
                //    //{
                //    //    AddressType = AddressTypes.Home,
                //    //    City = "17",
                //    //    Country = "Россия"
                //    //}
                //}
            });

            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            var defaultTenantAdmin = new UserIdentifier(1, 2);
            var hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData(message),
                severity: NotificationSeverity.Info,
                userIds: new[] { defaultTenantAdmin, hostAdmin }
            );

            return Content("Sent notification: " + message);
        }
    }
}
