using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class RequestStudentPickedUp : ClientRequest
    {
        public int BranchId { get; set; }
        public string StudentId { get; set; }
        public string PickerName { get; set; }
    }

    public class RequestStudentCheckedIn : ClientRequest
    {
        public int BranchId { get; set; }
        public string StudentId { get; set; }

    }

    public class RequestStudentUpdateList : ClientRequest
    {
        public int BranchId { get; set; }
        public DateTime LastSyncTime { get; set; }


    }

    public class RequestCounslerCheckedInOut : ClientRequest
    {
        public int BranchId { get; set; }

    }

    public abstract class ClientRequest
    {
        public string Token { get; set; }
        public bool IsTokenValid() 
        {
            return true;
        }

    }

    public class RequestGetBranchInfo : ClientRequest
    {
        public DateTime LastSyncTime { get; set; }
    }


}