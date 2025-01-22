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
    public class SubjectsRepository: Repository<Subject>, ISubjectsRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectsRepository(ApplicationDbContext context) : base(context)
        {

            _context = context;
        }
    }
}
