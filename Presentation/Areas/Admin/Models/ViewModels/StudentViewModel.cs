using SMSystem.Models.Entities;

namespace Presentation.Areas.Admin.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public int DiaryId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
        public bool Gender { get; set; }
        public int AddressId { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string LUB { get; set; }
        public DateTime? LUD { get; set; }
        public int? LUN { get; set; }
    }
}
