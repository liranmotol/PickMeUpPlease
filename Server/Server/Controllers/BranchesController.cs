using Server.AuthHelpers;
using Server.Hndlers;
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
            ResponseGetBranchInfo branch = new ResponseGetBranchInfo();
            try
            {
                string a = "a";
                string b = a ?? "no";

                //Request.GetOwinContext().
                string userName = SimpleAuthorizationServerProvider.GetUserNameFromContext(Request.GetOwinContext());
                CounslerModel counsler = InMemoryHandler.GetUserIdFromCounslerUserName(userName);
                if (counsler == null)

                {
                    branch.Status = 3;
                    branch.ErrorMsg = "couldn't find counsler";
                }
                //ResponseGetBranchInfo branch = BranchModel.GetBranchesInfo(counsler, requestBranchInfo.LastSyncTime);
                branch = BranchModel.GetBranchesInfo(counsler, DateTime.MinValue);
                branch.Status = 1;
            }
            catch (Exception ex)
            {
                branch.Status = 2;
                branch.ErrorMsg = ex.Message;

            }
            return branch;

        }
    }
}
