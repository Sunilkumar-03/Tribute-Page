using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tribute_MVC.Models
{
    public class TributeRating
    {
        public int RatingId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int TributeId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
