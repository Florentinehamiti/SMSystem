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
    [Index("RoleId", Name = "IX_AspNetRoleClaims_RoleId")]
    public partial class AspNetRoleClaim
    {
        [Key]
        public int Id { get; set; }
        public string RoleId { get; set; } = null!;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("AspNetRoleClaims")]
        public virtual AspNetRole Role { get; set; } = null!;
    }
}
