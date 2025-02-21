using Microsoft.AspNetCore.Mvc;
using SMSystem.App.Interfaces;

namespace Presentation.Areas.Educator.Controllers
{
    public class RemarksController : Controller
    {
        private readonly ITeacherService _teacherService;

        //public async Task<IActionResult> Index()
        //{
        //    var teacherEmail = User.Identity.Name;
        //    var diary = await _teacherService.GetDiaryIdForLoggedTeacherAsync(teacherEmail);

        //    var remarks = await _teacherService.GetEvaluationsAndSubjectsByDiaryId(diary.Id);


        //    var evaluationViewModels = evaluations.Select(e => new EvaluateViewModel
        //    {
        //        StudentId = e.StudentId,
        //        StudentName = e.Student.Name + " " + e.Student.Lastname,
        //        SubjectName = e.Subject.Name,
        //        Grade = e.Value
        //    }).ToList();

        //    return View(evaluationViewModels);

        //}
    }
}
