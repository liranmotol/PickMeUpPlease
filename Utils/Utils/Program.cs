﻿

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            List<StudentModel> students = LoadStudents();
            //List<StudentModel> students = LoadStudentsJson();
            uploadStudentsToDb(students, 1);
            //AddBranches();
            //ReadCSV();

        }

        private static List<StudentModel> LoadStudentsJson()
        {
            string line;
            string temp = "";
            System.IO.StreamReader file =
        new System.IO.StreamReader(@"D:\apps\Mobile\PmupApp\Utils\Utils\jsonStudents.txt");
            while ((line = file.ReadLine()) != null)
            {
                temp += line;
            }
            file.Close();
            var result = JsonUtils.ConvertJsonToObject<List<StudentModel>>(temp);
            return result;

        }

        private static void uploadStudentsToDb(List<StudentModel> studentsFullList, int branchId)
        {
            pickmepleasedbEntities1 p = new pickmepleasedbEntities1();
            List<StudentModel> errorList = new List<StudentModel>();
            foreach (var s in studentsFullList)
            //studentsFullList.ForEach(s =>
            {
                //remove permissions in the pickup
                //Yes, we give permission for Englilush Ltd. to publish photos including our child/children on website and marketing materials.
                //No, we do not give permission for Englilush Ltd. to publish photos including our child/children on website and marketing materials.
                bool resetPicker = false;
                foreach (var picker in s.PickUpOptions)
                {
                    if (picker.Contains("for Englilush Ltd"))
                        resetPicker = true;
                }

                if (resetPicker)
                    s.PickUpOptions = new List<string>();


                students newStudent = new students()
                {

                    user_id = s.StudentID,
                    address = s.Address,
                    //email_1 = s.Parent2Email,
                    first_name = s.FirstName,
                    image = "",
                    last_name = s.LastName,
                    phone_home = s.HomeNum,

                    parent_a_email = s.Parent1Email,
                    parent_a_first_name = s.Parent1Name,
                    parent_a_last_name = s.LastName,
                    parent_a_phone_mobile = s.Parent1Num,

                    parent_b_email = s.Parent2Email,
                    parent_b_first_name = s.Parent2Name,
                    parent_b_last_name = s.LastName,
                    parent_b_phone_mobile = s.Parent2Num,

                    birthday = s.BirthDay,
                    branch_id = branchId,
                    @class = s.SClass ?? "0",
                    gender = s.Gender == "Male",
                    grade = s.Grade ?? "0",
                    health_issues = (s.HealthIssues != null) ? string.Join("*", s.HealthIssues) : null,
                    is_active = true,
                    pick_up_options = (s.PickUpOptions != null) ? string.Join("*", s.PickUpOptions) : null,

                };
                try
                {
                    if (s.Grade.Length > 19 || s.SClass.Length > 19)
                    {
                        errorList.Add(s);
                    }
                    else
                    {
                        p.students.Add(newStudent);
                        //p.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(newStudent.first_name + ", " + newStudent.last_name);
                    errorList.Add(s);
                    p.students.Remove(newStudent);
                    //throw;
                }
            }
            try
            {
                p.SaveChanges();
            }
            catch (Exception ex)
            {

                //throw;
            }
            //});
            p.SaveChanges();
        }

        private static List<StudentModel> LoadStudents()
        {
            //string path = @"D:\apps\Mobile\PmupApp\Data\2015_16_RegForms  - Copy.xlsx";
            string path = @"D:\apps\Mobile\PmupApp\Data\2015_16_RegForms .xlsx";

            return ReadXlsx(path);

        }

        private static List<StudentModel> ReadXlsx(string path)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;


            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            List<StudentModel> listStudents = StudentModel.LoadXlsx(range, 1);

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            return listStudents;
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        private static List<string[]> ReadCsvFromFile(string path)
        {

            var data = new List<string[]>();
            var reader = new StreamReader(File.OpenRead(path), Encoding.UTF8, true);
            bool isfirstRow = true;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (isfirstRow)
                {
                    isfirstRow = false;
                    continue;
                }
                data.Add(line.Split(','));
            }

            return data;
        }

        private static void AddBranches()
        {
            pickmepleasedbEntities1 p = new pickmepleasedbEntities1();
            //int id= DbHelpers.CreateContacts();
            contacts c_a = new contacts()
            {
                address = null,
                email_1 = "email.com",
                first_name = "lea",
                image = "http.git",
                last_name = "bela",
                phone_home = "03-12345678"
            };
            contacts c_b = new contacts()
           {
               address = null,
               email_1 = "email2.com",
               first_name = "lea2",
               image = "http.git",
               last_name = "bela2",
               phone_home = "03-12345678"
           };
            contacts manager = new contacts()
           {
               address = null,
               email_1 = "email.com",
               first_name = "mng",
               image = "http.git",
               last_name = "mng last",
               phone_home = "03-12345678"
           };
            contacts tempa = p.contacts.Add(c_a);
            contacts tempb = p.contacts.Add(c_b);
            contacts tempmng = p.contacts.Add(manager);
            p.SaveChanges();
            branches b = new branches()
            {
                address = "Adress 1",
                contact_a_contacts_id = tempa.id,
                contact_b_contacts_id = tempb.id,
                principle_contacts_id = tempmng.id,
                name = "cool branch"

            };
            branches b2 = new branches()
            {
                address = "Adress 2",
                contact_a_contacts_id = tempa.id,
                contact_b_contacts_id = tempb.id,
                principle_contacts_id = tempmng.id,
                name = "cool branch 2"

            };
            p.branches.Add(b);

            p.branches.Add(b2);
            p.SaveChanges();
        }

        private static void ReadCSV()
        {
            List<Old_StudentsModel> list = new List<Old_StudentsModel>();
            var reader = new StreamReader(File.OpenRead(@"D:\apps\Mobile\PmupApp\Data\2014_2015_RegForms.csv"), Encoding.UTF8, true);
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            bool isfirstRow = true;
            Dictionary<string, StringBuilder> errorsDic = new Dictionary<string, StringBuilder>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (isfirstRow)
                {
                    isfirstRow = false;
                    continue;
                }
                StringBuilder linesError = new StringBuilder();
                Old_StudentsModel s = new Old_StudentsModel();
                var values = line.Split(',');
                if (values.Count() < 15)
                {
                    linesError.AppendLine("Line was not properply inserted");
                    continue;
                }
                s.FirstName = values[1];
                s.LastName = values[2];
                s.Gender = values[3];
                s.BirthDayString = values[6];
                try
                {
                    s.BirthDay = DateTime.ParseExact(s.BirthDayString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    linesError.AppendLine("Bad BirthDay format");
                    //throw;
                }
                //1. split to class. 2. uppercase. 3. tranlate frmo hebrew
                string gradeAndClass = values[7];
                string Grade, sClass;
                string errorGrageAndClass = StudentModel.GetFormattedGrageAndClass(gradeAndClass, out Grade, out sClass);
                s.Grade = Grade;
                s.SClass = sClass;
                if (errorGrageAndClass != null)
                    linesError.AppendLine(errorGrageAndClass);
                s.HomeNum = values[9];

                s.Parent1Name = values[10];
                s.Parent1Num = values[11];
                s.Parent2Name = values[12];
                s.Parent2Num = values[13];
                s.Parent1Email = values[14];

                //allowed to be picked up should be in a single cells seperated by ;
                s.PickUpOptions = values[16].Split(';').ToList();

                //Food heatlh issues up should be in a single cells seperated by ;

                //s.HealthIssues= values[17].Split(';').ToList();
                string tempHekath = GetRandomHealth();
                s.HealthIssues = values[17].Split(';').ToList();


                if (s.Gender == "Male")
                    s.Img = @"http://mistran.otp.go.th/publish/Images/Icon/user_3.png";
                else
                    s.Img = @"http://icons.iconarchive.com/icons/hopstarter/sleek-xp-basic/256/Office-Girl-icon.png";
                errorsDic.Add(line, linesError);

                list.Add(s);
            }


            string students = JsonUtils.ConvertObjectToJson<List<Old_StudentsModel>>(list.OrderBy(s => s.FirstName).ToList());
        }

        private static string GetRandomHealth()
        {
            Random r = new Random();
            int num = r.Next(0, 300);
            if (num < 100) return "";
            if (num < 200) return "Celiak";
            if (num < 250) return "Celiak;Sugar";
            if (num < 250) return "Sugar";
            if (num < 300) return "Celiak;Sugar;WierdThingy";
            else return "";
        }


    }
}
