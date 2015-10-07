using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    [Serializable]
    public class StudentModel
    {
        public string StudentID { get; set; }
        public int StudentContactID { get; set; }
        public string Img { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public string SClass { get; set; }
        public string PickUpFrom { get; set; }
        public List<string> HealthIssues { get; set; }
        public string HealthIssuesString { get; set; }

        public CheckedInOutModel CheckedIn { get; set; }
        public CheckedInOutModel PickUp { get; set; }
        public List<string> PickUpOptions { get; set; }
        public bool IsPickedUp { get; set; }
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
        public StudentModel()
        {
            HealthIssues = new List<string>();
            CheckedIn = new CheckedInOutModel();
            PickUp = new CheckedInOutModel();
            PickUpOptions = new List<string>();
        }

        public DateTime LastUpdateTime { get; set; }
        public int BranchId { get; set; }

    }

    public class CheckedInOutModel
    {
        public int CounslerContactId { get; set; }
        public string ByWhom { get; set; }
        public string When { get; set; }
        public bool IsByOther { get; set; }
    }

    public class StudentsCheckedInOutModel : CheckedInOutModel
    {
        public int StuedntContactId { get; set; }
    }
}