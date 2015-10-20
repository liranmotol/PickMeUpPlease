using MobileApplication.Hndlers;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Utils
{
    public class Utils
    {
        internal static string GetGender(bool gender)
        {
            if (gender)
                return "Male";
            return "Female";

        }

        internal static CounslerModel GetCounslerFromRequest()
        {
            string userName = System.Web.Security.Membership.GetUser().UserName;
            CounslerModel counsler = InMemoryHandler.GetUserIdFromCounslerUserName(userName);
            return counsler;
        }

        internal static int GetContactIdOfStudentId(string studentId)
        {
            var tempContact = InMemoryHandler.Students.Where(s => s.StudentID == studentId).Select(s => s.StudentContactID).FirstOrDefault();
            //if (tempContact == null)
            //    return 0;
            return tempContact;
        }
    }
}