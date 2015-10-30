using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //1. check if multyple branches are allowed
            //2 set viewbag with defalt branch and go to home with default branch
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest();
            if (counsler == null)
            { 
                //TODO add log
                return View("SadFace");
            }
            if (counsler.AllowedBranchedIds.Count > 0)
            {
                BranchModel defaultBranch = BranchModel.GetBranchById(counsler.AllowedBranchedIds[0]);
                ViewBag.DefaultBranchName = defaultBranch.BranchName;
                ViewBag.DefaultBranchId = defaultBranch.BranchId;
            }
            return View();
        }

    

       
    }
}
