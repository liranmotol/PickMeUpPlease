using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class ResponseGetBranchInfo
    {
        public List<BranchModel> Branches{ get; set; }
    }
}