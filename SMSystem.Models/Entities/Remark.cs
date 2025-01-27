using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Remark:Base
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string SchoolHourId { get; set; }
        [ForeignKey("SchoolHour")]
        public SchoolHour SchoolHour { get; set; }
        public string StudentId { get; set; }
        [ForeignKey("Student")]
        public Student Student { get; set; }
    }
}
