using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribute_API.Entities
{
    public class TributeCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public List<Tribute> Tributes { get; set; }
    }
}
