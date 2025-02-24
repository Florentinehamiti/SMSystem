using SMSystem.Models.Entities;

namespace Presentation.Areas.Client.Models.ViewModels
{
    public class EvaluationViewModel
    {
        public int? StudentId { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public string? FullName { get; set; }
        public string? ParentName { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public IEnumerable<SubjectViewModel> Subjects { get; set; }

    }
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
