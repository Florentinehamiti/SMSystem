using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateOnly Birthday { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool Qualified { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
        public int InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public int LUB { get; set; }
        public DateTime LUD { get; set; }
        public int LUN { get; set; }
    }
}

