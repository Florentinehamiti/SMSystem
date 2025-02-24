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
    public class AbsenceRepository : Repository<Absence>, IAbsenceRepository
    {
        private readonly ApplicationDbContext _context;
        public AbsenceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Absence> GetAbsencesByDiaryId(int diaryId)
        {
            return _context.Absences.Where(x => x.DiaryId == diaryId && x.Status == false).Include(s => s.Student).Include(s => s.SchoolHour).ThenInclude(sub => sub.Subject).ToList();
        }
        public IEnumerable<Absence> GetAbsencesAndSubjectsForStudentByStudentId(int id)
        {
            return _context.Absences.Where(x => x.StudentId == id && x.Status == false).Include(s => s.SchoolHour).ThenInclude(sub => sub.Subject).ToList();
        }

        public void AddAbsence(Absence absence)
        {
            _context.Absences.Add(absence);
        }

        public async Task<IEnumerable<Absence>> GetAbsencesForLoggedStudentAsync(string studentEmail)
        {
            return await _context.Absences
                .Include(a => a.Student)
                .Include(a => a.SchoolHour)
                .ThenInclude(sh => sh.Subject)
                .Where(a => a.Student.Email == studentEmail)
                .ToListAsync();
        }
    }
}
