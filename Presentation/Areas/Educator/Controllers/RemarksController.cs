using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Educator.Models.ViewModels;
using SMSystem.App.Interfaces;

namespace Presentation.Areas.Educator.Controllers
{
    public class RemarksController : Controller
    {
        private readonly ITeacherService _teacherService;

        public RemarksController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public async Task<IActionResult> Index()
        {
            var teacherEmail = User.Identity.Name;
            var diary = await _teacherService.GetDiaryIdForLoggedTeacherAsync(teacherEmail);

            var remarks = await _teacherService.GetRemarksAndSubjectsByDiaryId(diary.Id);


            var remarksViewModel = remarks.Select(r => new RemarkViewModel
            {
                StudentId = r.StudentId,
                StudentName = r.Student.Name + " " + r.Student.Lastname,
                RemarkInsertedDate = r.InsertedDate,
                RemarkDescription = r.SchoolHour.SchoolHourDescribe,
                SchoolHourDescription = r.SchoolHour.SchoolHourDescribe,
                SubjectWhichRemarkWas = r.SchoolHour.Subject.Name
            }).ToList();

            return View(remarksViewModel);
        }
    }
}
