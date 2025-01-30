using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    [Authorize(Roles = AreasConstants.Admin)]
    public class DiaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
