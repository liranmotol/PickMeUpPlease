﻿using Server.Models;
using Server.Utils;
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
            pickmepleasedbEntities.Instnace.counslers.ToList().ForEach(c =>
                {
                    contacts counslerBase = Utils.Utils.GetContactByContactId(c.counsler_concacts_id);
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
            pickmepleasedbEntities.Instnace.branches.ToList().ForEach(b =>
                { 
                    var priniciple = Utils.Utils.GetContactByContactId(b.principle_contacts_id);
                    var contactA= Utils.Utils.GetContactByContactId (b.contact_a_contacts_id);
                    var contactB= Utils.Utils.GetContactByContactId (b.contact_b_contacts_id);
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
            //ApplicationContext.Instnace.Students;
            return null;
        }






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



    }
}