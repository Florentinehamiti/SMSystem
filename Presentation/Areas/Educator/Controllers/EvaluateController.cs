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
    public class EvaluateController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IEvaluationService _evaluationService;
        private readonly ISubjectsService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly IDiaryService _diaryService;

        public EvaluateController(IStudentService studentService, IEvaluationService evaluationService, ISubjectsService subjectService, ITeacherService teacherService, IDiaryService diaryService)
        {
            _studentService = studentService;
            _evaluationService = evaluationService;
            _subjectService = subjectService;
            _teacherService = teacherService;
            _diaryService = diaryService;
        }
        public async Task<IActionResult> Index()
        {
            var teacherEmail = User.Identity.Name;
            var diary = await _teacherService.GetDiaryIdForLoggedTeacherAsync(teacherEmail);
            var evaluations = await _teacherService.GetEvaluationsAndSubjectsByDiaryId(diary.Id);

            var groupedEvaluations = evaluations
                .GroupBy(e => new { e.StudentId, e.Student.Name, e.Student.Lastname })
                .Select(g => new EvaluateViewModel
                {
                    StudentId = g.Key.StudentId,
                    StudentName = g.Key.Name + " " + g.Key.Lastname,
                    Grades = g.ToDictionary(e => e.Subject.Name, e => e.Value)
                }).ToList();

            return View(groupedEvaluations);
        }


        [HttpGet]
        public IActionResult EvaluateStudent(int studentId, int subjectId, int diaryId)
        {
            var student = _studentService.GetById(studentId);
            var studentsEvaluaton = _evaluationService.GetEvaluationForStudentInSubject(subjectId, studentId);
            var subject = _subjectService.GetById(subjectId);

            var model = new EvaluateStudentViewModel
            {
                EvaluationId = studentsEvaluaton?.Id ?? 0,
                StudentId = student.Id,
                SubjectId = subjectId,
                DiaryId = diaryId,
                StudentName = student.Name + " " + student.Lastname,
                GradeValue = studentsEvaluaton?.Value ?? 0,
                SubjectName = subject.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EvaluateStudent(EvaluateStudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.EvaluationId == 0)
            {
                var newEvaluation = new Evaluation
                {
                    StudentId = model.StudentId,
                    SubjectId = model.SubjectId,
                    DiaryId = model.DiaryId,
                    Value = model.GradeValue
                };

                _evaluationService.AddEvaluation(newEvaluation);
            }
            else
            {

                var existingEvaluation = _evaluationService.GetById(model.EvaluationId);
                if (existingEvaluation != null)
                {
                    existingEvaluation.Value = model.GradeValue;
                    _evaluationService.Update(existingEvaluation);
                }
            }

            return RedirectToAction("Index", "Subject", new { diaryId = model.DiaryId, subjectId = model.SubjectId });
        }

        public async Task<IActionResult> Detail(int id)
        {
            var evaluationsOfStudent = _evaluationService.GetEvaluationsAndSubjectsForStudentByStudentId(id);

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
                Evaluations = evaluationsOfStudent.Select(e => new EvaluateViewModel
                {
                    SubjectName = e.Subject.Name,
                    Grade = e.Value
                }).ToList()
            };

            return View(studentDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddEvaluation(int diaryId, int subjectId)
        {
            var evaluateViewModel = new EvaluateViewModel
            {
                Students = _studentService.GetAllStudentsForDiary(diaryId),
                SubjectId =  subjectId,
                DiaryId = diaryId,
            };

            return View(evaluateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvaluation(EvaluateViewModel evaluation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var registerEvaluation = new Evaluation
                    {
                       StudentId = evaluation.StudentId,
                       InsertedDate = DateTime.Now,
                       Value = evaluation.Grade,
                       SubjectId = evaluation.SubjectId,
                       DiaryId = evaluation.DiaryId,
                    };

                    _evaluationService.AddEvaluation(registerEvaluation);
                    return RedirectToAction("Index", "SchoolHour", new { area = "Educator" });
                }

                return View(evaluation);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(evaluation);
            }

        }
    }
}
