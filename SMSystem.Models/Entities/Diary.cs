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
        public int SchoolCode { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("Address")]
        public Address Address { get; set; }
        public int Year { get; set; }
        public int Paralel { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("Teacher")]
        public Teacher Teacher { get; set; }
    }
}
