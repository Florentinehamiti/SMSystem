using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Presentation.Areas.Admin.Models.ViewModels;
using SMSystem.App.Constants;
using SMSystem.App.Implementations;
using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;

namespace Presentation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    [Authorize(Roles = AreasConstants.Admin)]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDiaryService _diaryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserService _userService;
       
        public StudentController(IStudentService studentService, IWebHostEnvironment webHostEnvironment, IUserService userService, IDiaryService diaryService)
        {
            _studentService = studentService;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
            _diaryService = diaryService;
        }
        public IActionResult Index()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                var studentsViewModel = students.Select(t => new StudentViewModel
                {
                    Id = t.Id,
                    ParentName = t.ParentName,
                    //DiaryId = t.DiaryId,
                    Name = t.Name,
                    Lastname = t.Lastname,
                    Birthday = t.Birthday,
                    Tel=t.Tel,
                    Email = t.Email,
                    Gender = t.Gender,
                    ProfilePhotoPath = t.ProfilePhotoPath,
                    InsertedBy = _userService.GetUserId(),
                    InsertedDate = DateTime.Now,
                    LUB = t.LUB,
                    LUD = t.LUD,
                    LUN = t.LUN
                }).ToList();
                return View(studentsViewModel);
            }
            catch (Exception ex)
            {

                return View("Error", ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            var diaries = _diaryService.GetDiariesWithTeachers();

            var viewModel = new StudentViewModel
            {
                Diaries = diaries
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                string photoPath = null;

                if (studentViewModel.ProfilePhoto != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(studentViewModel.ProfilePhoto.FileName);
                    photoPath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(photoPath, FileMode.Create))
                    {
                        await studentViewModel.ProfilePhoto.CopyToAsync(fileStream);
                    }

                    photoPath = fileName;
                }

                var student = new Student
                {
                    ParentName = studentViewModel.ParentName,
                    DiaryId = studentViewModel.DiaryId,
                    Name = studentViewModel.Name,
                    Lastname = studentViewModel.Lastname,
                    Birthday = studentViewModel.Birthday,
                    Email = studentViewModel.Email,
                    Tel = studentViewModel.Tel,
                    Gender = studentViewModel.Gender,
                    ProfilePhotoPath = photoPath,
                    InsertedBy = _userService.GetUserId(),
                    InsertedDate = DateTime.Now
                };

                _studentService.AddStudent(student);

            
                var defaultPassword = "Password123!";
                var result = await _userService.CreateUserForEntityAsync(
                    student.Email,
                    student.Name,
                    student.Lastname,
                    AreasConstants.Client, 
                    defaultPassword
                );

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(studentViewModel);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(studentViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var student = _studentService.GetById(id);

                if (student == null)
                {
                    return NotFound();
                }

                var studentViewModel = new StudentViewModel
                {
                    Id = student.Id,
                    ParentName = student.ParentName,
                    //DiaryId = student.DiaryId,
                    Name = student.Name,
                    Lastname = student.Lastname,
                    Birthday = student.Birthday,
                    Email = student.Email,
                    Tel = student.Tel,
                    Gender = student.Gender,
                    ProfilePhotoPath = student.ProfilePhotoPath,
                    LUB = _userService.GetUserId(),
                    LUD = DateTime.Now,
                    LUN = student.LUN + 1
                };

                return View(studentViewModel);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingStudent = _studentService.GetById(studentViewModel.Id);

                    if (existingStudent == null)
                    {
                        return NotFound();
                    }


                    existingStudent.ParentName = studentViewModel.ParentName;
                    //existingStudent.DiaryId = studentViewModel.DiaryId;
                    existingStudent.Name = studentViewModel.Name;
                    existingStudent.Lastname = studentViewModel.Lastname;
                    existingStudent.Birthday = studentViewModel.Birthday;
                    existingStudent.Email = studentViewModel.Email;
                    existingStudent.Tel = studentViewModel.Tel;
                    existingStudent.Gender = studentViewModel.Gender;
                    existingStudent.ProfilePhotoPath = studentViewModel.ProfilePhotoPath;
                    existingStudent.LUB = _userService.GetUserId();
                    existingStudent.LUD = DateTime.Now;
                    existingStudent.LUN = studentViewModel.LUN + 1;

                    if (studentViewModel.ProfilePhoto != null)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(studentViewModel.ProfilePhoto.FileName);
                        string newPhotoPath = Path.Combine(uploadsFolder, fileName);

                        using (var fileStream = new FileStream(newPhotoPath, FileMode.Create))
                        {
                            await studentViewModel.ProfilePhoto.CopyToAsync(fileStream);
                        }


                        if (!string.IsNullOrEmpty(existingStudent.ProfilePhotoPath))
                        {
                            string oldPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", existingStudent.ProfilePhotoPath);
                            if (System.IO.File.Exists(oldPhotoPath))
                            {
                                System.IO.File.Delete(oldPhotoPath);
                            }
                        }

                        existingStudent.ProfilePhotoPath = fileName;
                    }

                    _studentService.Update(existingStudent);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                TempData["ErrorMessage"] = "Student could not be found.";
                return RedirectToAction("Index");
            }

            try
            {
                if (!string.IsNullOrEmpty(student.ProfilePhotoPath))
                {
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", student.ProfilePhotoPath);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

              
                _studentService.Remove(student);

                TempData["SuccessMessage"] = "Student was successfully deleted.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the student: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
