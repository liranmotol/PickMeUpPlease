using MobileApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileApplication.Controllers
{
    [CompressAttribute]
    [Authorize]
    public class CounslersController : Controller
    {

        public ActionResult MyInfo(string UserName)
        {
            MobileApplication.Models.CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);

            MobileApplication.Models.CounslerInfoModelToView c = new Models.CounslerInfoModelToView(counsler);
            return View("CounslerInfo",c);
        }

    }
}
