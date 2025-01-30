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
    public class DiaryRepository: Repository<Diary>, IDiaryRepository
    {
        private readonly ApplicationDbContext _context;
        public DiaryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
