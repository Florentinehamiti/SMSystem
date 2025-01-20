using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    public class Base
    {
        public int InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public int LUB { get; set; }
        public DateTime LUD { get; set; }
        public int LUN { get; set; }
    }
}
