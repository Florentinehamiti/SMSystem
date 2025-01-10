using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Models.Entities
{
    [Index("UserId", Name = "IX_AspNetUserLogins_UserId")]
    public partial class AspNetUserLogin
    {
        [Key]
        [StringLength(128)]
        public string LoginProvider { get; set; } = null!;
        [Key]
        [StringLength(128)]
        public string ProviderKey { get; set; } = null!;
        public string? ProviderDisplayName { get; set; }
        public string UserId { get; set; } = null!;

        [ForeignKey("UserId")]
        [InverseProperty("AspNetUserLogins")]
        public virtual AspNetUser User { get; set; } = null!;
    }
}
