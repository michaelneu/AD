using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AD.Excercise4;

namespace AD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" m  | n  | recursion | iteration ");
            string tableRow = " {0,2} | {1,2} | {2,9} | {3,9} ",
                tableSeparator = "----+----+-----------+-----------";

            for (int m = 0; m < 4; m++)
            {
                for (int n = 0; n < 11; n++)
                {
                    int recursion = Algorithm.Recursion(m, n),
                        iteration = Algorithm.Iteration(m, n);

                    if (recursion != iteration)
                    {
                        Console.WriteLine(string.Format("\nMismatching results: {0} - {1} ({2},{3})\n", recursion, iteration, m, n));
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine(tableSeparator);
                        Console.WriteLine(string.Format(tableRow, m, n, recursion, iteration));
                    }
                }
            }
        }
    }
}
