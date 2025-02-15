using SMSystem.App.Interfaces;
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
        public TeacherDashboardService(ITeacherDashboardRepository teacherDashboardRepository)
        {
            _teacherDashboardRepository = teacherDashboardRepository;
        }

    }
}
