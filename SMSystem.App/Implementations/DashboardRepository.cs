using Microsoft.EntityFrameworkCore;
using SMSystem.App.Interfaces;
using SMSystem.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalStudentsAsync()
        {
            return await _context.Students.CountAsync();
        }

        public async Task<int> GetTotalTeachersAsync()
        {
            return await _context.Teachers.CountAsync();
        }

        public async Task<int> GetTotalDiariesAsync()
        {
            return await _context.Diaries.CountAsync();
        }

        public async Task<int> GetTotalSubjectesAsync()
        {
            return await _context.Subjects.CountAsync();
        }

        public async Task<List<int>> GetStudentStatisticsByMonthAsync()
        {
            var studentCounts = await _context.Students
             .Where(s => s.InsertedDate.HasValue)
             .GroupBy(s => new { s.InsertedDate.Value.Year, s.InsertedDate.Value.Month })
             .Select(g => new
             {
                 Month = g.Key.Month,
                 Count = g.Count()
             })
             .ToListAsync();

           
            var result = new List<int>(new int[12]);

           
            foreach (var item in studentCounts)
            {
                result[item.Month - 1] = item.Count; 
            }

            return result;
        }

        public async Task<List<int>> GetClassStatisticsByMonthAsync()
        {
            var classCounts = await _context.Diaries
            .Where(d => d.InsertedDate.HasValue)
            .GroupBy(d => new { d.InsertedDate.Value.Year, d.InsertedDate.Value.Month })
            .Select(g => new
            {
                Month = g.Key.Month,
                Count = g.Count()
            })
            .ToListAsync();

            var result = new List<int>(new int[12]);

            foreach (var item in classCounts)
            {
                result[item.Month - 1] = item.Count;
            }

            return result;
        }

        public async Task<List<int>> GetProfessorStatisticsByMonthAsync()
        {
            var professorCounts = await _context.Teachers
            .Where(t => t.InsertedDate.HasValue)
            .GroupBy(t => new { t.InsertedDate.Value.Year, t.InsertedDate.Value.Month })
            .Select(g => new
            {
                Month = g.Key.Month,
                Count = g.Count()
            })
            .ToListAsync();

            
            var result = new List<int>(new int[12]);

           
            foreach (var item in professorCounts)
            {
                result[item.Month - 1] = item.Count;
            }

            return result;
        }
    }
}
