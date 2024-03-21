using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tribute_MVC.Models
{
    public class Tribute
    {

        public int TributeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Abstract { get; set; }
        [Required]
        public string Description { get; set; }
        public string RefferenceLink { get; set; }
        public string Approval { get; set; }
        public string Status { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
