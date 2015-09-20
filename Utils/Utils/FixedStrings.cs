using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class FixedStrings
    {
        public const string StudentID = "Identification Number:";
        public const string FirstName = "First Name (English):";
        public const string LastName = "Last Name (English):";
        public const string GradeNClass = "Grade and Class:";
        public const string HealthIssues = "Additional Useful Information (including health conditions, allergies and sensitivities, request for specific vacation day):";
        public const string Parent1Name = "Mother's Name:";
        public const string Parent1Num = "Mother's Cell Phone:";
        public const string Parent1Email = "E-mail Address:";
        public const string Parent2Name = "Father's Name:";
        public const string Parent2Num = "Father's Cell Phone:";
        public const string Parent2Email = "Additional E-mail Address:";

        public const string HomeNum = "Home Phone:";
        public const string Gender = "Gender";
        public const string BirthDay = "Date of Birth (dd/mm/yyyy):";
        public const string Address = "Address:";
        public const string PickUpOptions = "Other Adults Allowed to Pick Up Your Child/Children:";


        public  string Gan_Hova = "Gan Hova";
        public string Gan_Trom_Hova = "Gan Trom Hova";

        public char[] pickupSeperators = new char[]{'\n',',','\r','/',';'};
        public List<string> IgnorePicks = new List<string>{ "&", "", @"\"};


        public int Column_StudentID;
        public int Column_FirstName;
        public int Column_LastName;
        public int Column_GradeNClass;
        public int Column_HealthIssues;
        public int Column_Parent1Name;
        public int Column_Parent1Num;
        public int Column_Parent1Email;
        public int Column_Parent2Name;
        public int Column_Parent2Num;
        public int Column_HomeNum;
        public int Column_Gender;
        public int Column_BirthDay;
        public int Column_Address; 
        public int Column_Parent2Email;
        public int Column_PickUpOptions;
        internal void setValue(string str, int column)
        {
            switch (str)
            {
                case StudentID:
                    Column_StudentID = column;
                    break;
                case FirstName:
                    Column_FirstName = column;
                    break;
                case LastName:
                    Column_LastName = column;
                    break;
                case GradeNClass:
                    Column_GradeNClass = column;
                    break;
                case HealthIssues:
                    Column_HealthIssues = column;
                    break;
                case Address:
                    Column_Address = column;
                    break;
                case BirthDay:
                    Column_BirthDay = column;
                    break;
                case Gender:
                    Column_Gender = column;
                    break;
                case Parent1Name:
                    Column_Parent1Name = column;
                    break;
                case Parent1Num:
                    Column_Parent1Num = column;
                    break;
                case Parent1Email:
                    Column_Parent1Email = column;
                    break;
                case Parent2Name:
                    Column_Parent2Name = column;
                    break;
                case HomeNum:
                    Column_HomeNum = column;
                    break;
                case Parent2Num:
                    Column_Parent2Num = column;
                    break;
                case PickUpOptions:
                    Column_PickUpOptions = column;
                    break;
                case Parent2Email:
                    Column_Parent2Email = column;
                    break;
            }
        }



    }
}
