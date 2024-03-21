using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribute_API.Entities
{
    public class TributeRating
    {
        [Key]
        public int RatingId { get; set; }

        public int Rating { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Comments { get; set; }

        [Display(Name = "Tribute")]
        public int TributeId { get; set; }
        [ForeignKey("TributeId")]
        public Tribute Tribute { get; set; }



        [Display(Name = "User")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
