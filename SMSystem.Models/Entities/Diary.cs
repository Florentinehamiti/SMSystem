using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Diary:Base
    {
        public int Id { get; set; }
        public string? SchoolCode { get; set; }
        public int? Class { get; set; }
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        public string? Year { get; set; }
        public int? Paralel { get; set; }
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
