using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Educator.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Implementations;
using SMSystem.App.Interfaces;

namespace Presentation.Areas.Educator.Controllers
{
    [Area(AreasConstants.Teacher)]
    [Authorize(Roles = AreasConstants.Teacher)]
    public class RemarksController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IRemarksService _remarksService;
        private readonly IStudentService _studentService;

        public RemarksController(ITeacherService teacherService, IRemarksService remarksService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _remarksService = remarksService;
            _studentService = studentService;
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

        public async Task<IActionResult> Detail(int id)
        {
            var remarksOfStudent = await _remarksService.GetRemarksAndSubjectsByDiaryId(id);

            var student = _studentService.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDetailsViewModel = new StudentDetailsViewModel
            {
                StudentId = student.Id,
                FullName = student.Name + " " + student.Lastname,
                Email = student.Email,
                ProfilePhotoPath = student.ProfilePhotoPath,
                Birthday = student.Birthday,
                Gender = student.Gender ?? false,
                ParentName = student.ParentName,
                Tel = student.Tel,
                Remarks = remarksOfStudent.Select(e => new RemarkViewModel
                {
                    SubjectWhichRemarkWas = e.SchoolHour.Subject.Name,
                    RemarkDescription = e.Description,
                    RemarkInsertedDate = e.InsertedDate,
                    SchoolHourDescription = e.SchoolHour.SchoolHourDescribe,
                }).ToList()
            };

            return View(studentDetailsViewModel);
        }
    }
}
