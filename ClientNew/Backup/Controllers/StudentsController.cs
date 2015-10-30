using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileApplication.Controllers
{
    public class StudentsController : Controller
    {
        //
        // GET: /Students/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckInList(int BranchId)
        {
            ViewBag.Title = "Check In List";
            BranchModel b = BranchModel.GetBranchById(BranchId);
            return View(b.StudentsList);
        }

        public ActionResult CheckInListAreYouSure(int StudentId)
        {
            StudentModel student = StudentModel.GetStudentById(StudentId);

            return View(student);
        }


        public ActionResult PickUpList(int BranchId)
        {
            
            ViewBag.Message = "PickUpList.";
            BranchModel b = BranchModel.GetBranchById(BranchId);

            return View(b.StudentsList);
        }
        public ActionResult LunchList(int BranchId)
        {
            ViewBag.Message = "LunchList.";
            BranchModel b = BranchModel.GetBranchById(BranchId);

            return View("CheckInList", b.StudentsList);

        }
        public ActionResult StudentsInfoList(int StudentId)
        {
            ViewBag.Message = "StudentsInfoList.";
            StudentModel student = StudentModel.GetStudentById(StudentId);

            return View(student);

        }
      

    }
}
