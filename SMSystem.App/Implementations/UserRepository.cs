using Microsoft.EntityFrameworkCore;
using SMSystem.App.Interfaces;
using SMSystem.Data.Context;
using SMSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class UserRepository : Repository<AspNetUser>, IUserRepository
    {
        protected readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public AspNetUser? GetByStringId(string id)
        {
            return _context.AspNetUsers.FirstOrDefault(x => x.Id == id);
        }

        public List<AspNetUser> GetAllWithRoles()
        {
            return _context.AspNetUsers.Include(x => x.Roles).ToList();
        }
    }
}
