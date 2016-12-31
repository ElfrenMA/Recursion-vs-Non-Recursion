/*
 * This program compares two different methods 
 * of calculating fibinacci numbers. When it 
 * finishes a run time in milliseconds is 
 * displayed the the bottom of each run
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RecursionVsNonRecursion
{
    class Program
    {
        // Does not user recusion
        // To find the fibinocci numbers
        static Int64 NonRecFib(Int32 n)
        {
            if (n < 2)
            {
                return n;
            }
            Int64[] f = new Int64[n + 1];
            f[0] = 0;
            f[1] = 1;
            for (int i = 2; i <= n; ++i)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[n];
        }
        // Uses Recursion to find 
        // the fibinocci numbers.
        static Int64 RecFib(Int32 n)
        {
            if( n == 0 || n == 1)
            {
                return n;
            }
            return RecFib(n -2) + RecFib(n - 1);
        }
        static void Main(string[] args)
        {
            Int32 number = 0;
            Int64 output = 0;
            string input = String.Empty;
            while(true)
            {
                output = 0;
                number = 0;
                input = String.Empty;
                try
                {
                    Console.WriteLine("\nEnter an integer less than {0}", Int32.MaxValue);
                    Console.WriteLine("Numbers greater than 50 not recommended");
                    Console.WriteLine("Type quite to exit application");
                    input = Console.ReadLine();
                    bool result = Int32.TryParse(input, out number);
                    if(result)
                    {
                        Stopwatch stopWatch = Stopwatch.StartNew();
                        output = NonRecFib(number);
                        stopWatch.Stop();
                        Console.WriteLine("Non Recusive Method ETA: {0}s", stopWatch.ElapsedMilliseconds * 0.001);
                        Console.WriteLine(output);
                        
                        stopWatch = Stopwatch.StartNew();
                        output = RecFib(number);
                        stopWatch.Stop();
                        Console.WriteLine("Recusive Method ETA: {0}s", stopWatch.ElapsedMilliseconds * 0.001);
                        Console.WriteLine(output);
                    }
                    else if(input.ToUpper() == "QUITE")
                    {
                        // Safely closes the application.
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect Input, Try Again.");   
                    }
                    
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                   // Console.ReadLine();
                }
            }
        }
    }
}
