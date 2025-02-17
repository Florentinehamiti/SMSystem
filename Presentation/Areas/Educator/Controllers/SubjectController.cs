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
    public class SubjectController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IAbsenceService _absenceService;
        private readonly IEvaluationService _evaluationService;
        private readonly ISubjectsService _subjectService;
        public SubjectController(IStudentService studentService, IAbsenceService abesenceService, IEvaluationService evaluationService, ISubjectsService subjectService)
        {
            _studentService = studentService;
            _absenceService = abesenceService;
            _evaluationService = evaluationService;
            _subjectService = subjectService;
        }
        public IActionResult Index(int diaryId, int subjectId)
        {
            var students = _studentService.GetAllStudentsForDiary(diaryId);
            var absences = _absenceService.GetAllAbsencesForSubjectAndDiary(subjectId, diaryId);
            var evaluations = _evaluationService.GetAllEvaluationsForSubjectAndDiary(subjectId, diaryId);
            var subject = _subjectService.GetById(subjectId);


            var studentViewModel = new StudentViewModel
            {
                SubjectName = subject?.Name,
                SubjectId = subjectId,
                DiaryId = diaryId,
                Students = students.Select(s => new StudentInfo
                {
                    StudentId = s.Id,
                    Name = s.Name,
                    Lastname = s.Lastname,
                    ProfilePhotoPath = s.ProfilePhotoPath,
                    TotalAbsences = absences.Count(a => a.StudentId == s.Id),
                    Grade = evaluations.Where(e => e.StudentId == s.Id).Select(e => e.Value).FirstOrDefault()
                }).ToList()
            };

            return View(studentViewModel);
        }
    }
}
