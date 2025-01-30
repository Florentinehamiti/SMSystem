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
            //[ForeignKey("SubjectId")]
            //public Subject Subject { get; set; }
            public int TeacherId { get; set; }
            //[ForeignKey("TeacherId")]
            //public Teacher Teacher { get; set; }
            public int DiaryId { get; set; }
            //[ForeignKey("DiaryId")]
            //public Diary Diary { get; set; }
        }
    }
