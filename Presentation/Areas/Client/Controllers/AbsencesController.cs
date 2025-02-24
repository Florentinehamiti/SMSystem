using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Client.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Interfaces;

namespace Presentation.Areas.Client.Controllers
{
    [Area(AreasConstants.Client)]
    [Authorize(Roles = AreasConstants.Client)]
    public class AbsencesController : Controller
    {
        private readonly IAbsenceService _absenceService;

        public AbsencesController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }
        public async Task<IActionResult> Index()
        {
            var studentEmail = User.Identity.Name;
            var absences = await _absenceService.GetAbsencesForLoggedStudentAsync(studentEmail);

            
            var absenceViewModel = new AbsenceViewModel
            {
               
                StudentId = absences.FirstOrDefault()?.Student?.Id,
                ProfilePhotoPath = absences.FirstOrDefault()?.Student?.ProfilePhotoPath,
                FullName = absences.FirstOrDefault()?.Student?.Name +" " + absences.FirstOrDefault()?.Student?.Lastname,
                ParentName = absences.FirstOrDefault()?.Student?.ParentName,
                Email = absences.FirstOrDefault()?.Student?.Email,
                Tel = absences.FirstOrDefault()?.Student?.Tel,
                Birthday = absences.FirstOrDefault()?.Student?.Birthday,
                Gender = absences.FirstOrDefault()?.Student?.Gender,
                Absences = absences.Select(a => new AbsenceDetail
                {
                    Date = a.SchoolHour.Date,
                    HourNumber = a.SchoolHour.HourNumber,
                    SubjectName = a.SchoolHour.Subject.Name,
                    Status = a.Status
                }).ToList()
            };

            return View(absenceViewModel);
        }
    }
}
