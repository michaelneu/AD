using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AD.Excercise3;

namespace AD
{
    class Program
    {
        private static bool CompareTime(TimeSpan time)
        {
            const long deltaSeconds = 0,
                targetMinutes = 1;

            long deltaTicks = deltaSeconds * TimeSpan.TicksPerSecond,
                targetTicks = targetMinutes * TimeSpan.TicksPerMinute,
                timeTicks = time.Ticks;

            return timeTicks + deltaTicks >= targetTicks;
        }

        static void Main(string[] args)
        {
            const int reportSteps = 10000;

            Console.Write("Run benchmark? [y/n] ");
            var c = Console.ReadKey().KeyChar;
            Console.WriteLine("\n");

            if (c == 'y')
            {
                int length = 170000;

                Console.WriteLine("Starting with {0} elements", length);

                Benchmark simpleBenchmark = new Benchmark(new Excercise1.Insertionsort()),
                    advancedBenchmark = new Benchmark(new Excercise4.Mergesort());

                Benchmark.Result simpleResult, advancedResult;

                do
                {
                    simpleResult = simpleBenchmark.Run(length);
                    advancedResult = advancedBenchmark.Run(length);

                    length += 15000;

                    if (length % reportSteps == 0)
                    {
                        Console.WriteLine("... {0} elements", length);
                    }
                } while (!CompareTime(simpleResult.AlgorithmTime) && !CompareTime(advancedResult.AlgorithmTime));

                Console.WriteLine();

                Console.WriteLine(
                    "Time: {0}\n  |-- Array generator: {1}\n  |-- Algorithm ({2}): {3}\n  +-- Size: {4}\n",
                    simpleResult.Time,
                    simpleResult.GeneratorTime,
                    simpleBenchmark.AlgorithmName,
                    simpleResult.AlgorithmTime, length
                );

                Console.WriteLine(
                    "Time: {0}\n  |-- Array generator: {1}\n  |-- Algorithm ({2}): {3}\n  +-- Size: {4}",
                    advancedResult.Time,
                    advancedResult.GeneratorTime,
                    advancedBenchmark.AlgorithmName,
                    advancedResult.AlgorithmTime, length
                );

                Console.WriteLine();
            }
        }
    }
}
