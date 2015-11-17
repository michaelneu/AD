using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise3
{
    public sealed class Benchmark
    {
        public sealed class Result
        {
            public TimeSpan GeneratorTime
            {
                get;
                private set;
            }
            public TimeSpan AlgorithmTime
            {
                get;
                private set;
            }
            public TimeSpan Time
            {
                get
                {
                    return new TimeSpan(GeneratorTime.Ticks + AlgorithmTime.Ticks);
                }
                private set
                {
                    value = value;
                }
            }

            public Result(TimeSpan generator, TimeSpan algorithm)
            {
                GeneratorTime = generator;
                AlgorithmTime = algorithm;
            }
        }

        public string AlgorithmName
        {
            get
            {
                return sorter.GetType().Name;
            }
        }

        private ISorter sorter;

        public Benchmark(ISorter sortAlgorithm)
        {
            sorter = sortAlgorithm;
        }

        private int[] GenerateArray(int length)
        {
            int side = length / 2;
            var random = new Random();

            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(-side, side);
            }

            return array;
        }

        public Result Run(int arrayLength)
        {
            var start = DateTime.Now;
            int[] array = GenerateArray(arrayLength);
            var end = DateTime.Now;

            var generator = new TimeSpan(end.Ticks - start.Ticks);

            start = DateTime.Now;
            sorter.Sort(array);
            end = DateTime.Now;

            var algorithm = new TimeSpan(end.Ticks - start.Ticks);

            return new Result(generator, algorithm);
        }
    }
}
