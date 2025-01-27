using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class RemarkStudent
    {
        public int Id { get; set; }
        public int RemarkId { get; set; }
        [ForeignKey("Remark")]
        public Remark Remark { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("Student")]
        public Student Student { get; set; }
    }
}
