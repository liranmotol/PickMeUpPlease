using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DAL
{
    public class DataAccess
    {


        internal static List<CounslerModel> GetCounslersData()
        {
            List<CounslerModel> list = new List<CounslerModel>();
            CounslerModel c = new CounslerModel() { AllowedBranchedIds = new List<int>() { 1, 2, 3, 4 }, UserName = "liran", FirstName = "Liran", LastName = "Moto", CounslerID = 1, };
            CounslerModel c1 = new CounslerModel() { AllowedBranchedIds = new List<int>() { 1, 2, 3, 4 }, UserName = "lily", FirstName = "Lily", LastName = "Motola", CounslerID = 2, };
            list.Add(c); list.Add(c1);
            return list;
        }

        internal static List<BranchModel> GetBranchesData()
        {
            BranchModel b = new BranchModel() { BranchId = 1, BranchName = "First B" };
            BranchModel b2 = new BranchModel() { BranchId = 2, BranchName = "Second B" };
            BranchModel b5 = new BranchModel() { BranchId = 5, BranchName = "Fifth B" };
            b.StudentsList = BuildList(b.BranchId);
            b2.StudentsList = BuildList(b2.BranchId);
            b5.StudentsList = BuildList(b5.BranchId);

            var list = new List<BranchModel>() { b, b2, b5 };
            return list;
        }






        //TESTING
        private static List<StudentModel> BuildList(int p)
        {
            List<StudentModel> li = new List<StudentModel>();
            for (int i = 0; i < 100; i++)
            {
                int rand = new Random().Next(0, Boys.Count() - 1);
                string grade = getGrade(rand);
                int Sclass = getSclass(rand);
                var health = getHealth(rand);
                var pickUpOptions2 = getPickUp(rand);
                StudentModel s = new StudentModel()
                {
                    BirthDay = DateTime.Now,
                    BirthDayString = DateTime.Now.ToShortDateString(),
                    CheckedIn = new CeckedInOutModel(),
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
                    IsPickedUp = false,
                    LastUpdateTime = DateTime.Now,
                    Parent1Email = "liran@gmail.com",
                    Parent1Name = Boys[rand],
                    Parent2Name = Girls[rand],
                    Parent1Num = "052-1234567",
                    Parent2Num = "052-7654321",
                    PickUp = new CeckedInOutModel(),
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
            }
            if (rand < 30)
            {
                l.Add(Boys[rand]);
                l.Add(Girls[rand]);
                l.Add(Boys[rand - 1]);
                l.Add(Girls[rand - 1]);
            }
            if (rand < 40)
            {
                l.Add(Boys[rand]);
                l.Add(Girls[rand]);
            }
            return l;
        }

        private static List<string> getHealth(int rand)
        {
            List<string> l = new List<string>();
            if (rand < 10)
                l.Add("GLUTEN");
            if (rand < 20)
                l.Add("SUGAR");
            if (rand < 40)
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

    }
}