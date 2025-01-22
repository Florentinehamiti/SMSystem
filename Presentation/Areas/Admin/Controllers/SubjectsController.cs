using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Implementations;
using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;

namespace Presentation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    [Authorize(Roles = AreasConstants.Admin)]
    public class SubjectsController : Controller
    {
        private readonly ISubjectsService _subjectsService;
        private readonly IUserService _userService;

        public SubjectsController(ISubjectsService subjectsService, IUserService userService)
        {
            this._subjectsService = subjectsService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            try
            {
                var subjects = _subjectsService.GetAllSubjects();
                
                return View(subjects);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","");
                return View(subject);
            }

            
            _subjectsService.AddSubject(subject);

            return RedirectToAction("Index");
        }
    }
}
