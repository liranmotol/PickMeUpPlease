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
            ClassPickUpModel.GetInstance();
            return View(ClassPickUpModel.PickUpDic);
        }

        public ActionResult ManagePickUps()
        {
            ClassPickUpModel.GetInstance();
            return View(ClassPickUpModel.PickUpDic);
        }

        public void UpdateShowPickUps(string Who,string Where)
        {
            if (string.IsNullOrEmpty(Who))
                return;
            if (ClassPickUpModel.PickUpDic.Any(c => c.Key.ToUpper() == Who.ToUpper()))
                ClassPickUpModel.PickUpDic[Who.ToUpper()] = Where;
            else
                ClassPickUpModel.PickUpDic.Add(Who.ToUpper(), Where);
        }
        public void RemoveValue(string Who)
        {
            if (Who==null)
                return;
            if (ClassPickUpModel.PickUpDic.Any(c => c.Key.ToUpper() == Who.ToUpper()))
                ClassPickUpModel.PickUpDic.Remove(Who);
        }

    }
}
