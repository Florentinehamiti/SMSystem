using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Educator.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;

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

            var subjectStudents = new Dictionary<int, List<Student>>();
            var subjectAbsences = new Dictionary<int, int>();

            foreach (var subject in subjects)
            {
                var topStudents = await _teacherDashboardService.GetTopStudentsWithGrade5Async(subject.Id);
                subjectStudents[subject.Id] = topStudents;

     
                subjectAbsences[subject.Id] = await _teacherDashboardService.GetTotalAbsencesForSubjectAsync(subject.Id);
            }

            var dashboard = new DashboardTeacherViewModel
            {
                DiaryId = diary.Id,
                Subjects = subjects,
                SubjectStudents = subjectStudents,
                SubjectAbsences = subjectAbsences
            };

            return View(dashboard);
        }
    }
}
