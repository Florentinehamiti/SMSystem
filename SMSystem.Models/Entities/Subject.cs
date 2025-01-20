using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Subject:Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
    }
}
