namespace Presentation.Areas.Educator.Models.ViewModels
{
    public class RemarkViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string SchoolHourDescription { get; set; }
        public DateTime? RemarkInsertedDate { get; set; }
        public string RemarkDescription { get; set; }
        public string SubjectWhichRemarkWas { get; set; }

    }
}
