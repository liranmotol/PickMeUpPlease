using MobileApplication.DAL;
using MobileApplication.Hndlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    [Serializable]
    public class StudentModel
    {
        public int ID { get; set; }
        public string StudentUserID { get; set; }
        public string Img { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public string Address { get; set; }

        public string SClass { get; set; }
        public string PickUpFrom { get; set; }
        public List<string> HealthIssues { get; set; }
        public string HealthIssuesString { get; set; }

        public CheckedInOutModel CheckedIn { get; set; }
        public CheckedInOutModel PickUp { get; set; }
        public List<string> PickUpOptions { get; set; }
        public string Parent1Name { get; set; }
        public string Parent1Num { get; set; }
        public string Parent1Email { get; set; }
        public string Parent2Email { get; set; }

        public string Parent2Name { get; set; }
        public string Parent2Num { get; set; }

        public string HomeNum { get; set; }

        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthDayString { get; set; }

        public bool IsCheckedIn
        {
            get
            {
                if (CheckedIn != null)
                    return CheckedIn.CounslerId != 0;
                else
                    return false;
            }
        }

        public bool IsPickedUp
        {
            get
            {
                if (PickUp != null)
                    return PickUp.CounslerId != 0;
                else
                    return false;
            }
        }

        public StudentModel()
        {
            HealthIssues = new List<string>();
            CheckedIn = new CheckedInOutModel();
            PickUp = new CheckedInOutModel();
            PickUpOptions = new List<string>();
        }

        public DateTime LastUpdateTime { get; set; }
        public int BranchId { get; set; }


        internal static StudentModel GetStudentById(int StudentId)
        {
            return InMemoryHandler.Students.Where(s => s.ID == StudentId).FirstOrDefault();

        }

        internal void SetStudentPickedUp(CounslerModel counsler, string pickerName)
        {

            this.PickUp = new CheckedInOutModel() { ByWhom = pickerName, CounslerId = counsler.ID, When = DateTime.Now, IsByOther = IsPickedByOther(pickerName) };
            DataAccess.StudentPickedUp(counsler.ID, this.ID, pickerName, PickUp.IsByOther);
        }

        internal void SetStudentCheckedIn(CounslerModel counsler)
        {
            this.CheckedIn = new CheckedInOutModel() { CounslerId = counsler.ID, When = DateTime.Now };
            DataAccess.StudentCheckedIn(counsler.ID, this.ID);
        }

        public static bool IsPickedByOther(string picker)
        {
            if (picker != null)
                return picker.ToLower() == "other";
            return false;
        }
    }

    public class CheckedInOutModel
    {
        public int CounslerId { get; set; }
        public string ByWhom { get; set; }
        public DateTime When { get; set; }
        public bool IsByOther { get; set; }
    }

    public class StudentsCheckedInOutModel : CheckedInOutModel
    {
        public int StuedntId { get; set; }
    }
}