using Newtonsoft.Json;
using Server.Hndlers;
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
        public string BranchName { get; set; }
        public List<StudentModel> StudentsList { get; set; }
        public List<string> OptionalGrades { get; set; }
        public List<string> OptionalClasses { get; set; }
        public List<string> OptionalHealthIssues { get; set; }


        public string PrincipalName { get; set; }
        public string PrincipalNUmber { get; set; }




        internal List<StudentModel> GetUpdateStundetsInfo(DateTime LastSyncTime)
        {
            List<StudentModel> temp = InMemoryHandler.Students.Where(s => s.BranchId == this.BranchId && s.LastUpdateTime >= LastSyncTime).ToList();
            return temp;
        }

        internal void UpdateBranch()
        {
            OptionalGrades = StudentsList.Select(s => s.Grade).Distinct().ToList();
            OptionalClasses = StudentsList.Select(s => s.SClass).Distinct().ToList();

            List<string> tempHealth = new List<string>();
            StudentsList.ForEach(s =>
                {
                    if (s.HealthIssues != null)
                        tempHealth.AddRange(s.HealthIssues);
                });

            OptionalHealthIssues = tempHealth.Distinct().ToList();

        }

        internal static ResponseGetBranchInfo GetBranchesInfo(CounslerModel counsler, DateTime LastSyncTime)
        {
            ResponseGetBranchInfo response = new ResponseGetBranchInfo();
            response.Branches = new List<BranchModel>(); //InMemoryHandler.Branches.Where(b => allowedBranches.Contains(b.BranchId)).ToList();
            //TODO refresh the students here
            counsler.AllowedBranchedIds.ForEach(allowed =>
            {
                response.Branches.AddRange(InMemoryHandler.Branches.Where(b => b.BranchId == allowed).ToList());
            });
            return response;
        }

        internal void BuildBranch(List<StudentModel> Students)
        {
            this.StudentsList = Students.Where(s => s.BranchId == this.BranchId).OrderBy(s => s.LastName).ToList();
            var grades = this.StudentsList.Select(s => s.Grade).Distinct();
            var classes = this.StudentsList.Select(s => s.SClass).Distinct();

            this.OptionalClasses = classes.ToList();
            this.OptionalGrades = grades.ToList();
            //var Health = tempList.Select(s => s.HealthIssues).Distinct();
            this.OptionalHealthIssues = null;// Health.ToList();
        }
    }
}