using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class DashboardService:IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            return new DashboardViewModel
            {
                TotalStudents = await _dashboardRepository.GetTotalStudentsAsync(),
                TotalTeachers = await _dashboardRepository.GetTotalTeachersAsync(),
                TotalDiaries = await _dashboardRepository.GetTotalDiariesAsync(),
                TotalSubjects = await _dashboardRepository.GetTotalSubjectesAsync(),
                StudentStatisticsByMonth = await _dashboardRepository.GetStudentStatisticsByMonthAsync(),
                ClassStatisticsByMonth = await _dashboardRepository.GetClassStatisticsByMonthAsync(),
                ProfessorStatisticsByMonth = await _dashboardRepository.GetProfessorStatisticsByMonthAsync()
            };
        }
    }
}
