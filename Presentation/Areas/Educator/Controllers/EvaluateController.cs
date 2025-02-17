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
    public class EvaluateController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IEvaluationService _evaluationService;
        private readonly ISubjectsService _subjectService;

        public EvaluateController(IStudentService studentService, IEvaluationService evaluationService, ISubjectsService subjectService)
        {
            _studentService = studentService;
            _evaluationService = evaluationService;
            _subjectService = subjectService;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
