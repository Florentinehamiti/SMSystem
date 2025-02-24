namespace Presentation.Areas.Client.Models.ViewModels
{

    public class RemarkViewModel
    {
        public int? StudentId { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public string? FullName { get; set; }
        public string? ParentName { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public IEnumerable<RemarkDetail> Remarks { get; set; }
    }

    public class RemarkDetail
    {
        public DateTime Date { get; set; }
        public int HourNumber { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
    }
}
