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
    public class DiaryController : Controller
    {
        private readonly IDiaryService _diaryService;
        private readonly ITeacherService _teacherService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserService _userService;

        public DiaryController(IDiaryService diaryService, IWebHostEnvironment webHostEnvironment, IUserService userService, ITeacherService teacherService)
        {
            _diaryService = diaryService;
            _teacherService = teacherService;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
        }
        
        public IActionResult Index()
        {
            try
            {
                var diaries = _diaryService.GetAllDiaries();

                var diaryViewModels = diaries.Select(d => new DiaryViewModel
                {
                    Id = d.Id,
                    SchoolCode = d.SchoolCode,
                    Year = d.Year,
                    Paralel = d.Paralel,
                    TeacherId = d.TeacherId,
                    Teachers = _teacherService.GetAllTeachers(),
                }).ToList();

                return View(diaryViewModels);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var teachers = _teacherService.GetAllTeachers();

            var viewModel = new DiaryViewModel
            {
                Teachers = teachers
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DiaryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var diary = new Diary
                    {
                        SchoolCode = viewModel.SchoolCode ?? 0, 
                        Year = viewModel.Year ?? 0,
                        Paralel = viewModel.Paralel ?? 0,
                        TeacherId = viewModel.TeacherId ?? 0
                    };
                    
                    _diaryService.AddDiary(diary);
                   
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the diary.");
                }
            }

            viewModel.Teachers = _teacherService.GetAllTeachers();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                // Fetch the diary from the service
                var diary = _diaryService.GetById(id);

                if (diary == null)
                {
                    return NotFound();
                }

                // Fetch the list of teachers for the dropdown
                var teachers = _teacherService.GetAllTeachers();

                // Map the Diary entity to the DiaryViewModel
                var viewModel = new DiaryViewModel
                {
                    Id = diary.Id,
                    SchoolCode = diary.SchoolCode,
                    Year = diary.Year,
                    Paralel = diary.Paralel,
                    TeacherId = diary.TeacherId,
                    Teachers = teachers // Populate the Teachers dropdown
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Diary diary)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingDiary = _diaryService.GetById(diary.Id);

                    if (existingDiary == null)
                    {
                        return NotFound();
                    }

                    //existingDiary.ParentName = diary.ParentName;
                    
                    existingDiary.LUB = _userService.GetUserId();
                    existingDiary.LUD = DateTime.Now;
                    existingDiary.LUN = diary.LUN + 1;


                    _diaryService.Update(existingDiary);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(diary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var diary = _diaryService.GetById(id);
            if (diary == null)
            {
                TempData["ErrorMessage"] = "Diary could not be found.";
                return RedirectToAction("Index");
            }

            try
            {
                _diaryService.Remove(diary);
                TempData["SuccessMessage"] = "Diary was successfully deleted.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the diary: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
