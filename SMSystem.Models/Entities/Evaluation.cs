using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Evaluation:Base
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int SubjectId { get; set; }
        //[ForeignKey("SubjectId")]
        //public Subject Subject { get; set; }
        public int StudentId { get; set; }
        //[ForeignKey("StudentId")]
        //public Student Student { get; set; }
    }
}
