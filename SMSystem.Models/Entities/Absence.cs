using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Absence:Base
    {
        public int Id { get; set; }
        public int SchoolHourId { get; set; }
        //[ForeignKey("SchoolHourId")]
        //public SchoolHour SchoolHour { get; set; }
        public bool Status { get; set; }
        public int StudentId { get; set; }
        //[ForeignKey("StudentId")]
        //public Student Student { get; set; }
    }
}
