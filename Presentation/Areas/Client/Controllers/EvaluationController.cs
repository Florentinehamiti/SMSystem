using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Client.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;

namespace Presentation.Areas.Client.Controllers
{
    [Area(AreasConstants.Client)]
    [Authorize(Roles = AreasConstants.Client)]
    public class EvaluationController : Controller
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        public async Task<IActionResult> Index()
        {
            var studentEmail = User.Identity.Name;
            var evaluations = await _evaluationService.GetEvaluationsForLoggedStudentAsync(studentEmail);

       
            var evaluationViewModel = new EvaluationViewModel
            {
                StudentId = evaluations.FirstOrDefault()?.Student?.Id,
                ProfilePhotoPath = evaluations.FirstOrDefault()?.Student?.ProfilePhotoPath,
                FullName = evaluations.FirstOrDefault()?.Student?.Name +" " + evaluations.FirstOrDefault()?.Student?.Lastname,
                ParentName = evaluations.FirstOrDefault()?.Student?.ParentName,
                Email = evaluations.FirstOrDefault()?.Student?.Email,
                Tel = evaluations.FirstOrDefault()?.Student?.Tel,
                Birthday = evaluations.FirstOrDefault()?.Student?.Birthday,
                Gender = evaluations.FirstOrDefault()?.Student?.Gender,
                Subjects = evaluations.Select(e => new SubjectViewModel
                {
                    Id = e.Subject.Id,
                    Name = e.Subject.Name,
                    Value = e.Value
                }).ToList()
            };

            return View(evaluationViewModel);
        }
    }
}
