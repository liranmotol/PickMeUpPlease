using MobileApplication.Hndlers;
using MobileApplication.Models;
using MobileApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.DAL
{
    public class DataAccess
    {
        //TODO - IMPORTANT - add try cactch to each one of the methods

        internal static List<contacts> GetContacts()
        {
            return ApplicationContext.Instnace.contextInstance.contacts.ToList();
        }

        internal static void StudentCheckedIn(int CounslerId, int StudentId)
        {
            ApplicationContext.Instnace.contextInstance.students_checkin.Add
                (new students_checkin()
                {
                    hour_date = DateTime.Now,
                    set_coundler_id = CounslerId,
                    student_concacts_id = StudentId
                });
            ApplicationContext.Instnace.contextInstance.SaveChanges();
        }

        internal static void StudentPickedUp(int CounslerId, int StudentId, string PickerName, bool IsByOther)
        {
            ApplicationContext.Instnace.contextInstance.students_pickup.Add
                (new students_pickup()
                {
                    hour_date = DateTime.Now,
                    set_coundler_id = CounslerId,
                    student_concacts_id = StudentId,
                    is_by_other = IsByOther,
                    picker_name = (PickerName.Length>48)?PickerName.Substring(0,47):PickerName
                });
            ApplicationContext.Instnace.contextInstance.SaveChanges();
        }

        internal static List<CounslerModel> GetCounslersData()
        {
            List<CounslerModel> list = new List<CounslerModel>();
            ApplicationContext.Instnace.contextInstance.counslers.ToList().ForEach(c =>
            {
                CounslerModel tempCounsler = new CounslerModel()
                {
                    Birthday = c.birthday,
                    ID = c.id,
                    FirstName = c.first_name,
                    LastName = c.last_name,
                    UserName = c.usernmae,
                    DefaultGrade = c.default_grade,
                    DefaultClass = c.default_class,
                    WhereAmIDic = new Dictionary<int, string>() {
                    {1,"some activity" },{2,"some cooler activity" },{3,"boring activity" },{4,"AWSOME activity" },{5,"Homework yay activity" }
                    },
                    PhoneNumber=c.phone_mobile
                };
                try
                {
                    tempCounsler.AllowedBranchedIds = c.allowed_branches.Split(',').Select(branch => Convert.ToInt32(branch)).ToList();
                }
                catch (Exception ex)
                {
                    Logger.WriteToLog(LogLevel.error, "GetCounslersData converting branch ids", ex);
                }
                list.Add(tempCounsler);

            });
            return list;
        }

        internal static List<BranchModel> GetBranchesData()
        {
            List<BranchModel> branches = new List<BranchModel>();
            ApplicationContext.Instnace.contextInstance.branches.ToList().ForEach(b =>
            {
                var priniciple = InMemoryHandler.GetContactById(b.principle_contacts_id);
                var contactA = InMemoryHandler.GetContactById(b.contact_a_contacts_id);
                var contactB = InMemoryHandler.GetContactById(b.contact_b_contacts_id);
                BranchModel tempBranch = new BranchModel()
                {
                    BranchId = b.id,
                    BranchName = b.name,
                    PrincipalName = priniciple.first_name + " " + priniciple.last_name,
                    PrincipalNUmber = priniciple.phone_home
                };

                branches.Add(tempBranch);
            });
            return branches;
        }

        internal static List<StudentModel> GetStudentsData()
        {
            List<StudentModel> students = new List<StudentModel>();
            ApplicationContext.Instnace.contextInstance.students.ToList().ForEach(s =>
            {

                CheckedInOutModel checkedIn = InMemoryHandler.Today_CheckedIn.Where(stud => stud.StuedntId == s.id).FirstOrDefault();
                CheckedInOutModel pickedUp = InMemoryHandler.Today_PickedUp.Where(stud => stud.StuedntId == s.id).FirstOrDefault();


                StudentModel student = new StudentModel
                {
                    StudentUserID = s.user_id,
                    BirthDay = s.birthday?? DateTime.MinValue,
                    BranchId = s.branch_id ?? 0,
                    FirstName = s.first_name,
                    LastName = s.last_name,
                    SClass = s.@class,
                    Grade = s.grade,
                    HomeNum = s.phone_home,
                    Img = s.image,
                    ID = s.id,
                    PickUpOptions = (s.pick_up_options != null) ? s.pick_up_options.Split(',').ToList() : new List<string>(),
                    Gender = Utils.Utils.GetGender(s.gender),
                    CheckedIn = checkedIn,
                    PickUp = pickedUp,
                    Parent1Email = s.parent_a_email,
                    Parent1Num = s.parent_a_phone_mobile,
                    Parent1Name = s.parent_a_first_name + " " + s.parent_a_last_name,
                    Parent2Name = s.parent_b_first_name + " " + s.parent_b_last_name,
                    Parent2Email = s.parent_b_email,
                    Parent2Num = s.parent_b_phone_mobile,
                    HealthIssuesString =s.health_issues,
                    Address = s.address

                };
              

                students.Add(student);
            });
            return students.ToList();
        }

        internal static List<StudentsCheckedInOutModel> GetTodayCheckedIn()
        {
            List<StudentsCheckedInOutModel> temp = ApplicationContext.Instnace.contextInstance.students_checkin.
                Where(s => s.hour_date > DateTime.Today).
                Select(s => new StudentsCheckedInOutModel()
                {
                    CounslerId = s.set_coundler_id,
                    When = s.hour_date,
                    StuedntId = s.student_concacts_id
                }
                ).ToList();
            return temp;
        }

        internal static List<StudentsCheckedInOutModel> GetTodayPickedUp()
        {
            List<StudentsCheckedInOutModel> temp = ApplicationContext.Instnace.contextInstance.students_pickup.
              Where(s => s.hour_date > DateTime.Today).
              Select(s => new StudentsCheckedInOutModel()
              {
                  ByWhom = s.picker_name,
                  IsByOther = s.is_by_other,
                  CounslerId = s.set_coundler_id,
                  When = s.hour_date,
                  StuedntId = s.student_concacts_id
              }
              ).ToList();
            return temp;
        }


        #region tests


        private static List<string> getPickUp(int rand)
        {
            List<string> l = new List<string>();
            if (rand < 10)
            {
                l.Add(Boys[rand]);
                l.Add(Girls[rand]);
                return l;
            }
            if (rand < 30)
            {
                l.Add(Boys[rand]);
                l.Add(Girls[rand]);
                l.Add(Boys[rand - 1]);
                l.Add(Girls[rand - 1]);
                return l;
            }
            if (rand < 40)
            {
                l.Add(Boys[rand]);
                l.Add(Girls[rand]);
                return l;
            }
            return l;
        }

        private static List<string> getHealth(int rand)
        {
            List<string> l = new List<string>();
            if (rand < 10)
                l.Add("GLUTEN");
            else if (rand < 20)
                l.Add("SUGAR");
            else if (rand < 40)
            {
                l.Add("GLUTEN");
                l.Add("SUGAR");

            }
            return l;
        }

        private static int getSclass(int rand)
        {

            if (rand < 10)
                return 1;
            if (rand < 20)
                return 2;
            if (rand < 30)
                return 3;
            if (rand < 40)
                return 4;
            return 5;
        }

        private static string getGrade(int rand)
        {
            if (rand < 10)
                return "GAN";
            if (rand < 20)
                return "A";
            if (rand < 30)
                return "B";
            if (rand < 40)
                return "C";
            return "D";

        }

        private static string[] Boys = 
        {
        "Liam	  "	,
"Noah	  "	        ,
"Ethan	  "	        ,
"Mason		"	    ,
"Logan		"    	,	
"Lucas		"	    ,
"Jackson	"	    ,		
"Jacob	  "	        ,
"Oliver	  "	        ,
"Aiden	  "	        ,
"Elijah	  "	        ,
"James	  "	        ,
"Alexandei"    		,
"Benjamin"    		,
"Luke	  "	        ,
"Jack	  "	        ,
"Daniel	  "	        ,
"William	"   	,	
"Michael	"   	,	
"Gabriel	"   	,	
"Henry	  "	        ,
"Owen	  "	        ,
"Carter	  "	        ,
"Wyatt		"	    ,
"Caleb	  "	        ,
"Gordie	  "	        ,
"Matthew	"	    ,		
"Ryan	  "	        ,
"Jayden		"    	,	
"Nathan	  "	        ,
"Isaac	  "	        ,
"Andrew	  "	        ,
"Joshua	  "	        ,
"Connor	  "	        ,
"Eli	"		    ,
"David		"    	,	
"Hunter	  "	        ,
"Dylan	  "	        ,
"Samuel	  "	        ,
"Sebastia "         ,
        };


        private static string[] Girls = 
            {"Emma	      ",
"Olivia	      ",
"Sophia	      ",
"Ava	      ",
"Isabella     ",
"Mia	      ",
"Charlotte    ",
"Amelia	      ",
"Emily	      ",
"Madison	  ",
"Harper	      ",
"Ella	      ",
"Abiga     "   ,
"Lily      "   ,
"Avery	      ",
"Chloe	      ",
"Sofia	      ",
"Evelyn	      ",
"Ellie	      ",
"Aubrey	      ",
"Grace	      ",
"Audrey	      ",
"Aria	      ",
"Zoe	      ",
"Hannah	      ",
"Zoey	      ",
"Elizabeth    ",
"Nora	      ",
"Scarlett     ",
"Addison	  ",
"Mila	      ",
"Layla	      ",
"Lillian	  ",
"Lucy	      ",
"lie	      ",
"Brooklyn     ",
"Riley	      ",
"Violet	      ",
"Claire	      ",
"Alice     "};


        #endregion tests





        internal static bool UpdateDefaultClassAndGrade(int CounslerId, string Grade, string SClass)
        {
            var counsler = ApplicationContext.Instnace.contextInstance.counslers.Where(c => c.id == CounslerId).FirstOrDefault();
            if (counsler != null)
            {
                counsler.default_class = SClass;
                counsler.default_grade = Grade;

            }
               
            ApplicationContext.Instnace.contextInstance.SaveChanges();
            return true;
        }
    }
}