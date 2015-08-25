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

        public static List<CounslerModel> Counslers {get; private set;}
        public static List<BranchModel> Branches { get; private set; }
        public static List<StudentModel> Students { get; private set; }



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
            Students = DataAccess.GetStudentsData();
        }



        //public static void UpdateCounslerToken(string token, CounslerModel counsler)
        //{
        //    SecurityMemHandler.UpdateCounslerToken(token, counsler);
        //}

        internal static CounslerModel GetCounslerByUserName(string userName)
        {
            var tempCoun = Counslers.Where(c => c.UserName == userName);
            if (tempCoun !=null && tempCoun .Count()>0)
                return tempCoun.First();
            return null;
        }

   

        internal static void StudentPickedUp(string StudentId, string PickerName, int BranchId)
        {
            BranchModel branch = Branches.Where(b => b.BranchId == BranchId).First();
            StudentModel student = branch.StudentsList.Where(s => s.StudentID == StudentId).First();
            student.LastUpdateTime = DateTime.Now;
            student.PickUp = new CeckedInOutModel() { ByWhom = PickerName, When = DateTime.Now.ToString() };
            student.IsPickedUp = true;

        }

        internal static void GetAllCounslers()
        {
            var a = Counslers;
            var b= Branches;
            var s = Students;



        }
    }
}