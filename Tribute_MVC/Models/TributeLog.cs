using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tribute_MVC.Models
{
    public class TributeLog
    {
        public int LogId { get; set; }
        public DateTime DateOfModification { get; set; }
        public int TributeId { get; set; }
        public int UserId { get; set; }
    }
}
