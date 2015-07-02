using Server.DAL;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Web;

namespace Server.Hndlers
{
    public class InMemoryHandler
    {

        private static List<CounslerModel> Counslers;
        private static List<BranchModel> Branches;


        private static Timer staticDataRefreshTimer;
        private static object _init_locker = new object();
        #region initialization
        static InMemoryHandler()
        {
            Initialize(false);
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0, 0);
            startDate = startDate.AddHours(1);
            TimeSpan ts = startDate.Subtract(now);

            staticDataRefreshTimer = new System.Timers.Timer(ts.TotalMilliseconds);
            staticDataRefreshTimer.AutoReset = true;
            staticDataRefreshTimer.Elapsed += new ElapsedEventHandler(InitializeRefreshTimer);
            staticDataRefreshTimer.Start();
        }

        private static void InitializeRefreshTimer(object sender, System.Timers.ElapsedEventArgs eee)
        {
            staticDataRefreshTimer.Stop();
            staticDataRefreshTimer.Close();
            staticDataRefreshTimer = new Timer(TimeSpan.FromMinutes(5).TotalMilliseconds);
            staticDataRefreshTimer.AutoReset = true;
            staticDataRefreshTimer.Elapsed += new ElapsedEventHandler(ReInitialize);
            staticDataRefreshTimer.Start();

            BackgroundInitialize();
        }

        public static void Initialize(bool force)
        {
            lock (_init_locker)
            {
                if (force)
                {
                    BackgroundInitialize();
                }
                else
                {
                    Initialize();
                }
            }
        }


        private static void ReInitialize(object sender, System.Timers.ElapsedEventArgs eee)
        {
            BackgroundInitialize();
        }
        private static void BackgroundInitialize()
        {
            Task.Run(() => Initialize());
        }
        #endregion initialization

        private static void Initialize()
        {
            Counslers = DataAccess.GetCounslersData();
            Branches = DataAccess.GetBranchesData();
        }



        public static void UpdateCounslerToken(string token, CounslerModel counsler)
        {
            SecurityMemHandler.UpdateCounslerToken(token, counsler);
        }

        internal static CounslerModel GetCounslerByUserName(string userName)
        {
            var tempCoun = Counslers.Where(c => c.UserName == userName);
            if (tempCoun !=null && tempCoun .Count()>0)
                return tempCoun.First();
            return null;
        }
        internal static bool IsTokenValid(string token)
        {
            return SecurityMemHandler.IsTokenValid(token) > 0;
        }



        internal static CounslerModel GetCounslerByToken(string token)
        {
            int CounslerId = SecurityMemHandler.IsTokenValid(token);
            if (CounslerId > 0)
            {
                return Counslers.Where(c => c.CounslerID == CounslerId).First();
            }
            return null;
        }

        internal static ResponseGetBranchInfo GetBranchesInfo(CounslerModel counsler, DateTime LastSyncTime)
        {
            ResponseGetBranchInfo response = new ResponseGetBranchInfo();
            response.Branches = new List<BranchModel>();

            List<int> allowedBranches = counsler.AllowedBranchedIds;
            counsler.AllowedBranchedIds.ForEach(allowed =>
                {
                    var branchAllowed = Branches.Where(b => b.BranchId == allowed);
                    if (branchAllowed != null && branchAllowed.Count() > 0)
                    {
                        BranchModel branch = branchAllowed.First();

                        List<StudentModel> tempList = branch.GetUpdateStundetsInfo(LastSyncTime);
                        BranchModel temp = new BranchModel() { BranchId = branch.BranchId, BranchName = branch.BranchName, StudentsList = tempList };
                        response.Branches.Add(temp);
                    }
                });
            return response;
        }

        internal static void StudentPickedUp(string StudentId, string PickerName, int BranchId)
        {
            BranchModel branch = Branches.Where(b => b.BranchId == BranchId).First();
            StudentModel student = branch.StudentsList.Where(s => s.StudentID == StudentId).First();
            student.LastUpdateTime = DateTime.Now;
            student.PickUp = new CeckedInOutModel() { ByWhom = PickerName, When = DateTime.Now.ToString() };
            student.IsPickedUp = true;

        }
    }
}