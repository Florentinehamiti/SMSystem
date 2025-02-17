namespace Presentation.Areas.Educator.Models.ViewModels
{
    public class EvaluateStudentViewModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int DiaryId { get; set; }
        public string StudentName { get; set; }
        public int GradeValue { get; set; }
    }
}
