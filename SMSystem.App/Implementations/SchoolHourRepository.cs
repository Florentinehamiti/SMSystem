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
    public class SchoolHourRepository : Repository<SchoolHour>, ISchoolHourRepository
    {
        private readonly ApplicationDbContext _context;
        public SchoolHourRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SchoolHour> GetAllSchoolHoursByDiaryIdAndTeacherId(int diaryId, int teacherId)
        {
            return _context.SchoolHours.Include(sh => sh.Subject).Where(sh => sh.DiaryId == diaryId && sh.TeacherId == teacherId).ToList();
        }
    }
}
