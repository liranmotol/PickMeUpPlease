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
            //ViewBag.HrefAssignment = "popupStudentCheckIn";
            ViewBag.Title = "Check In List";
            BranchModel b = BranchModel.GetBranchById(BranchId);
            return View(b.StudentsList);
        }

        [HttpPost]
        public string CheckInApproved(int StudentId)
        {
            StudentModel student = StudentModel.GetStudentById(StudentId);
            if (student != null)
            {
                CounslerModel counsler = Utils.Utils.GetCounslerFromRequest();
                student.SetStudentCheckedIn(counsler);
                return "OK";
            }
            else
                return "Student was not found";
        }


        [HttpPost]
        public string PickUpStudent(int StudentId, string Picker)
        {
            StudentModel student = StudentModel.GetStudentById(StudentId);
            if (student != null)
            {
                CounslerModel counsler = Utils.Utils.GetCounslerFromRequest();
                if (Picker == null)
                    Picker = "Auto Assigned default picker";
                //student.PickUp = new CheckedInOutModel() { ByWhom = Picker, CounslerId = counsler.ID, IsByOther = StudentModel.IsPickedByOther(Picker), When = DateTime.Now };

                student.SetStudentPickedUp(counsler, Picker);
                return "OK";
            }
            else
                return "Student was not found";
        }

        public ActionResult PickUpStudent(int StudentId)
        {
            ViewBag.Title = "Pick Up Student";

            StudentModel student = StudentModel.GetStudentById(StudentId);
            if (student != null)
            {
                CounslerModel counsler = Utils.Utils.GetCounslerFromRequest();

                
            }
            return View("StudentPickUp", student);
        }
        public ActionResult PickUpList(int BranchId)
        {
            ViewBag.Title = "Pick Up Student List";
            //ViewBag.Message = "PickUpList.";
            //ViewBag.RedirectMethodName = "StudentsInfoList";
            //ViewBag.DataRel = "";

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

        public ActionResult StudentsInfo(int BranchId)
        {

            ViewBag.Title = "Students Info";

            BranchModel b = BranchModel.GetBranchById(BranchId);
            return View(b.StudentsList);
        }

    }
}
