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
    public class TeacherDashboardRepository : Repository<Teacher>, ITeacherDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherDashboardRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetSubjectsByTeacherEmailAsync(string teacherEmail)
        {
            return await _context.Subjects
                .Where(s => _context.Diaries
                    .Any(d => d.Teacher.Email == teacherEmail && d.ClassId == s.ClassId))
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