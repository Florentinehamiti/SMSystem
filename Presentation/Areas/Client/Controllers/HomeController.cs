using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Client.Models;
using Presentation.Areas.Client.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Interfaces;
using System.Diagnostics;

namespace Presentation.Areas.Client
{
    [Area(AreasConstants.Client)]
    [Authorize(Roles = AreasConstants.Client)]
    public class HomeController : Controller
    {
        private readonly IEvaluationService _evaluationService;
        private readonly IAbsenceService _absenceService;
        private readonly IRemarksService _remarksService;

        public HomeController(
            IEvaluationService evaluationService,
            IAbsenceService absenceService,
            IRemarksService remarksService)
        {
            _evaluationService = evaluationService;
            _absenceService = absenceService;
            _remarksService = remarksService;
        }

        public async Task<IActionResult> Index()
        {
            var studentEmail = User.Identity.Name;

           
            var evaluations = await _evaluationService.GetEvaluationsForLoggedStudentAsync(studentEmail);
            var absences = await _absenceService.GetAbsencesForLoggedStudentAsync(studentEmail);
            var remarks = await _remarksService.GetRemarksForLoggedStudentAsync(studentEmail);

           
            var averageGrade = evaluations.Any() ? evaluations.Average(e => e.Value) : 0;
            var totalAbsences = absences.Count();
            var totalRemarks = remarks.Count();

           
            var dashboardViewModel = new DashboardViewModel
            {
                AverageGrade = averageGrade,
                TotalAbsences = totalAbsences,
                TotalRemarks = totalRemarks
            };

            return View(dashboardViewModel);
        }
    }
}
