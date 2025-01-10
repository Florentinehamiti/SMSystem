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
    [Index("UserId", Name = "IX_AspNetUserClaims_UserId")]
    public partial class AspNetUserClaim
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("AspNetUserClaims")]
        public virtual AspNetUser User { get; set; } = null!;
    }
}
