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
    [CompressAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index(string UserName)
        {
            //1. check if multyple branches are allowed
            //2 set viewbag with defalt branch and go to home with default branch
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);

            if (counsler == null)
            {

                //TODO add log
                return View("SadFace");
            }
            //else
            //{
            //    if (Session["UserName"] == null)
            //        Session["UserName"] = counsler.UserName;
            //}
            BranchModel defaultBranch = null;
            if (counsler.AllowedBranchedIds.Count > 0)
            {
                defaultBranch = BranchModel.GetBranchById(counsler.AllowedBranchedIds[0]);
                ViewBag.DefaultBranchName = defaultBranch.BranchName;
                ViewBag.DefaultBranchId = defaultBranch.BranchId;
            }
            ViewBag.UserName = UserName;
            CounslerBranchModelToView toView = new CounslerBranchModelToView(counsler, defaultBranch);
            return View(toView);
        }

        [HttpPost]
        public string WriteToUsSubmit(string UserName, string Msg)
        {
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);
            if (MobileApplication.DAL.DataAccess.AddComment(counsler.ID, Msg))
                return "Cool Cool Cool";
            return "Oops... something happend./nplease send it in email...";
        }

        public ActionResult WriteToUs(string UserName)
        {
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);
            return View(counsler);
        }

        public void regAll()
        {
            AccountController a = new AccountController();
            var counslers = MobileApplication.DAL.ApplicationContext.Instnace.contextInstance.counslers.ToList();
            foreach (var item in counslers)
            {
                RegisterModel reg = new RegisterModel()
                {
                    Email = item.email_1,
                    UserName = item.usernmae,
                    Password = "12345678",
                    ConfirmPassword = "12345678"
                };
                a.EnglilushRegister(reg);
            }
        }


        public void EngInitialize()
        {
            InMemoryHandler.Initialize(true);
        }




    }
}
