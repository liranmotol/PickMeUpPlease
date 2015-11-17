using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    public class GradeAndClass 
    {
        public string Grade { get; set; }
        public string SClass { get; set; }    

    }
    public class GradeAndClassComparer : IEqualityComparer<GradeAndClass>
    { 
        public bool Equals(GradeAndClass x, GradeAndClass y)
        {
            return x.Grade == y.Grade && x.SClass == y.SClass;
        }

        public int GetHashCode(GradeAndClass obj)
        {
            return (obj.Grade + obj.SClass).GetHashCode();
        }
    }
}