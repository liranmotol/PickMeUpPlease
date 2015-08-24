using Server.DAL;
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
    public class MainController : ApiController
    {

        [HttpGet, HttpPost]
        [Route("Main/testMethod")]
        public string testMethod()
        { 
            //ApplicationContext a = new ApplicationContext();
            //students s = a.Students.First();

            using (var db = new ApplicationContext())
            {
                students s1 = db.Students.First();

            }
                return null;
        }

        //public CounslerModel LoginRequest(RequestLoginModel loginRequest)
        //{
        //    CounslerModel counsler= null;
        //    if (SecurityMemHandler.IsUserAuthenticated(loginRequest))
        //    {
        //        string token = Guid.NewGuid().ToString();
        //        counsler = InMemoryHandler.GetCounslerByUserName(loginRequest.UserName);
        //        counsler.Token = token;
        //        InMemoryHandler.UpdateCounslerToken(token, counsler);
        //    }
        //    return counsler;
        //}

        [HttpGet, HttpPost]
        [Route("GetBranchInfo")]
        public ResponseGetBranchInfo GetBranchInfo(RequestGetBranchInfo requestBranchInfo)
        {
            

            CounslerModel counsler = InMemoryHandler.GetCounslerByUserName("liran");
            if (counsler == null)
                return null;
            ResponseGetBranchInfo branch= InMemoryHandler.GetBranchesInfo(counsler, requestBranchInfo.LastSyncTime);
            return branch;
        }

        [HttpGet, HttpPost]
        [Route("SetStudentPickedUp")]
        public string SetStudentPickedUp(RequestStudentPickedUp StudentPickedUpRequest)
        {
           // if (InMemoryHandler.IsTokenValid(StudentPickedUpRequest.Token))
          //  {
                InMemoryHandler.StudentPickedUp(StudentPickedUpRequest.StudentId, StudentPickedUpRequest.PickerName,StudentPickedUpRequest.BranchId);
                return "";
          //  }
          //  else
          //      return "Illegal Token";

        }

    }

   
}
