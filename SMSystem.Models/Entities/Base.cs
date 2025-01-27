using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Base
    {
        public string? InsertedBy { get; set; } = null;
        public DateTime? InsertedDate { get; set; }
        public string? LUB { get; set; } = null;
        public DateTime? LUD { get; set; }
        public int? LUN { get; set; }
    }
}
