using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AD.Excercise1;
using AD.Excercise2;
using AD.Excercise3;
using System.IO;

namespace AD
{
    class Program
    {
        private static void Excercise1()
        {
            Console.WriteLine("Excercise 1: Euklid\n");
            var euklid = new Euklid();

            string tableHeader = " a   | b   | gcd iteration | gcd recursion | lcm  | a * b | gcd * lcm",
                tableSplit =     "-----+-----+---------------+---------------+------+-------+-----------",
                tableRow =       " {0,3} | {1,3} | {2,13} | {3,13} | {4,4} | {5,5} | {6,7}";

            Console.WriteLine(tableHeader);
            Console.WriteLine(tableSplit);

            for (int a = 30; a < 40; a++)
            {
                for (int b = 30; b < 40; b++)
                {
                    int gcdIteration = euklid.GreatestCommonDivisorIteration(a, b),
                        gcdRecursion = euklid.GreatestCommonDivisorIteration(a, b),
                        lcm = euklid.LeastCommonMultiplier(a, b),
                        product = a * b;

                    Console.WriteLine(string.Format(tableRow, a, b, gcdIteration, gcdRecursion, lcm, product, gcdIteration * lcm));
                    Console.WriteLine(tableSplit);
                }
            }
        }

        private static void Excercise2()
        {
            Console.WriteLine("Excercise 2: Field type:\n");

            var field = new Feld(5);
            field.FillRandom();
            field.Print();

            Console.WriteLine("Min: " + field.Min());
            Console.WriteLine("Max: " + field.Max());
            Console.WriteLine("Avg: " + field.Avg());
        }

        private static void Excercise3()
        {
            Console.WriteLine("Excercise 3: Matrix Multiplication:\n");

            var matrixA = new Matrix(2, 2);
            Console.WriteLine(string.Format("Input a {0}x{1} matrix", matrixA.Rows, matrixA.Columns));
            matrixA.Input();

            var matrixB = new Matrix(2, 3);
            Console.WriteLine(string.Format("Input a {0}x{1} matrix", matrixB.Rows, matrixB.Columns));
            matrixB.Input();

            // add tests
            try
            {
                Console.WriteLine("\nA.Add(A): ");
                matrixA.Add(matrixA).Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                Console.WriteLine("\nA.Add(B): ");
                matrixA.Add(matrixB).Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                Console.WriteLine("\nB.Add(B): ");
                matrixB.Add(matrixB).Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\n");

            // mul tests
            try
            {
                Console.WriteLine("\nA.Mul(A): ");
                matrixA.Mul(matrixA).Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                Console.WriteLine("\nA.Mul(B): ");
                matrixA.Mul(matrixB).Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                Console.WriteLine("\nB.Mul(B): ");
                matrixB.Mul(matrixB).Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Excercise4()
        {
            const int testCount = 5,
                testSize = 500,
                testStepsAdd = testSize * testSize,
                testStepsMul = testStepsAdd * testSize;

            Console.WriteLine("Excercise 4: Matrix calculation speed estimation:\n");
            Console.WriteLine(string.Format("Running {0} benchmarks for a {1}x{1} matrix", testCount, testSize));

            var stdout = Console.Out;
            Console.SetOut(TextWriter.Null);

            List<long> ticksAdd = new List<long>(),
                ticksMul = new List<long>();

            for (int i = 0; i < testCount; i++)
            {
                Matrix matrixA = new Matrix(testSize, testSize),
                    matrixB = matrixA.Clone();

                var startAdd = DateTime.Now;
                matrixA.Add(matrixB);
                var endAdd = DateTime.Now;

                ticksAdd.Add(endAdd.Ticks - startAdd.Ticks);

                var startMul = DateTime.Now;
                matrixA.Mul(matrixB);
                var endMul = DateTime.Now;

                ticksMul.Add(endMul.Ticks - startMul.Ticks);
            }

            Console.SetOut(stdout);

            double addStepsPerMinute = testStepsAdd / ticksAdd.Average() * TimeSpan.TicksPerMinute,
                mulStepsPerMinute = testStepsMul / ticksMul.Average() * TimeSpan.TicksPerMinute;

            Console.WriteLine("Benchmark done. On this machine it would look like this: ");
            Console.WriteLine(" minutes | add size | mul size");

            string tableSeparator = "---------+----------+---------",
                tableRow = " {0,7} | {1,8} | {2,8}";

            foreach (int duration in new int[] { 1, 2, 5, 10 })
            {
                double addStepsPerDuration = addStepsPerMinute * duration,
                    mulStepsPerDuration = mulStepsPerMinute * duration;

                long addSize = (long)Math.Pow(addStepsPerDuration, 1.0 / 2),
                    mulSize = (long)Math.Pow(mulStepsPerDuration, 1.0 / 3);

                Console.WriteLine(tableSeparator);
                Console.WriteLine(string.Format(tableRow, duration, addSize, mulSize));
            }
        }

        static void Main(string[] args)
        {
            Excercise1();
            Excercise2();
            Excercise3();
            Excercise4();
        }
    }
}
