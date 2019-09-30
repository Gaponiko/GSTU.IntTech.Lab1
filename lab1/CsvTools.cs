using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace lab1
{
    class CsvTools
    {
        public static List<string[]> ReadStudentsGroup(string path)
        {
            List<string[]> stringCSV = new List<string[]>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        //Define pattern
                        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                        //Separating columns to array
                        string[] X = CSVParser.Split(line);


                        /* Do something with X */
                        stringCSV.Add(X);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Неверный формат файла или путь к нему.");
            }

            return stringCSV;
        }
    }
}
