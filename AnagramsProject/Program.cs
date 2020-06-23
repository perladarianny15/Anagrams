using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AnagramsProject.Helper;
using System.Diagnostics;

namespace AnagramsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            string FileName = @"wordlist.txt";
            bool endApp = false;

            while (!endApp)
            {
                Console.WriteLine("---Welcome to Kata Anagrams Program, What operation do you want: --- \n");

                Console.WriteLine("" +
                    "1. GetAllAnagrams \n" +
                    "2. BiggestWord \n" +
                    "3. Salir..."
                    );
                Console.WriteLine("Select your option: \n");

                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:

                        if (ValidateFile.FileExist(FileName))
                        {
                            string[] lines = File.ReadLines(FileName).ToArray();
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            Anagrams.PrintAnagrams(lines);
                            stopwatch.Stop();
                            var time = stopwatch.Elapsed.TotalMilliseconds;
                            Console.WriteLine("Total of time in seconds: " + time);
                        }
                        else
                        {
                            Console.WriteLine("File Not Found...");
                        }

                        break;
                    case 2:
                        break;
                    case 3:
                        Console.WriteLine("Saliendo...");
                        break; 
                }
                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
