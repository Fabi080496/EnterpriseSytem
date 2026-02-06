using Microsoft.AspNetCore.Mvc;

namespace EnterpriseSytem.Api.Controllers.Modules.Identity
{
    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
