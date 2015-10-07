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
                //Request.GetOwinContext().
                CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(Request.GetOwinContext());
                
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


        [HttpGet, HttpPost]
        [Route("Branches/Update")]
        public ResponseGetBranchInfo Update(RequestGetBranchInfo StudentUpdateRequest)
        {
            //System.Diagnostics.Trace.TraceError("Update Request");
            //string userName = SimpleAuthorizationServerProvider.GetUserNameFromContext(Request.GetOwinContext());
            //CounslerModel counsler = InMemoryHandler.GetCounslerByUserName(userName);
            //if (counsler == null)
            //    return null;
            //ResponseGetBranchInfo branch = BranchModel.GetBranchesInfo(counsler, StudentUpdateRequest.LastSyncTime);
            //branch = BranchModel.GetBranchesInfo(counsler, DateTime.MinValue);
            //branch.Status = 1;
            return Get(StudentUpdateRequest);

        }
    }
}
