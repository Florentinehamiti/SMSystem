using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Teacher:Base
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateOnly Birthday { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool Qualified { get; set; }
        public string ProfilePhotoPath { get; set; }

    }
}
