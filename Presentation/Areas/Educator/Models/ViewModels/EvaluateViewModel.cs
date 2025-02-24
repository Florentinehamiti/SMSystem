using SMSystem.Models.Entities;

namespace Presentation.Areas.Educator.Models.ViewModels
{
    public class EvaluateViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public int Grade { get; set; }
        public IEnumerable<Student>? Students { get; set; }
        public IEnumerable<Subject>? Subjects { get; set; }
        public int DiaryId { get; set; }
        public int SubjectId { get; set; }


    }
}
