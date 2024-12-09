using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Subjects()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSubject(int a)
        {
            return View();
        }
    }
}
