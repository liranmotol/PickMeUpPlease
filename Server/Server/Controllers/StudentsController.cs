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

    public class StudentsController : ApiController
    {
        [HttpGet, HttpPost]
        [Route("Students/PickedUp")]
        public string PickedUp(RequestStudentPickedUp StudentPickedUpRequest)
        {
            if (InMemoryHandler.IsTokenValid(StudentPickedUpRequest.Token))
            {
                InMemoryHandler.StudentPickedUp(StudentPickedUpRequest.StudentId, StudentPickedUpRequest.PickerName, StudentPickedUpRequest.BranchId);
                return "Cool. bye bye";
            }
            else
                return "Illegal Token";

        }

        [HttpGet, HttpPost]
        [Route("Students/CheckedIn")]
        public string CheckedIn(RequestStudentCheckedIn StudentCheckedInRequest)
        {
            //if (InMemoryHandler.IsTokenValid(StudentPickedUpRequest.Token))
            //{
            //    InMemoryHandler.StudentPickedUp(StudentPickedUpRequest.StudentId, StudentPickedUpRequest.PickerName, StudentPickedUpRequest.BranchId);
            //    return "";
            //}
            //else
            //    return "Illegal Token";
            return "Students checked in . thank you";
        }

        [HttpGet, HttpPost]
        [Route("Students/Update")]
        public List<StudentModel> Update(RequestStudentUpdateList StudentUpdateRequest)
        {
            CounslerModel counsler = InMemoryHandler.GetCounslerByToken(StudentUpdateRequest.Token);
            if (counsler == null)
                return null;
            ResponseGetBranchInfo branch = InMemoryHandler.GetBranchesInfo(counsler, StudentUpdateRequest.LastSyncTime);
            return branch.Branches[0].StudentsList;
        }
        
    }
}