using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tribute_API.Entities
{
    public class Tribute
    {
        [Key]
        public int TributeId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string ImageUrl { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Abstract { get; set; }
        [Required]
        [Column(TypeName = "varchar(800)")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string RefferenceLink { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Approval { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Status { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public TributeCategory TributeCategory { get; set; }
        [Display(Name = "User")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
