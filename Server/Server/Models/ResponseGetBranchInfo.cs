﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class ResponseGetBranchInfo : BaseResponse
    {
        public List<BranchModel> Branches{ get; set; }
    }
}