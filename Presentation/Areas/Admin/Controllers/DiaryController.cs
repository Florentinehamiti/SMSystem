using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserService _userService;

        public DiaryController(IDiaryService diaryService, IWebHostEnvironment webHostEnvironment, IUserService userService)
        {
            _diaryService = diaryService;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
        }
        public IActionResult Index()
        {
            try
            {
                var diaries = _diaryService.GetAllDiaries();

                return View(diaries);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Diary diary)
        {
            if (ModelState.IsValid)
            {
                _diaryService.AddDiary(diary);

                return RedirectToAction(nameof(Index));
            }

            return View(diary);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var diary = _diaryService.GetById(id);

                if (diary == null)
                {
                    return NotFound();
                }

                return View(diary);
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
