﻿using Server.Hndlers;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Server.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BranchesController : ApiController
    {
        [Authorize]
        [HttpGet, HttpPost]
        [Route("Branches/Get")]
        public ResponseGetBranchInfo Get(RequestGetBranchInfo requestBranchInfo)
        {
            CounslerModel counsler = InMemoryHandler.GetCounslerByToken(requestBranchInfo.Token);
            if (counsler == null)
                return null;
            ResponseGetBranchInfo branch = InMemoryHandler.GetBranchesInfo(counsler, requestBranchInfo.LastSyncTime);
            return branch;
        }
    }
}