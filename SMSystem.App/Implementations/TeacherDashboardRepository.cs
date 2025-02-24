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

        public async Task<IEnumerable<Student?>> GetStudentsForDiary(int diaryId)
        {

            var students = await _context.Students
                 .Where(students => students.DiaryId == diaryId).ToListAsync();
            return students;
        }

        public async Task<List<Student>> GetTopStudentsWithGrade5Async(int subjectId)
        {
            return await _context.Evaluations
                .Where(g => g.SubjectId == subjectId && g.Value == 5)
                .Select(g => new Student
                {
                    Id = g.Student.Id,
                    Name = g.Student.Name,
                    ProfilePhotoPath = g.Student.ProfilePhotoPath 
                })
                .Distinct()
                .Take(4)
                .ToListAsync();
        }

        public async Task<int> GetTotalAbsencesForSubjectAsync(int subjectId)
        {
            return await _context.Absences
                .Where(a => a.SchoolHour.SubjectId == subjectId && a.Status == false)
                .CountAsync();
        }


    }

}