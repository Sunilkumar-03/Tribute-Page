using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tribute_MVC.Models
{
    public class Approval
    {
        public int ApprovalId { get; set; }
        public DateTime DateOfApproval { get; set; }
        public int TributeId { get; set; }
        public int UserId { get; set; }
    }
}
