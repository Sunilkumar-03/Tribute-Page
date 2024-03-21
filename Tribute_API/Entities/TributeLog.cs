using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribute_API.Entities
{
    public class TributeLog
    {
        [Key]
        public int LogId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfModification { get; set; }
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
