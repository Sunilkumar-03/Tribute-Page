using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tribute_MVC.Models.DataViewModel
{
    public class TributeDataView
    {
        public int TributeId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Upload Image")]
        public IFormFile Image { get; set; }
        [Required]
        [StringLength(200,MinimumLength =30,ErrorMessage ="Abstract should be of Minimum 30 words and Maximum 200 words")]
        public string Abstract { get; set; }
        [Required]
        [StringLength(800, MinimumLength = 50, ErrorMessage = "Abstract should be of Minimum 200 words and Maximum 800 words")]
        public string Description { get; set; }
        public string RefferenceLink { get; set; }
        public string Approval { get; set; }
        public string Status { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
