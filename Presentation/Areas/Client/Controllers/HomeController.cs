using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Client.Models;
using SMSystem.App.Constants;
using System.Diagnostics;

namespace Presentation.Areas.Client
{
    [Area(AreasConstants.Client)]
    [Authorize(Roles = AreasConstants.Client)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Subjects()
        {
            return View();
        }
    }
}
