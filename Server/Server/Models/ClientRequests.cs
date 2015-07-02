using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class RequestStudentPickedUp
    {
        public int BranchId { get; set; }
        public string StudentId { get; set; }
        public string PickerName { get; set; }
        public string Token { get; set; }
    }

    public class RequestStudentCheckedIn
    {
        public int BranchId { get; set; }
        public string StudentId { get; set; }
        public string Token { get; set; }

    }

    public class RequestCounslerCheckedInOut
    {
        public string Token { get; set; }

    }


}