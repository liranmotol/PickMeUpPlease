using MobileApplication.Models;
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
    public class StudentsController : Controller
    {
        //
        // GET: /Students/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckInList(int BranchId, string UserName)
        {
            //ViewBag.HrefAssignment = "popupStudentCheckIn";
            ViewBag.Title = "Check In List";
            BranchModel b = BranchModel.GetBranchById(BranchId);
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);

            var studentLightList = StudentLight.BuildStudentLight(b.StudentsList);
            StudentLightModelToView studentModelToView = new StudentLightModelToView(studentLightList, counsler);
            return View(studentModelToView);

        }

        [HttpPost]
        public string CheckInApproved(int StudentId, string UserName)
        {
            StudentModel student = StudentModel.GetStudentById(StudentId);
            if (student != null)
            {
                CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);
                student.SetStudentCheckedIn(counsler);
                return "OK";
            }
            else
                return "Student was not found";
        }


        [HttpPost]
        public string PickUpStudent(int StudentId, string Picker, string UserName)
        {
            StudentModel student = StudentModel.GetStudentById(StudentId);
            if (student != null)
            {
                CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);
                if (Picker == null)
                    Picker = "Auto Assigned default picker";
                //student.PickUp = new CheckedInOutModel() { ByWhom = Picker, CounslerId = counsler.ID, IsByOther = StudentModel.IsPickedByOther(Picker), When = DateTime.Now };

                student.SetStudentPickedUp(counsler, Picker);
                return "OK";
            }
            else
                return "Student was not found";
        }

        public ActionResult PickUpStudent(int StudentId, string UserName)
        {
            ViewBag.Title = "Pick Up Student";

            StudentModel student = StudentModel.GetStudentById(StudentId);
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);
            StudentCounslerModelToView toView = new StudentCounslerModelToView(student, counsler);

            return View("StudentPickUp", toView);
        }
        public ActionResult PickUpList(int BranchId, string UserName)
        {
            ViewBag.Title = "Pick Up Student List";
            //ViewBag.Message = "PickUpList.";
            //ViewBag.RedirectMethodName = "StudentsInfoList";
            //ViewBag.DataRel = "";

            BranchModel b = BranchModel.GetBranchById(BranchId);
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);

            var studentLightList = StudentLight.BuildStudentLight(b.StudentsList);
            StudentLightModelToView studentModelToView = new StudentLightModelToView(studentLightList, counsler);
            return View(studentModelToView);

        }
        public ActionResult LunchList(int BranchId, string UserName)
        {
            ViewBag.Message = "LunchList.";
            BranchModel b = BranchModel.GetBranchById(BranchId);
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);

            var studentLightList = StudentLight.BuildStudentLight(b.StudentsList);
            StudentLightModelToView studentModelToView = new StudentLightModelToView(studentLightList, counsler);
            return View(studentModelToView);
            return View("CheckInList", studentModelToView);

        }
        public ActionResult StudentsInfoList(int StudentId)
        {
            ViewBag.Message = "StudentsInfoList.";
            StudentModel student = StudentModel.GetStudentById(StudentId);

            return View(student);

        }

        public ActionResult StudentsInfo(int BranchId, string UserName)
        {

            ViewBag.Title = "Students Info";

            BranchModel b = BranchModel.GetBranchById(BranchId);
            CounslerModel counsler = Utils.Utils.GetCounslerFromRequest(UserName);

            var studentLightList = StudentLight.BuildStudentLight(b.StudentsList);
            StudentLightModelToView studentModelToView = new StudentLightModelToView(studentLightList, counsler);
            return View(studentModelToView);
        }

    }
}
