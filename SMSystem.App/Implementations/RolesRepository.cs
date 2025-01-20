using Microsoft.EntityFrameworkCore;
using SMSystem.App.Interfaces;
using SMSystem.Data.Context;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class RolesRepository : Repository<AspNetRole>, IRolesRepository
    {
        protected readonly ApplicationDbContext _context;

        public RolesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public AspNetRole? GetByStringId(string id)
        {
            return _context.AspNetRoles.FirstOrDefault(x => x.Id == id);
        }

        public AspNetRole? GetByUserId(string userId)
        {
            return _context.AspNetUsers.Include(x => x.Roles).FirstOrDefault(x => x.Id == userId)?.Roles.FirstOrDefault();
        }
    }
}
