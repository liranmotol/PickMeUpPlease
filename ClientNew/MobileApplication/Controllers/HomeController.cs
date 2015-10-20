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
            ViewBag.DefaultBranchName = "Ramat Hasharom";
            ViewBag.DefaultBranchId = 2;


            return View();
        }

    

        public ActionResult Lunch()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult PickUp()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CheckIn()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
    }
}
