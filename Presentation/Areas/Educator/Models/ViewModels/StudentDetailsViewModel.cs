using SMSystem.Models.Entities;

namespace Presentation.Areas.Educator.Models.ViewModels
{
    public class StudentDetailsViewModel
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string ParentName { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoPath { get; set; }
        public DateTime Birthday { get; set; }
        public string Tel { get; set; }
        public bool Gender { get; set; }
        public List<EvaluateViewModel> Evaluations { get; set; }
        public List<RemarkViewModel> Remarks { get; set; }

    }
}
