using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Data.Entities
{
    public partial class AspNetUserToken
    {
        [Key]
        public string UserId { get; set; } = null!;
        [Key]
        [StringLength(128)]
        public string LoginProvider { get; set; } = null!;
        [Key]
        [StringLength(128)]
        public string Name { get; set; } = null!;
        public string? Value { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("AspNetUserTokens")]
        public virtual AspNetUser User { get; set; } = null!;
    }
}
