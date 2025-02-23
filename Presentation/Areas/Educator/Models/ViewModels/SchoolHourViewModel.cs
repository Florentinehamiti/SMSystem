using SMSystem.Models.Entities;

namespace Presentation.Areas.Educator.Models.ViewModels
{
    public class SchoolHourViewModel
    {
        public int SchoolHourId { get; set; }
        public int DiaryId { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public int HourNumber { get; set; }
        public string? SubjectName { get; set; }
        public string SchoolHourDescribe { get; set; }
        public int? SubjectId { get; set; }
        public IEnumerable<Subject>? Subjects { get; set; }
        public List<StudentInfo> Students { get; set; } = new List<StudentInfo>();
        public List<int> AbsentStudentIds { get; set; } = new List<int>();
    }
}
