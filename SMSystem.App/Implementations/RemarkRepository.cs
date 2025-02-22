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
    public class RemarkRepository : Repository<Remark>, IRemarksRepository
    {
        private readonly ApplicationDbContext _context;
        public RemarkRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Remark>> GetRemarksAndSubjectsByDiaryId(int diaryId)
        {
            return await _context.Remarks
                .Where(x => x.DiaryId == diaryId)
                .Include(e => e.Student) 
                .Include(e => e.SchoolHour) 
                .ThenInclude(sh => sh.Subject) 
                .ToListAsync();
        }
    }
    
}
