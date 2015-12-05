using MobileApplication.DAL;
using MobileApplication.Models;
using MobileApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Web;

namespace MobileApplication.Hndlers
{
    public class InMemoryHandler
    {
        public static List<StudentsCheckedInOutModel> Today_CheckedIn { get; private set; }
        public static List<StudentsCheckedInOutModel> Today_PickedUp { get; private set; }

        public static List<contacts> Contacts { get; private set; }
        public static List<ClassPickUpModel> ClassPicks { get; private set; }

        public static List<CounslerModel> Counslers { get; private set; }
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
            Contacts = DataAccess.GetContacts();

            Today_PickedUp = DataAccess.GetTodayPickedUp();
            Today_CheckedIn = DataAccess.GetTodayCheckedIn();

            Counslers = DataAccess.GetCounslersData();
            Branches = DataAccess.GetBranchesData();
            Students = DataAccess.GetStudentsData();
            ClassPicks = DataAccess.GetClassPickUp();
            Branches.ForEach(b =>
            {
                b.BuildBranch(Students);
            });
        }

        internal static CounslerModel GetCounslerByUserName(string userName)
        {
            var tempCoun = Counslers.Where(c => c.UserName == userName);
            if (tempCoun != null && tempCoun.Count() > 0)
                return tempCoun.First();
            return null;
        }

        internal static CounslerModel GetCounslerById(int counslerId)
        {
            var tempCoun = Counslers.Where(c => c.ID == counslerId);
            if (tempCoun != null && tempCoun.Count() > 0)
                return tempCoun.First();
            return null;
        }

        internal static void StudentPickedUp(int CounslerId, int StudentContactId, string PickerName, bool IsByOther)
        {
            DataAccess.StudentPickedUp(CounslerId, StudentContactId, PickerName, IsByOther);
            //BranchModel branch = Branches.Where(b => b.BranchId == BranchId).First();
            StudentModel student = Students.Where(s => s.ID == StudentContactId).FirstOrDefault();
            if (student == null)
            {
                Logger.WriteToLog(LogLevel.error, "StudentPickedUp: Could not find student:" + StudentContactId);
                //TODO handle
                return;
            }
            student.LastUpdateTime = DateTime.Now;
            student.PickUp = new CheckedInOutModel() { ByWhom = PickerName, When = DateTime.Now, IsByOther = IsByOther, CounslerId = StudentContactId };
        }

        internal static void StudentCheckIn(int CounslerId, int StudentContactId)
        {
            DataAccess.StudentCheckedIn(CounslerId, StudentContactId);
            StudentModel student = Students.Where(s => s.ID == StudentContactId).FirstOrDefault();
            if (student == null)
            {
                Logger.WriteToLog(LogLevel.error, "StudentCheckIn: Could not find student:" + StudentContactId);
                //TODO handle
                return;
            }
            student.LastUpdateTime = DateTime.Now;
            student.CheckedIn = new CheckedInOutModel() { When = DateTime.Now, CounslerId = CounslerId };
        }


        internal static void GetAllCounslers()
        {
            var a = Counslers;
            var b = Branches;
            var s = Students;
        }

        internal static CounslerModel GetUserIdFromCounslerUserName(string userName)
        {
            var counsler = Counslers.Where(c =>
            {
                if (c.UserName != null)
                    return c.UserName.ToLower().Equals(userName.ToLower());
                return false;
            }
                ).FirstOrDefault();
            if (counsler != null)
                return counsler;
            return null;

        }

        internal static contacts GetContactById(int? contactId)
        {
            return Contacts.Where(c => c.id == contactId).FirstOrDefault();
        }

        internal static List<GradeAndClass> GetAvaiableGradeAndClass(int BranchId)
        {
            //get all the avaiable class and grades
            if (BranchId == 0)
            {
                var GradeAndClassCollection =
                    Students.Select(s =>
                        {
                            return new GradeAndClass() { Grade = s.Grade, SClass = s.SClass };
                        }).GroupBy(s => new { s.Grade, s.SClass }).Select(s=>s.First());
                return GradeAndClassCollection.ToList();
            }
            else
            {
                return
                Students.Where(s => s.BranchId == BranchId).Select(s =>
                {
                    return new GradeAndClass() { Grade = s.Grade, SClass = s.SClass };
                }).Distinct().ToList();
            }
        }
    }
}