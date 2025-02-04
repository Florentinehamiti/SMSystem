using SMSystem.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Areas.Admin.Models.ViewModels
{
    public class DiaryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "School Code is required")]
        public string? SchoolCode { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public string? Year { get; set; }

        [Required(ErrorMessage = "Paralel is required")]
        public int? Paralel { get; set; }

        [Required(ErrorMessage = "Class is required")]
        public int? Class { get; set; }

        [Required(ErrorMessage = "Teacher is required")]
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public IEnumerable<Teacher>? Teachers { get; set; }
        public string? InsertedBy { get; set; } = null;
        public DateTime? InsertedDate { get; set; }
        public string? LUB { get; set; } = null;
        public DateTime? LUD { get; set; }
        public int? LUN { get; set; }
    }
}
