using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Admin.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;

namespace Presentation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    [Authorize(Roles = AreasConstants.Admin)]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserService _userService;

        public TeacherController(ITeacherService teacherService, IWebHostEnvironment webHostEnvironment, IUserService userService)
        {
            _teacherService = teacherService;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
        }
        public IActionResult Index()
        {
            try
            {
                var teachers = _teacherService.GetAllTeachers();
                var teachersViewModel = teachers.Select(t => new TeacherViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Surname = t.Surname,
                    Birthday = t.Birthday,
                    Email = t.Email,
                    Qualified = t.Qualified,
                    ProfilePhotoPath = t.ProfilePhotoPath,
                    InsertedBy = _userService.GetUserId(),
                    InsertedDate = DateTime.Now,
                    LUB = t.LUB,
                    LUD = t.LUD,
                    LUN = t.LUN
                }).ToList();
                return View(teachersViewModel);
            }
            catch (Exception ex) {

                return View("Error", ex.Message);
            }
          
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherViewModel teacherViewModel)
        {

            if (ModelState.IsValid)
            {
                string photoPath = null;

                if (teacherViewModel.ProfilePhoto != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(teacherViewModel.ProfilePhoto.FileName);
                    photoPath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(photoPath, FileMode.Create))
                    {
                        await teacherViewModel.ProfilePhoto.CopyToAsync(fileStream);
                    }

                    photoPath = fileName;
                }

                var teacher = new Teacher
                {
                    Name = teacherViewModel.Name,
                    Surname = teacherViewModel.Surname,
                    Birthday = teacherViewModel.Birthday,
                    Email = teacherViewModel.Email,
                    Qualified = teacherViewModel.Qualified,
                    ProfilePhotoPath = photoPath,
                    InsertedBy = _userService.GetUserId(),
                    InsertedDate = DateTime.Now
                };

                _teacherService.AddTeacher(teacher);

                var defaultPassword = "Password123!"; 
                var result = await _userService.CreateUserForEntityAsync(
                    teacher.Email,
                    teacher.Name,
                    teacher.Surname,
                    AreasConstants.Teacher,
                    defaultPassword
                );

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(teacherViewModel);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(teacherViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var teacher = _teacherService.GetById(id);

                if (teacher == null)
                {
                    return NotFound();
                }

                var teacherViewModel = new TeacherViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Surname = teacher.Surname,
                    Birthday = teacher.Birthday,
                    Email = teacher.Email,
                    Qualified = teacher.Qualified,
                    ProfilePhotoPath = teacher.ProfilePhotoPath,
                    LUB = _userService.GetUserId(),
                    LUD = DateTime.Now,
                    LUN = teacher.LUN + 1
                };

                return View(teacherViewModel); 
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherViewModel teacherViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingTeacher = _teacherService.GetById(teacherViewModel.Id);

                    if (existingTeacher == null)
                    {
                        return NotFound();
                    }

                  
                    existingTeacher.Name = teacherViewModel.Name;
                    existingTeacher.Surname = teacherViewModel.Surname;
                    existingTeacher.Birthday = teacherViewModel.Birthday;
                    existingTeacher.Email = teacherViewModel.Email;
                    existingTeacher.Qualified = teacherViewModel.Qualified;
                    existingTeacher.LUB = _userService.GetUserId();
                    existingTeacher.LUD = DateTime.Now;
                    existingTeacher.LUN = teacherViewModel.LUN +1;

                    if (teacherViewModel.ProfilePhoto != null)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(teacherViewModel.ProfilePhoto.FileName);
                        string newPhotoPath = Path.Combine(uploadsFolder, fileName);

                        using (var fileStream = new FileStream(newPhotoPath, FileMode.Create))
                        {
                            await teacherViewModel.ProfilePhoto.CopyToAsync(fileStream);
                        }

             
                        if (!string.IsNullOrEmpty(existingTeacher.ProfilePhotoPath))
                        {
                            string oldPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", existingTeacher.ProfilePhotoPath);
                            if (System.IO.File.Exists(oldPhotoPath))
                            {
                                System.IO.File.Delete(oldPhotoPath);
                            }
                        }

                        existingTeacher.ProfilePhotoPath = fileName;
                    }

                    _teacherService.Update(existingTeacher);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(teacherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var teacher = _teacherService.GetById(id);
            if (teacher == null)
            {
                TempData["ErrorMessage"] = "The teacher could not be found.";
                return RedirectToAction("Index");
            }

            try
            {
               
                if (!string.IsNullOrEmpty(teacher.ProfilePhotoPath))
                {
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", teacher.ProfilePhotoPath);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
             
                _teacherService.Remove(teacher);

                TempData["SuccessMessage"] = "The teacher was successfully deleted.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the teacher: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
