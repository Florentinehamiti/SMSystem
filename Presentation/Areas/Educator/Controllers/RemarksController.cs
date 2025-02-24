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
    public class RemarksController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IRemarksService _remarksService;
        private readonly IStudentService _studentService;
        private readonly ISchoolHourService _schoolHourService;

        public RemarksController(ITeacherService teacherService, IRemarksService remarksService, IStudentService studentService, ISchoolHourService schoolHourService)
        {
            _teacherService = teacherService;
            _remarksService = remarksService;
            _studentService = studentService;
            _schoolHourService = schoolHourService;
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
                Description = r.SchoolHour.SchoolHourDescribe,
                SchoolHourDescription = r.SchoolHour.SchoolHourDescribe,
                SubjectWhichRemarkWas = r.SchoolHour.Subject.Name
            }).ToList();

            return View(remarksViewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var remarksOfStudent = await _remarksService.GetRemarksAndSubjectsForStudentByStudentId(id);

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
                    Description = e.Description,
                    RemarkInsertedDate = e.InsertedDate,
                    SchoolHourDescription = e.SchoolHour.SchoolHourDescribe,
                }).ToList()
            };

            return View(studentDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddRemark(int schoolHourId, int diaryId)
        {
            var remark = new RemarkViewModel
            {
               Students = _studentService.GetAllStudentsForDiary(diaryId),
               SchoolHour = _schoolHourService.GetById(schoolHourId),
               SchoolHourId = schoolHourId,
               DiaryId = diaryId
            };
           
            return View(remark);
        }

        [HttpPost]
        public async Task<IActionResult> AddRemark(Remark remark)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    remark.InsertedDate = DateTime.Now;
                    _remarksService.AddRemark(remark);
                    return RedirectToAction("Index", "SchoolHour", new { area = "Educator" });
                }

                return View(remark);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(remark);
            }

        }
    }
}
