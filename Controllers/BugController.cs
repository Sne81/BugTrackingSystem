using Microsoft.AspNetCore.Mvc;

namespace BugTrackingSystem.Controllers
{
    public class BugController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
