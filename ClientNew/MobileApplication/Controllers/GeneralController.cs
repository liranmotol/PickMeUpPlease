using MobileApplication.Hndlers;
using MobileApplication.Models;
using MobileApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileApplication.Controllers
{
    [Authorize]

    public class GeneralController : Controller
    {
        public ActionResult ShowPickUps()
        {
            return View(InMemoryHandler.ClassPicks);
        }

        public ActionResult ManagePickUps()
        {
            return View(InMemoryHandler.ClassPicks);
        }

        public ActionResult ShowPickUpsMobile()
        {
            return View(InMemoryHandler.ClassPicks);
        }
        public bool DoRefreshRequest()
        {
            if (DoRefresh)
            {
                DoRefresh = false;
                return true;
            }
            else
                return false ;
        }

        static bool DoRefresh = false;
        public bool UpdateShowPickUps(int WhoId, string Where, bool UpdateAlways)
        {
            //if (string.IsNullOrEmpty(Who))
            //    return;
            var temp = InMemoryHandler.ClassPicks.Where(c => c.Id == WhoId).FirstOrDefault();
            if (temp != null)
                temp.Where = Where;
            if (UpdateAlways)
                temp.UpdateInDB();
            DoRefresh = true;
            return true;
        }

        public bool UpdateCounslerPickUps(int GroupId, int CounslerId)
        {
            ClassPickUpModel.UpdateCounslerGroup(GroupId, InMemoryHandler.GetCounslerById(CounslerId));
            DoRefresh = true;
            return true;
        }

    }
}
