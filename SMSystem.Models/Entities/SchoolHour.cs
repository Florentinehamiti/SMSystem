using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class SchoolHour:Base
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HourNumber { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("Subject")]
        public Subject Subject { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("Teacher")]
        public Teacher Teacher { get; set; }
        public int DiaryId { get; set; }
        [ForeignKey("Diary")]
        public Diary Diary { get; set; }
    }
}
