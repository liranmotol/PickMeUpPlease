using MobileApplication.Hndlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{

    [Serializable]
    public class StudentCounslerModelToView
    {
        public StudentModel Student { get; set; }
        public CounslerModel Counsler { get; set; }

        public StudentCounslerModelToView(StudentModel Student, CounslerModel Counsler)
        {
            this.Counsler = Counsler;
            this.Student = Student;
        }
    }

     [Serializable]
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

     [Serializable]
    public class CounslerInfoModelToView
    {
        public CounslerModel Counsler { get; set; }
        public List<GradeAndClass> GradeAndClasses { get; set; }
        //public List<string> OptionalGrades { get; set; }
        //public List<string> OptionalClasses { get; set; }
        public CounslerInfoModelToView(CounslerModel Counsler,int BranchId=0)
        {
            this.Counsler = Counsler;
            this.GradeAndClasses=InMemoryHandler.GetAvaiableGradeAndClass(BranchId);
        }
        
    }


  


     [Serializable]
     public class CounslerBranchModelToView
     {
         public CounslerModel Counsler { get; set; }
         public BranchModel Branch { get; set; }
         //public List<string> OptionalGrades { get; set; }
         //public List<string> OptionalClasses { get; set; }
         public CounslerBranchModelToView(CounslerModel Counsler, BranchModel Branch)
         {
             if (Counsler == null)
                 Counsler = new CounslerModel();
             this.Counsler = Counsler;
             if (Branch == null)
                 Branch = new BranchModel();
             this.Branch = Branch;

         }

     }

}