using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class RequestGetBranchInfo
    {
        public DateTime LastSyncTime { get; set; }
        public string Token { get; set; }
    }
}