using Microsoft.AspNetCore.Mvc;
using SMSystem.App.Interfaces;

namespace Presentation.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = _userRepository.GetAllWithRoles();
            return View(users);
        }
    }
}
