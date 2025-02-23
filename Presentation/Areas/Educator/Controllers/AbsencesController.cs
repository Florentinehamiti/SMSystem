using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Educator.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Implementations;
using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;

namespace Presentation.Areas.Educator.Controllers
{
    [Area(AreasConstants.Teacher)]
    [Authorize(Roles = AreasConstants.Teacher)]
    public class AbsencesController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IAbsenceService _absencesService;
        private readonly IStudentService _studentService;

        public AbsencesController(ITeacherService teacherService, IAbsenceService absencesService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _absencesService = absencesService;
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var teacherEmail = User.Identity.Name;
            var diary = await _teacherService.GetDiaryIdForLoggedTeacherAsync(teacherEmail);

            var absences = _absencesService.GetAllAbsencesForSubjectAndDiary(diary.Id);
            
            var absencesViewModel = absences.Select(r => new AbsencesViewModel
            {
                StudentId = r.StudentId,
                StudentName = r.Student.Name + " " + r.Student.Lastname,
                AbsenceDate = r.InsertedDate,
                SubjectWhichHasAbsences = r.SchoolHour.Subject.Name,
                SchoolHourDescription = r.SchoolHour.SchoolHourDescribe
            }).ToList();

            return View(absencesViewModel);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var remarksOfStudent = _absencesService.GetAbsencesAndSubjectsForStudentByStudentId(id);

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
                Absences = remarksOfStudent.Select(e => new AbsencesViewModel
                {
                    StudentId = e.StudentId,
                    StudentName = e.Student.Name + " " + e.Student.Lastname,
                    AbsenceDate = e.InsertedDate,
                    SubjectWhichHasAbsences = e.SchoolHour.Subject.Name,
                    SchoolHourDescription = e.SchoolHour.SchoolHourDescribe
                }).ToList()
            };

            return View(studentDetailsViewModel);
        }
    }
}
