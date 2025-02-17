using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models.ViewModels;
using Presentation.Areas.Educator.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Implementations;
using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;

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

        public SchoolHourController(ITeacherDashboardService teacherDashboardService, ISchoolHourService schoolHourService, ITeacherService teacherService, ISubjectsService subjectsService, IUserService userService)
        {
            _teacherDashboardService = teacherDashboardService;
            _schoolHourService = schoolHourService;
            _teacherService = teacherService;
            _subjectsService = subjectsService;
            _userService = userService;
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

            var viewModel = new SchoolHourViewModel
            {
                DiaryId = diary.Id,
                Subjects = subjectsOfClass,
                TeacherId = _teacherService.GetByEmail(teacherEmail).Id
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
            return View(schoolHourVM);
        }
    }
}
