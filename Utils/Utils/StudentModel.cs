using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Utils
{
    public class StudentModel
    {
        #region properties
        public string StudentID { get; set; }
        public string Img { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public string SClass { get; set; }
        public string PickUpFrom { get; set; }
        public List<string> HealthIssues { get; set; }
        public string HealthIssuesString { get; set; }

        public CeckedInOutModel CheckedIn { get; set; }
        public CeckedInOutModel PickUp { get; set; }
        public List<string> PickUpOptions { get; set; }
        public bool IsPickedUp { get; set; }
        public string Parent1Name { get; set; }
        public string Parent1Num { get; set; }
        public string Parent1Email { get; set; }
        public string Parent2Name { get; set; }
        public string Parent2Num { get; set; }
        public string Parent2Email { get; set; }
        public string Address { get; set; }

        public string HomeNum { get; set; }

        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthDayString { get; set; }
        #endregion properties


        public static void LoadCsv(List<string> CsvData)
        {

        }

        internal static void LoadCsv(List<string[]> data, int branchId)
        {
            pickmepleasedbEntities1 p = new pickmepleasedbEntities1();
            if (data == null)
                return;
            foreach (string[] row in data)
            {
                //contacts


                contacts stu = new contacts()
                {
                    first_name = row[3],
                    last_name = row[4],
                    user_id = row[5],
                    address = row[13],
                    phone_home = row[14]
                };
                //parent a
                contacts parent1 = new contacts()
                {
                    first_name = row[15],
                    last_name = row[4],
                    user_id = row[5] + "_p1",
                    address = row[13],
                    phone_home = row[14],
                    phone_mobile = row[16],
                    email_1 = row[17],

                };
                //parent b
                contacts parent2 = new contacts()
                {
                    first_name = row[18],
                    last_name = row[4],
                    user_id = row[5] + "_p2",
                    address = row[13],
                    phone_home = row[14],
                    phone_mobile = row[19],
                    email_1 = row[20],
                };
                p.contacts.Add(stu);
                p.contacts.Add(parent1);
                p.contacts.Add(parent2);
                p.SaveChanges();

                //student
                DateTime bDay = DateTime.MinValue;
                try
                {
                    bDay = DateTime.ParseExact(row[10], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    //linesError.AppendLine("Bad BirthDay format");
                    //throw;
                }
                string gradeAndClass = row[9];
                string Grade, sClass;
                GetFormattedGrageAndClass(gradeAndClass, out  Grade, out  sClass);
                students s = new students()
                {
                    student_concacts_id = stu.id,
                    parent_a_contacts_id = parent1.id,
                    parent_b_contacts_id = parent2.id,
                    birthday = bDay,
                    branch_id = branchId,
                    @class = sClass,
                    grade = Grade,
                    gender = (row[11] == "Male") ? true : false,
                    health_issues = row[21],
                    pick_up_options = row[22]
                };
                p.students.Add(s);
                p.SaveChanges();



            }
        }

        internal static string GetFormattedGrageAndClass(string gradeAndClass, out string Grade, out string sClass)
        {
            string errorGAndClass = null;
            if (string.IsNullOrEmpty(gradeAndClass))
            {
                Grade = "NA";
                sClass = "0";
                return "No Grade or class is present";
            }
            switch (gradeAndClass.ToUpper())
            {
                case "A1":
                case "A":
                    Grade = "A";
                    sClass = "1";
                    break;
                case "A2":
                    Grade = "A";
                    sClass = "2";
                    break;
                case "A3":
                    Grade = "A";
                    sClass = "3";
                    break;
                case "B1":
                case "B":
                    Grade = "B";
                    sClass = "1";
                    break;
                case "B2":
                    Grade = "B";
                    sClass = "2";
                    break;
                case "B3":
                    Grade = "B";
                    sClass = "3";
                    break;
                case "C1":
                case "C":
                    Grade = "C";
                    sClass = "1";
                    break;
                case "C2":
                    Grade = "C";
                    sClass = "2";
                    break;
                case "C3":
                    Grade = "C";
                    sClass = "3";
                    break;
                case "Gan Yareach (Sofi)":
                    Grade = "GAN";
                    sClass = "1";
                    break;
                case "Gan Shavit (Maayan)":
                    Grade = "GAN";
                    sClass = "2";
                    break;
                case "Gan Shavtay (Olga)":
                    Grade = "GAN";
                    sClass = "3";
                    break;
                case "Gan":
                    Grade = "GAN";
                    sClass = "5";
                    break;
                default:
                    Grade = "NA";
                    sClass = "0";
                    errorGAndClass = "Could not find grade or class";
                    break;

            }
            return errorGAndClass;
        }


        internal static List<StudentModel> LoadXlsx(Range range, int branchId)
        {
            string str;
            int rCnt = 0;
            int cCnt = 0;
            bool isLastRowEmpty = true;
            FixedStrings fixedStrings = new FixedStrings();
            List<StudentModel> list = new List<StudentModel>();
            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                isLastRowEmpty = true;
                try
                {
                    StudentModel s = new StudentModel();
                    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                    {
                        var strBackup = (range.Cells[rCnt, cCnt] as Excel.Range).Text.ToString();
                        var temp = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                        str = temp != null ? temp.ToString() : "";
                        if (isLastRowEmpty && !string.IsNullOrEmpty(str))
                        {
                            isLastRowEmpty = false;
                        }

                        //initalize the data array
                        if (rCnt == 1)
                        {
                            fixedStrings.setValue(str, cCnt);
                            continue;
                        }

                        else
                        {
                            s.setValue(fixedStrings, str, cCnt, strBackup);
                        }
                        //Console.WriteLine(str);
                    }
                    if (rCnt != 1)
                        list.Add(s);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error in one of the studens.");
                }
                if (isLastRowEmpty)
                    break;
            }

            return list;
        }

        private void setValue(FixedStrings fixedStrings, string str, int cCnt, string strBackup)
        {
            if (string.IsNullOrEmpty(str))
                return;
            if (cCnt == fixedStrings.Column_StudentID)
            {
                this.StudentID = str;
            }
            else if (cCnt == fixedStrings.Column_Parent2Num)
            {
                this.Parent2Num = str;
            }
            else if (cCnt == fixedStrings.Column_Parent2Name)
            {
                this.Parent2Name = str;
            }
            else if (cCnt == fixedStrings.Column_Parent1Num)
            {
                this.Parent1Num = str;

            }
            else if (cCnt == fixedStrings.Column_Parent1Name)
            {
                this.Parent1Name = str;

            }
            else if (cCnt == fixedStrings.Column_Parent1Email)
            {
                this.Parent1Email = str;

            }
            else if (cCnt == fixedStrings.Column_LastName)
            {
                this.LastName = str;

            }
            else if (cCnt == fixedStrings.Column_HomeNum)
            {
                this.HomeNum = str;

            }
            else if (cCnt == fixedStrings.Column_HealthIssues)
            {
                this.HealthIssues = str.Split(',').ToList();

            }
            else if (cCnt == fixedStrings.Column_Parent2Email)
            {
                this.Parent2Email = str;

            }
            else if (cCnt == fixedStrings.Column_GradeNClass)
            {

                if (str.ToLower().Contains(fixedStrings.Gan_Hova.ToLower()))
                {
                    this.Grade = fixedStrings.Gan_Hova;
                    var sclassTemp = str.Split('-');
                    if (sclassTemp != null && sclassTemp.Count() > 1)
                        this.SClass = sclassTemp[1].Trim();
                    else
                        this.SClass = "1";
                }
                else if (str.ToLower().Contains(fixedStrings.Gan_Trom_Hova.ToLower()))
                {
                    this.Grade = fixedStrings.Gan_Trom_Hova;
                    var sclassTemp = str.Split('-');
                    if (sclassTemp != null && sclassTemp.Count() > 1)
                        this.SClass = sclassTemp[1].Trim();
                    else
                        this.SClass = "1";
                }
                else if (str.Length == 1)
                {
                    this.Grade = str;
                    this.SClass = "1";
                }
                else if (str.Length == 2)
                {
                    this.Grade = str[0].ToString();
                    this.SClass = str[1].ToString();
                }

            }
            else if (cCnt == fixedStrings.Column_Gender)
            {
                this.Gender = str;

            }
            else if (cCnt == fixedStrings.Column_FirstName)
            {
                this.FirstName = str;

            }
            else if (cCnt == fixedStrings.Column_BirthDay)
            {
                string exactDatetime = null;
                try
                {


                    var temp = str.Split('/');
                    if (temp == null || temp.Count() != 3)
                    {
                        temp = strBackup.Split('/');
                        if (temp == null || temp.Count() != 3)
                        {
                            this.BirthDay = DateTime.MinValue;
                            return;
                        }
                    }


                    if (temp[0].Length == 1)
                        exactDatetime = "0" + temp[0];
                    else
                        exactDatetime = temp[0];
                    exactDatetime += "/";
                    if (temp[1].Length == 1)
                        exactDatetime += "0" + temp[1];
                    else
                        exactDatetime += temp[1];
                    exactDatetime += "/";
                    if (temp[2].Length == 2)
                        exactDatetime += "20" + temp[2];
                    else if (temp[2].Length == 4)
                        exactDatetime += temp[2];
                    else
                    {
                        this.BirthDay = DateTime.MinValue;
                        return;
                    }

                    this.BirthDay = DateTime.ParseExact(exactDatetime, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture); ;

                }
                catch (Exception ex)
                {

                    try
                    {
                        this.BirthDay = DateTime.ParseExact(exactDatetime, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture); ;
                    }
                    catch (Exception)
                    {
                        this.BirthDay = DateTime.MinValue;
                    }
                    
                }

            }
            else if (cCnt == fixedStrings.Column_Address)
            {
                this.Address = str;

            }
            else if (cCnt == fixedStrings.Column_PickUpOptions)
            {
                try
                {

                    this.PickUpOptions = str.Split(fixedStrings.pickupSeperators).ToList().Where(p => !fixedStrings.IgnorePicks.Contains(p)).ToList();
                }
                catch (Exception)
                {

                    this.PickUpOptions = str.Split(fixedStrings.pickupSeperators).ToList();
                }

            }

        }

    }
}
