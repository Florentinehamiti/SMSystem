using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Educator.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Interfaces;

namespace Presentation.Areas.Educator.Controllers
{
    [Area(AreasConstants.Teacher)]
    [Authorize(Roles = AreasConstants.Teacher)]
    public class HomeController : Controller
    {
        private readonly ITeacherDashboardService _teacherDashboardService;

        public HomeController(ITeacherDashboardService teacherDashboardService)
        {
            _teacherDashboardService = teacherDashboardService;
        }
        public async Task<IActionResult> Index()
        {
            var teacherEmail = User.Identity.Name; 
            var subjects = await _teacherDashboardService.GetSubjectsForLoggedTeacherAsync(teacherEmail);
            var diary = await _teacherDashboardService.GetDiaryIdForLoggedTeacherAsync(teacherEmail);

            var dashboard = new DashboardTeacherViewModel
            {
                DiaryId = diary.Id,
                Subjects = subjects,

            };
            return View(dashboard);
        }
    }
}
