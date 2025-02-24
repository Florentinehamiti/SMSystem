using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSystem.Models.Entities
{
    public class Subject:Base
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        public int? PublicationYear { get; set; }
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Classes Class { get; set; }
    }
}
