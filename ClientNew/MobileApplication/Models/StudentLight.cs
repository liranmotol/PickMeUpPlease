using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    [Serializable]
    public class StudentLight
    {
        public int ID { get { return this.StudentFull.ID; } }
        public string FirstName { get { return this.StudentFull.FirstName; } }
        public string LastName { get { return this.StudentFull.LastName; } }
        public string Grade { get { return this.StudentFull.Grade; } }
        public string SClass { get { return this.StudentFull.SClass; } }
        public DateTime BirthDay { get { return this.StudentFull.BirthDay; } }
        public bool IsPickedUp { get { return this.StudentFull.IsPickedUp; } }
        public bool IsCheckedIn { get { return this.StudentFull.IsCheckedIn; } }
        public bool IsDefaultClass { get; set; }


        private StudentModel StudentFull;

        public StudentLight(StudentModel studentFull)
        {
            this.StudentFull = studentFull;          
        }


        internal static List<StudentLight> BuildStudentLight(List<StudentModel> list)
        {
            if (list != null)
            {
                List<StudentLight> temp = list.Select(s =>
                {
                    return new StudentLight(s);
                }).ToList();
                return temp;
            }
            return new List<StudentLight>();
        }
    }
}