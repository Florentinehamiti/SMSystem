using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface ITeacherDashboardService
    {
        Task<List<Subject>> GetSubjectsForLoggedTeacherAsync(string teacherEmail);
        Task<Diary?> GetDiaryIdForLoggedTeacherAsync(string teacherEmail);

    }
}
