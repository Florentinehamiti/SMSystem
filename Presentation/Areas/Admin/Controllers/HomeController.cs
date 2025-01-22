using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMSystem.App.Constants;

namespace Presentation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    [Authorize(Roles = AreasConstants.Admin)]
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
        public IActionResult Staff()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStaff()
        {
            return View();
        }
    }
}
