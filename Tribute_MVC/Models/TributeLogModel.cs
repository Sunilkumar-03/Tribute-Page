using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tribute_MVC.Models
{
    public class TributeLogModel
    {
        public string UserName { get; set; }
        public string TributeName { get; set; }
        public DateTime dateTime { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
