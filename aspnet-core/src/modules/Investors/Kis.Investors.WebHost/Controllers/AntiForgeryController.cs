using Kis.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace Kis.Web.Host.Controllers
{
    public class AntiForgeryController : KisControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
