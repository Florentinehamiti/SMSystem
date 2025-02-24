using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMSystem.App.Interfaces;
using SMSystem.Data.Identity;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class TeacherDashboardService :ITeacherDashboardService
    {
        private ITeacherDashboardRepository _teacherDashboardRepository;
        private readonly IUserService _userService;
        public TeacherDashboardService(ITeacherDashboardRepository teacherDashboardRepository, IUserService userService)
        {
            _teacherDashboardRepository = teacherDashboardRepository;
            _userService = userService;
        }

        public async Task<List<Subject>> GetSubjectsForLoggedTeacherAsync(string teacherEmail)
        {
            return await _teacherDashboardRepository.GetSubjectsByTeacherEmailAsync(teacherEmail);
        }

        public async Task<Diary?> GetDiaryIdForLoggedTeacherAsync(string teacherEmail)
        {
            return await _teacherDashboardRepository.GetDiaryIdByTeacherEmailAsync(teacherEmail);
        }

        public async Task<IEnumerable<Student?>> GetStudentsForDiary(int diaryId)
        {
            return await _teacherDashboardRepository.GetStudentsForDiary(diaryId);
        }

        public async Task<List<Student>> GetTopStudentsWithGrade5Async(int subjectId)
        {
            return await _teacherDashboardRepository.GetTopStudentsWithGrade5Async(subjectId);
        }

        public async Task<int> GetTotalAbsencesForSubjectAsync(int subjectId)
        {
            return await _teacherDashboardRepository.GetTotalAbsencesForSubjectAsync(subjectId);
        }
    }
}
