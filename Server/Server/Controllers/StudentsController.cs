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

    public class StudentsController : ApiController
    {
        [HttpGet, HttpPost]
        [Route("Students/PickedUp")]
        public string PickedUp(RequestStudentPickedUp StudentPickedUpRequest)
        {
            System.Diagnostics.Trace.TraceInformation("PickedUp Request");
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(Request.GetOwinContext());
            //int studentContactId = Utils.Utils.GetContactIdOfStudentId(StudentPickedUpRequest.StudentId);
            InMemoryHandler.StudentPickedUp(counsler.CounslerID, StudentPickedUpRequest.ContactStudentId, StudentPickedUpRequest.PickerName, StudentPickedUpRequest.IsByOther);
            return "Cool. bye bye";

        }

        [HttpGet, HttpPost]
        [Route("Students/CheckedIn")]
        public string CheckedIn(RequestStudentCheckedIn StudentCheckedInRequest)
        {
            System.Diagnostics.Trace.TraceWarning("CheckedIn Request");
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(Request.GetOwinContext());
            //int studentContactId = Utils.Utils.GetContactIdOfStudentId(StudentCheckedInRequest.ContactStudentId);
            InMemoryHandler.StudentCheckIn(counsler.CounslerID, StudentCheckedInRequest.ContactStudentId);
           

            return "Students checked in . thank you";
        }



    }
}
