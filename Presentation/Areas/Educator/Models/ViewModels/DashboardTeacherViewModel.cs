using SMSystem.Models.Entities;

namespace Presentation.Areas.Educator.Models.ViewModels
{
    public class DashboardTeacherViewModel
    {
        public int DiaryId { get; set; }
        public Diary Diary { get; set; }
        public Student Student { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public Subject Subject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
