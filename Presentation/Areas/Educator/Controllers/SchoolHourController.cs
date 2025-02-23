using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models.ViewModels;
using Presentation.Areas.Educator.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Implementations;
using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using StudentViewModel = Presentation.Areas.Educator.Models.ViewModels.StudentViewModel;

namespace Presentation.Areas.Educator.Controllers
{
    [Area(AreasConstants.Teacher)]
    [Authorize(Roles = AreasConstants.Teacher)]
    public class SchoolHourController : Controller
    {
        private readonly ITeacherDashboardService _teacherDashboardService;
        private readonly ITeacherService _teacherService;
        private readonly ISchoolHourService _schoolHourService;
        private readonly ISubjectsService _subjectsService;
        private readonly IUserService _userService;
        private readonly IAbsenceService _absenceService;

        public SchoolHourController(ITeacherDashboardService teacherDashboardService, ISchoolHourService schoolHourService, ITeacherService teacherService, ISubjectsService subjectsService, IUserService userService, IAbsenceService absenceService)
        {
            _teacherDashboardService = teacherDashboardService;
            _schoolHourService = schoolHourService;
            _teacherService = teacherService;
            _subjectsService = subjectsService;
            _userService = userService;
            _absenceService = absenceService;
        }
        public async Task<IActionResult> Index()
        {
            var teacherEmail = User.Identity.Name;
            var diary = await _teacherDashboardService.GetDiaryIdForLoggedTeacherAsync(teacherEmail);
            var teacher = _teacherService.GetByEmail(teacherEmail);

            var schoolHours = _schoolHourService.GetAllSchoolHoursByDiaryIdAndTeacherId(diary.Id, teacher.Id);

            var schoolHourViewModel = schoolHours.Select(sh => new SchoolHourViewModel
            {
                HourNumber = sh.HourNumber,
                Date = sh.Date,
                SubjectName = sh.Subject.Name,
                DiaryId = sh.DiaryId,
                SchoolHourDescribe = sh.SchoolHourDescribe,
                SchoolHourId = sh.Id
            }).ToList();


            return View(schoolHourViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teacherEmail = User.Identity.Name;
            var diary = await _teacherDashboardService.GetDiaryIdForLoggedTeacherAsync(teacherEmail);
            var subjectsOfClass = _subjectsService.GetSubjectsByClassId(diary.ClassId);
            var students = await _teacherDashboardService.GetStudentsForDiary(diary.Id);

            var viewModel = new SchoolHourViewModel
            {
                DiaryId = diary.Id,
                Subjects = subjectsOfClass,
                TeacherId = _teacherService.GetByEmail(teacherEmail).Id,
                Students = students.Select(s => new StudentInfo { StudentId = s.Id, Name = s.Name,  Lastname = s.Lastname}).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolHourViewModel schoolHourVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var schoolHour = new SchoolHour
                    {
                        Date = schoolHourVM.Date,
                        HourNumber = schoolHourVM.HourNumber,
                        SubjectId = schoolHourVM.SubjectId ?? 0,
                        TeacherId = schoolHourVM.TeacherId,
                        DiaryId = schoolHourVM.DiaryId,
                        SchoolHourDescribe = schoolHourVM.SchoolHourDescribe,
                        InsertedBy = _userService.GetUserId(),
                        InsertedDate = DateTime.Now,
                    };

                    _schoolHourService.AddSchoolHour(schoolHour);

                    
                    foreach (var studentId in schoolHourVM.AbsentStudentIds)
                    {
                        var absence = new Absence
                        {
                            SchoolHourId = schoolHour.Id,
                            StudentId = studentId,
                            DiaryId = schoolHourVM.DiaryId,
                            Status = true,
                            InsertedBy = _userService.GetUserId(),
                            InsertedDate = DateTime.Now,
                        };

                        _absenceService.AddAbsence(absence);
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the diary.");
                }
            }

            var teacherEmail = User.Identity.Name;
            var diary = await _teacherDashboardService.GetDiaryIdForLoggedTeacherAsync(teacherEmail);
            schoolHourVM.Subjects = _subjectsService.GetSubjectsByClassId(diary.ClassId);
            var students = await _teacherDashboardService.GetStudentsForDiary(diary.Id);

            schoolHourVM.Students = students
                .Select(s => new StudentInfo
                {
                    StudentId = s.Id,
                    Name = s.Name,
                    Lastname = s.Lastname
                }).ToList();

            return View(schoolHourVM);
        }
    }
}
