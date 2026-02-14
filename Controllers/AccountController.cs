using Microsoft.AspNetCore.Mvc;

namespace BugTrackingSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
