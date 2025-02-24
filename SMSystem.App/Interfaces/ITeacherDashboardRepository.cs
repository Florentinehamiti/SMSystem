using Microsoft.EntityFrameworkCore;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface ITeacherDashboardRepository
    {
        Task<List<Subject>> GetSubjectsByTeacherEmailAsync(string teacherEmail);
        Task<Diary?> GetDiaryIdByTeacherEmailAsync(string teacherEmail);
        Task<IEnumerable<Student?>> GetStudentsForDiary(int diaryId);
        Task<List<Student>> GetTopStudentsWithGrade5Async(int subjectId);
        Task<int> GetTotalAbsencesForSubjectAsync(int subjectId);

    }
}
