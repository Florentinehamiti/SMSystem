using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalStudentsAsync();
        Task<int> GetTotalTeachersAsync();
        Task<int> GetTotalDiariesAsync();
        Task<int> GetTotalSubjectesAsync();
        Task<List<int>> GetStudentStatisticsByMonthAsync();
        Task<List<int>> GetClassStatisticsByMonthAsync();
        Task<List<int>> GetProfessorStatisticsByMonthAsync();
    }
}
