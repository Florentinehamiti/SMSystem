using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int TotalDiaries { get; set; }
        public int TotalTeachers { get; set; }
        public int TotalSubjects { get; set; }
        public List<int> StudentStatisticsByMonth { get; set; }
        public List<int> ClassStatisticsByMonth { get; set; }
        public List<int> ProfessorStatisticsByMonth { get; set; }
    }
}
