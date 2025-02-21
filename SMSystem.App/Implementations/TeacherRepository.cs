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
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {

            _context = context;
        }

        public Teacher GetByEmail(string email)
        {
            return _context.Teachers.Where(x => x.Email == email).FirstOrDefault();
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluationsAndSubjectsByDiaryId(int diaryId)
        {
            return await _context.Evaluations
                .Where(e => e.DiaryId == diaryId)
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .ToListAsync();
        }
        public async Task<IEnumerable<Remark>> GetRemarksAndSchoolHoursByDiaryId(int diaryId)
        {
            return await _context.Remarks
               .Where(e => e.DiaryId == diaryId)
               .Include(e => e.Student)
               .Include(e => e.SchoolHour)
                    .ThenInclude(sh => sh.Subject)
               .ToListAsync();
        }

        public async Task<Diary?> GetDiaryIdByTeacherEmailAsync(string teacherEmail)
        {
            var diary = await _context.Diaries
                 .Where(s => _context.Diaries
                    .Any(d => d.Teacher.Email == teacherEmail))
                .FirstOrDefaultAsync();

            return diary;
        }
    }
}
