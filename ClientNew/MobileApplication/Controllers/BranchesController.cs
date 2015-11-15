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
    [CompressAttribute]
    public class BranchesController : Controller
    {
        public ActionResult BranchesInfo(int BranchId)
        {
            BranchModel b =BranchModel.GetBranchById(BranchId);
            return View(b);
        }
        public void ChangeBranch()
        {
            //add property to the user - current branch. and change it there
        }

        public ActionResult ChangeBranchPicker()
        {
            //add property to the user - current branch. and change it there
            ViewBag.Message = "Your app description page.";

            return View();
        }

    }
}
