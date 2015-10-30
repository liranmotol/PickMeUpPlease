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
                    picker_name = PickerName
                });
            ApplicationContext.Instnace.contextInstance.SaveChanges();
        }

        internal static List<CounslerModel> GetCounslersData()
        {
            List<CounslerModel> list = new List<CounslerModel>();
            ApplicationContext.Instnace.contextInstance.counslers.ToList().ForEach(c =>
            {
                contacts counslerBase = InMemoryHandler.GetContactById(c.counsler_concacts_id);
                if (c == null)
                {
                    return;
                }
                CounslerModel tempCounsler = new CounslerModel()
                {
                    Birthday = c.birthday,
                    CounslerID = counslerBase.id,
                    FirstName = counslerBase.first_name,
                    LastName = counslerBase.last_name,
                    UserName = c.usernmae
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
                contacts contact = InMemoryHandler.GetContactById(s.student_concacts_id);
                contacts parentA = InMemoryHandler.GetContactById(s.parent_a_contacts_id);
                contacts parentB = InMemoryHandler.GetContactById(s.parent_b_contacts_id);

                if (contact == null)
                {
                    return;
                }

                CheckedInOutModel checkedIn = InMemoryHandler.Today_CheckedIn.Where(stud => stud.StuedntContactId == contact.id).FirstOrDefault();
                CheckedInOutModel pickedUp = InMemoryHandler.Today_PickedUp.Where(stud => stud.StuedntContactId == contact.id).FirstOrDefault();


                StudentModel student = new StudentModel
                {
                    StudentContactID = contact.id,
                    BirthDay = s.birthday ?? DateTime.MinValue,
                    BranchId = s.branch_id ?? 0,
                    FirstName = contact.first_name,
                    LastName = contact.last_name,
                    SClass = s.@class,
                    Grade = s.grade,
                    HomeNum = contact.phone_home,
                    Img = contact.image,
                    StudentID = contact.user_id,
                    PickUpOptions = (s.pick_up_options != null) ? s.pick_up_options.Split(',').ToList() : null,
                    Gender = Utils.Utils.GetGender(s.gender),
                    CheckedIn = checkedIn,
                    PickUp = pickedUp,
                };
                if (parentA != null)
                {
                    student.Parent1Email = parentA.email_1;
                    student.Parent1Name = parentA.first_name + " " + parentA.first_name;
                    student.Parent1Num = parentA.phone_mobile;
                }
                if (parentB != null)
                {
                    student.Parent2Email = parentB.email_1;
                    student.Parent2Name = parentB.first_name + " " + parentA.first_name;
                    student.Parent2Num = parentB.phone_mobile;
                }

                students.Add(student);
            });
            return students.Distinct().ToList();
        }

        internal static List<StudentsCheckedInOutModel> GetTodayCheckedIn()
        {
            List<StudentsCheckedInOutModel> temp = ApplicationContext.Instnace.contextInstance.students_checkin.
                Where(s => s.hour_date > DateTime.Today).
                Select(s => new StudentsCheckedInOutModel()
                {
                    CounslerContactId = s.set_coundler_id,
                    When = s.hour_date,
                    StuedntContactId = s.student_concacts_id
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
                  CounslerContactId = s.set_coundler_id,
                  When = s.hour_date,
                  StuedntContactId = s.student_concacts_id
              }
              ).ToList();
            return temp;
        }


        #region tests


        //TESTING
        private static List<StudentModel> BuildList(int p)
        {
            List<StudentModel> li = new List<StudentModel>();

            for (int i = 0; i < 100; i++)
            {

                int rand = new Random(i).Next(0, Boys.Count() - 1);
                string grade = getGrade(rand);
                int Sclass = getSclass(rand);
                var health = getHealth(rand);
                var pickUpOptions2 = getPickUp(rand);
                StudentModel s = new StudentModel()
                {
                    BirthDay = DateTime.Now,
                    BirthDayString = DateTime.Now.ToShortDateString(),
                    CheckedIn = new CheckedInOutModel(),
                    FirstName = Boys[rand],
                    LastName = Girls[rand],
                    Gender = (rand > 20) ? "Male" : "Female",
                    Grade = grade,
                    SClass = Sclass.ToString(),
                    StudentID = i.ToString(),
                    HealthIssues = health,
                    HealthIssuesString = string.Join(",", health),
                    HomeNum = "03-5555555",
                    Img = "",
                    LastUpdateTime = DateTime.Now,
                    Parent1Email = "liran@gmail.com",
                    Parent1Name = Boys[rand],
                    Parent2Name = Girls[rand],
                    Parent1Num = "052-1234567",
                    Parent2Num = "052-7654321",
                    PickUp = new CheckedInOutModel(),
                    PickUpFrom = "nada",
                    PickUpOptions = pickUpOptions2
                };
                li.Add(s);
            }
            return li;
        }

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




    }
}