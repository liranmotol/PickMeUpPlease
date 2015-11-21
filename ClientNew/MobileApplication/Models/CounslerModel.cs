using MobileApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    [Serializable]
    public class CounslerModel
    {
        public int ID { get; set; }
        public string CounslerUserID { get; set; }
        public string UserName { get; set; }
        public string Img { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime CheckedIn { get; set; }
        //public DateTime CheckedOut { get; set; }
        public DateTime? Birthday { get; set; }
        public List<int> AllowedBranchedIds { get; set; }
        public string Gender { get; set; }

        public string PhoneNumber { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }

        public string DefaultClass { get; set; }
        public string DefaultGrade { get; set; }

      
        public List<CCounslersScheduleModel> WhereAmI { get; set; }


        internal bool SetDefaultGradeAndClass(int CounslerId, string Grade, string SClass)
        {
            bool result = false;
            if (DataAccess.UpdateDefaultClassAndGrade(CounslerId, Grade, SClass))
            {
                this.DefaultClass = SClass;
                this.DefaultGrade = Grade;
                result = true;
            }
            return result;

        }

        internal string GetCounslerName()
        {
            return FirstName + " " + LastName;
        }
    }

    [Serializable]

    public class CCounslersScheduleModel
    {
        public int Day { get; set; }
        public int Hour { get; set; }
        public string Acticity{ get; set; }
        public string Location{ get; set; }
        public string Group{ get; set; }
        public string Comment { get; set; }
        public string HourDescription{ get; set; }



    }
}