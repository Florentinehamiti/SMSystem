using Microsoft.AspNetCore.Mvc;
using SMSystem.App.Interfaces;

namespace Presentation.Areas.Educator.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IStudentService _studentService;
        public SubjectController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index(int id)
        {
            var students = _studentService.GetAllStudentsForDiary(id);
            return View();
        }
    }
}
