using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.Excercise2
{
    public class Feld
    {
        private int[] field;

        public Feld(int n)
        {
            field = new int[n];
        }

        public void FillRandom()
        {
            var random = new Random();

            for (int i = 0; i < field.Length; i++)
            {
                field[i] = random.Next(1, int.MaxValue);
            }
        }

        public int Min()
        {
            if (field.Length == 0)
            {
                throw new Exception("Field not initialized");
            }

            int min = field[0];

            foreach (var item in field.Skip(1))
            {
                min = Math.Min(min, item);
            }

            return min;
        }

        public int Max()
        {
            if (field.Length == 0)
            {
                throw new Exception("Field not initialized");
            }

            int max = field[0];

            foreach (var item in field.Skip(1))
            {
                max = Math.Max(max, item);
            }

            return max;
        }

        public int Avg()
        {
            // long required as there might be some overfow regarding
            // random.next(1, int.MaxValue) as items of the array
            long sum = 0;

            foreach (var item in field)
            {
                sum += item;
            }

            return (int)(sum / field.Length);
        }

        public void Print()
        {
            Console.WriteLine("[" + string.Join(", ", field.Select(x => x + "").ToArray()) + "]");
        }
    }
}
