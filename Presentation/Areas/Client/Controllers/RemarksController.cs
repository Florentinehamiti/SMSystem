using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Client.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Interfaces;

namespace Presentation.Areas.Client.Controllers
{
    [Area(AreasConstants.Client)]
    [Authorize(Roles = AreasConstants.Client)]
    public class RemarksController : Controller
    {
        private readonly IRemarksService _remarksService;
        public RemarksController(IRemarksService remarksService)
        {
            _remarksService = remarksService;
        }

        public async Task<IActionResult> Index()
        {
            var studentEmail = User.Identity.Name;
            var remarks = await _remarksService.GetRemarksForLoggedStudentAsync(studentEmail);

            
            var remarkViewModel = new RemarkViewModel
            {
               
                StudentId = remarks.FirstOrDefault()?.Student?.Id,
                ProfilePhotoPath = remarks.FirstOrDefault()?.Student?.ProfilePhotoPath,
                FullName = remarks.FirstOrDefault()?.Student?.Name +" " +remarks.FirstOrDefault()?.Student?.Lastname,
                ParentName = remarks.FirstOrDefault()?.Student?.ParentName,
                Email = remarks.FirstOrDefault()?.Student?.Email,
                Tel = remarks.FirstOrDefault()?.Student?.Tel,
                Birthday = remarks.FirstOrDefault()?.Student?.Birthday,
                Gender = remarks.FirstOrDefault()?.Student?.Gender,
                Remarks = remarks.Select(r => new RemarkDetail
                {
                    Date = r.SchoolHour.Date,
                    HourNumber = r.SchoolHour.HourNumber,
                    SubjectName = r.SchoolHour.Subject.Name,
                    Description = r.Description
                }).ToList()
            };

            return View(remarkViewModel);
        }
    }
}
