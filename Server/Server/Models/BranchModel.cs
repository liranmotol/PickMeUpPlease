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

        internal static ResponseGetBranchInfo GetBranchesInfo(CounslerModel counsler, DateTime LastSyncTime)
        {
            ResponseGetBranchInfo response = new ResponseGetBranchInfo();
            response.Branches = new List<BranchModel>(); //InMemoryHandler.Branches.Where(b => allowedBranches.Contains(b.BranchId)).ToList();

            //List<int> allowedBranches = counsler.AllowedBranchedIds;
            counsler.AllowedBranchedIds.ForEach(allowed =>
            {
                var branchAllowed =InMemoryHandler.Branches.Where(b => b.BranchId == allowed);
                if (branchAllowed != null && branchAllowed.Count() > 0)
                {
                    BranchModel branch = branchAllowed.First();

                    List<StudentModel> tempList = branch.GetUpdateStundetsInfo(LastSyncTime);
                    BranchModel temp = new BranchModel()
                    {
                        BranchId = branch.BranchId,
                        BranchName = branch.BranchName,
                        StudentsList = tempList.OrderBy(s => s.LastName).ToList(),
                        OptionalClasses = branch.OptionalClasses.OrderBy(c => c).ToList(),
                        OptionalGrades = branch.OptionalGrades.OrderBy(c => c).ToList(),
                        OptionalHealthIssues = branch.OptionalHealthIssues.OrderBy(c => c).ToList(),
                        PrincipalName = branch.PrincipalName,
                        PrincipalNUmber = branch.PrincipalNUmber
                    };
                    response.Branches.Add(temp);
                }
            });
            return response;
        }
    }
}