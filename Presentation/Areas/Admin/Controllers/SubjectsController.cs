using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IClassService _classService;
        private readonly IUserService _userService;

        public SubjectsController(ISubjectsService subjectsService, IUserService userService, IClassService classService)
        {
            this._subjectsService = subjectsService;
            _userService = userService;
            _classService = classService;
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
            var classes = _classService.GetAllClasses();

            var viewModel = new SubjectViewModel
            {
                Classes = classes
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddSubject(SubjectViewModel subjectVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Please check the data entered");
                return View(subjectVM);
            }

            var subject = new Subject
            {
                Name = subjectVM.Name,
                BookName = subjectVM.BookName,
                Author = subjectVM.Author,
                PublicationYear = subjectVM.PublicationYear,
                ClassId = subjectVM.ClassId ?? 0,
                InsertedDate = DateTime.Now,
                LUD = DateTime.Now,
                InsertedBy = _userService.GetUserId(),
            };

          
            _subjectsService.AddSubject(subject);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var subject = _subjectsService.GetById(id);

                if (subject == null)
                {
                    return NotFound();
                }

                var classes = _classService.GetAllClasses();

                var viewModel = new SubjectViewModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    BookName = subject.BookName,
                    Author = subject.Author,
                    PublicationYear = subject.PublicationYear,
                    ClassId = subject.ClassId,
                    Classes = classes,
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubjectViewModel subject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingSubject = _subjectsService.GetById(subject.Id);

                    if (existingSubject == null)
                    {
                        return NotFound();
                    }


                    existingSubject.Name = subject.Name;
                    existingSubject.BookName = subject.BookName;
                    existingSubject.Author = subject.Author;
                    existingSubject.PublicationYear = subject.PublicationYear;
                    existingSubject.ClassId = subject.ClassId;
                    existingSubject.LUB = _userService.GetUserId();
                    existingSubject.LUD = DateTime.Now;
                    existingSubject.LUN = existingSubject.LUN + 1;

                  
                    _subjectsService.Update(existingSubject);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(subject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var subject = _subjectsService.GetById(id);
            if (subject == null)
            {
                TempData["ErrorMessage"] = "The subject could not be found.";
                return RedirectToAction("Index");
            }

            try
            {
                _subjectsService.Remove(subject);
                TempData["SuccessMessage"] = "The subject was successfully deleted.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the subject: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
