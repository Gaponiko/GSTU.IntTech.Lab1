using System;
using System.Collections.Generic;

namespace lab1
{
    class PerfomanceCalculation
    {
        public static void Run(string inputFile, string outputFile = null, string fileType = null)
        {
            List<string[]> data = CsvTools.ReadStudentsGroup(inputFile);
            Group group = new Group(data);

            Console.WriteLine(group);
            
            if (fileType != null && outputFile != null)
            {
                if (fileType.ToUpper() == "JSON")
                {
                    JsonTools.SaveStudentsGroup(group, outputFile);
                    Console.WriteLine("Записано в JSON.");
                }
                else if (fileType.ToUpper() == "XLSX")
                {
                    ExcelTools.SaveStudentsGroup(group, outputFile);
                    Console.WriteLine("Записано в XLSX.");
                }
            }
        }
    }
}
