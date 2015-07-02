using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    [Serializable]
    public class BranchModel
    {
        public int BranchId { get; set; }
        public string BranchName{ get; set; }
        public List<StudentModel> StudentsList { get; set; }
        public List<string> OptionalGrades { get; set; }
        public List<string> OptionalClasses { get; set; }
        public List<string> OptionalHealthIssues { get; set; }


        public string PrincipalName{ get; set; }
        public string PrincipalNUmber { get; set; }
        



        internal  List<StudentModel> GetUpdateStundetsInfo(DateTime LastSyncTime)
        {
            List<StudentModel> temp=StudentsList.Where(s => s.LastUpdateTime>LastSyncTime).ToList();
            return temp;
        }

        internal void UpdateBranch()
        {
            OptionalGrades = StudentsList.Select(s => s.Grade).Distinct().ToList();
            OptionalClasses = StudentsList.Select(s => s.SClass).Distinct().ToList();
            
            List<string> tempHealth= new List<string>();
            StudentsList.ForEach(s=>
                {
                    if (s.HealthIssues != null)
                        tempHealth.AddRange(s.HealthIssues);
                });

            OptionalHealthIssues = tempHealth.Distinct().ToList();

        }
    }
}