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
            var reader = new StreamReader(File.OpenRead(@"D:\apps\Mobile\PmupApp\Data\2014_2015_RegForms.csv"));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                listA.Add(values[0]);
                listB.Add(values[1]);
            }
        }
    }
}
