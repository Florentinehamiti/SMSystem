using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SMSystem.App.Interfaces;
using SMSystem.Data.Context;
using SMSystem.Models.Entities;
using SMSystem.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IRolesRepository _rolesRepository;
        protected readonly ApplicationDbContext _context;

        private HttpContext _httpContext { get { return _contextAccessor.HttpContext; } }

        public UserService(IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager, IUserRepository userRepository, IRolesRepository rolesRepository, ApplicationDbContext context)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _userRepository = userRepository;
            _rolesRepository = rolesRepository;
            if (_httpContext.User.Identity!.IsAuthenticated)
            {
                var id = userManager.GetUserId(_httpContext.User);
                CurrentUser = userRepository.GetByStringId(id);
                CurrentRole = _rolesRepository.GetByUserId(id);
            }
            _context = context;
        }

        private AspNetUser? CurrentUser { get; set; }
        private AspNetRole? CurrentRole { get; set; }
        public string GetUserEmail()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.Email!;
            }
            else
            {
                return "";
            }
        }

        public string GetUserId()
        {
            try
            {


                if (CurrentUser != null)
                {
                    return CurrentUser.Id;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetUserName()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.UserName!;
            }
            else
            {
                return "";
            }
        }

        public string? GetUserPhoneNumber()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.PhoneNumber;
            }
            else
            {
                return "";
            }
        }

        public string GetUserRole()
        {
            if (CurrentRole != null)
            {
                return CurrentRole.Name!;
            }
            else
            {
                return "";
            }
        }

        public string GetFullName()
        {

            if (CurrentUser != null)
            {
                return CurrentUser.Name + " " + CurrentUser.Surname;
            }
            else
            {
                return "";
            }
        }
    }
}