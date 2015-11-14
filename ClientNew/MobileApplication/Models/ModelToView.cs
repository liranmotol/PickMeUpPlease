using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    public class StudentLightModelToView
    {
        public List<StudentLight> StudentsLight{ get; set; }
        public CounslerModel Counsler{ get; set; }

        public StudentLightModelToView(List<StudentLight> StudentsLight, CounslerModel Counsler)
        {
            this.Counsler = Counsler;
            this.StudentsLight=StudentsLight;
        }
    }

    public class CounslerInfoModelToView
    {
        public CounslerModel Counsler { get; set; }
        //public List<string> OptionalGrades { get; set; }
        //public List<string> OptionalClasses { get; set; }
        public CounslerInfoModelToView(CounslerModel Counsler)
        {
            this.Counsler = Counsler;
        }
        
    }

}