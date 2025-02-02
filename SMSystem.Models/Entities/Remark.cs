using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Remark : Base
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SchoolHourId { get; set; }
        [ForeignKey("SchoolHourId")]
        public virtual SchoolHour SchoolHour { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
