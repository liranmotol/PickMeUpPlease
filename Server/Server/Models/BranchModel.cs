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

            //List<int> allowedBranches = counsler.AllowedBranchedIds;
            counsler.AllowedBranchedIds.ForEach(allowed =>
            {
                var branchAllowed = InMemoryHandler.Branches.Where(b => b.BranchId == allowed);
                if (branchAllowed != null && branchAllowed.Count() > 0)
                {
                    BranchModel branch = branchAllowed.First();

                    List<StudentModel> tempList = branch.GetUpdateStundetsInfo(LastSyncTime);

                    BranchModel temp = new BranchModel()
                    {
                        BranchId = branch.BranchId,
                        BranchName = branch.BranchName,
                        PrincipalName = branch.PrincipalName,
                        PrincipalNUmber = branch.PrincipalNUmber
                    };

                    //if (tempList != null)
                    //{
                    //    var grades = tempList.Select(s => s.Grade).Distinct();
                    //    var classes = tempList.Select(s => s.SClass).Distinct();
                    //    temp.StudentsList = tempList.OrderBy(s => s.LastName).ToList();
                    //    temp.OptionalClasses = classes.ToList();
                    //    temp.OptionalGrades = grades.ToList();
                    //    //var Health = tempList.Select(s => s.HealthIssues).Distinct();
                    //    temp.OptionalHealthIssues = null;// Health.ToList();
                    //}
                    response.Branches.Add(temp);
                }
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