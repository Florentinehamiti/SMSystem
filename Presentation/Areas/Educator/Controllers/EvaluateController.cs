using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMSystem.App.Constants;
using SMSystem.Models.Entities;

namespace Presentation.Areas.Educator.Controllers
{
    [Area(AreasConstants.Teacher)]
    [Authorize(Roles = AreasConstants.Teacher)]
    public class EvaluateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EvaluateStudent(int studentId, int subjectId, int diaryId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EvaluateStudent(Evaluation evaluation)
        {
            return View();
        }
    }
}
