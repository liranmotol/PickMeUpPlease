using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class StudentsModel
    {
        public string StudentID { get; set; }
        public string Img{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Grade{ get; set; }
        public string SClass{ get; set; }
        public string PickUpFrom{ get; set; }
        public List<string> HealthIssues { get; set; }
        public string HealthIssuesString { get; set; }

        public CeckedInOutModel CheckedIn{ get; set; }
        public CeckedInOutModel PickUp{ get; set; }
        public List<string> PickUpOptions{ get; set; }
        public bool IsPickedUp{ get; set; }
        public string Parent1Name{ get; set; }
        public string Parent1Num{ get; set; }
        public string Parent1Email { get; set; }
        public string Parent2Name{ get; set; }
        public string Parent2Num{ get; set; }

        public string HomeNum { get; set; }

        public string Gender{ get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthDayString { get; set; }
        public StudentsModel()
        {
            HealthIssues = new List<string>();
            CheckedIn = new CeckedInOutModel();
            PickUp = new CeckedInOutModel();
            PickUpOptions = new List<string>();
        }

    }

    public class CeckedInOutModel
    {
        public string ByWhom{ get; set; }
        public string When{ get; set; }
    }



}
