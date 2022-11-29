using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flood_Labb1_SQL
{
    public class fetchNames
    {
        public static void createFiles()
        {
            File.OpenWrite("Firstnames.txt");
            File.OpenWrite("Lastnames.txt");
        }
        public static void GetNames(ref List<string> firstNames, ref List<string> lastNames)
        {
            string firstNamesPath = @"Firstnames.txt";
            string lastNamesPath = @"Lastnames.txt";

            if (!File.Exists("Firstnames.txt"))
            {
                Console.WriteLine($"{firstNamesPath}: File path could not be found!");
                return;
            }
            if (!File.Exists(lastNamesPath))
            {
                Console.WriteLine($"{lastNamesPath}: File path could not be found!");
                return;
            }

            using (FileStream stream = new FileStream(firstNamesPath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        firstNames.Add(reader.ReadLine());
                    }
                }
            }
            using (FileStream stream = new FileStream(lastNamesPath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        lastNames.Add(reader.ReadLine());
                    }
                }
            }
        }
    }
}
