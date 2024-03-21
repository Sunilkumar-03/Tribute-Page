using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribute_API.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "BIGINT")]
        public Int64 Mobile { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Role { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        public List<Tribute> Tributes { get; set; }
        public List<Approval> Approvals { get; set; }
        public List<TributeLog> TributeLogs { get; set; } 
    }
}
