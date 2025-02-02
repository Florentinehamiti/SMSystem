using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Student:Base
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public int? AddressId { get; set; }
        public string ProfilePhotoPath { get; set; }

        //[ForeignKey("AddressId")]
        //public virtual Address Address { get; set; }

    }
}
