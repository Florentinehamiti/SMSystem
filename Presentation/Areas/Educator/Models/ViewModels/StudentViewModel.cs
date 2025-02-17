using SMSystem.Models.Entities;

namespace Presentation.Areas.Educator.Models.ViewModels
{
    public class StudentViewModel
    {
        public string SubjectName { get; set; }
        public int SubjectId { get; set; }
        public int DiaryId { get; set; }
        public IEnumerable<StudentInfo> Students { get; set; }

    }
    public class StudentInfo
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string ProfilePhotoPath { get; set; }
        public int TotalAbsences { get; set; }
        public double? Grade { get; set; }
    }
}
