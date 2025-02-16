using SMSystem.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Areas.Admin.Models.ViewModels
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Classes? Class { get; set; }
        public IEnumerable<Classes>? Classes { get; set; }
    }
}
