using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    [Serializable]
    public class BranchModel
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public List<StudentModel> StudentsList { get; set; }
        public List<string> OptionalGrades { get; set; }
        public List<string> OptionalClasses { get; set; }
        public List<string> OptionalHealthIssues { get; set; }


        public string PrincipalName { get; set; }
        public string PrincipalNUmber { get; set; }

    }
}