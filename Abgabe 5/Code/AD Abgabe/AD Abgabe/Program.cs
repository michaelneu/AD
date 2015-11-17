using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD_Abgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine(
                "[{0}]: {1}",
                string.Join(", ", numbers.Select(x => x + "").ToArray()),
                Algorithm.ContainsSum(numbers)
            );

            numbers[numbers.Length - 1] = numbers.Take(numbers.Length - 1).Sum();

            Console.WriteLine(
                "[{0}]: {1}",
                string.Join(", ", numbers.Select(x => x + "").ToArray()),
                Algorithm.ContainsSum(numbers)
            );
        }
    }
}
