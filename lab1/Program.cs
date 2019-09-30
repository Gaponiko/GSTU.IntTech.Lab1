using System;


namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                PerfomanceCalculation.Run(args[0], args[1], args[2]);
            }
            else
            {
                PerfomanceCalculation.Run(".\\soso.csv");
            }


            Console.ReadKey();
        }
    }
}
