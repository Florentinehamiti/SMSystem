using SMSystem.Models.Entities;

namespace Presentation.Areas.Admin.Models.ViewModels
{
    public class DashboardTeacherViewModel
    {
        public Diary Diary { get; set; }
        public Student Student { get; set; }
        public IEnumerable<Student> Students { get; set; }  
        public Subject Subject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
