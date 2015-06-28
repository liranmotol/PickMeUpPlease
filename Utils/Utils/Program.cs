using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadCSV();

        }

        private static void ReadCSV()
        {
            List<StudentsModel> list = new List<StudentsModel>();
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
                StudentsModel s = new StudentsModel();
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
                string errorGrageAndClass = GetFormattedGrageAndClass(gradeAndClass, out Grade, out sClass);
                s.Grade = Grade;
                s.SClass = sClass;
                if (errorGrageAndClass != null)
                    linesError.AppendLine(errorGrageAndClass);
                s.HomeNum = values[9];

                s.Parent1Name= values[10];
                s.Parent1Num= values[11];
                s.Parent2Name= values[12];
                s.Parent2Num= values[13];
                s.Parent1Email= values[14];
                
                //allowed to be picked up should be in a single cells seperated by ;
                s.PickUpOptions = values[16].Split(';').ToList();

                //Food heatlh issues up should be in a single cells seperated by ;

                //s.HealthIssues= values[17].Split(';').ToList();
                string tempHekath= GetRandomHealth();
                s.HealthIssues= values[17].Split(';').ToList();


                if (s.Gender=="Male")
                    s.Img = @"http://mistran.otp.go.th/publish/Images/Icon/user_3.png";
                else
                    s.Img = @"http://icons.iconarchive.com/icons/hopstarter/sleek-xp-basic/256/Office-Girl-icon.png";
                errorsDic.Add(line, linesError);

                list.Add(s);
            }
            

            string students = JsonUtils.ConvertObjectToJson<List<StudentsModel>>(list.OrderBy(s=>s.FirstName).ToList());
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

        private static string GetFormattedGrageAndClass(string gradeAndClass, out string Grade, out string sClass)
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

    }
}
