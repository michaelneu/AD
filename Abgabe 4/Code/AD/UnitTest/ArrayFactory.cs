using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest
{
    sealed class ArrayFactory
    {
        public static int[] GenerateArray(int length)
        {
            var random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(-20, 20);
            }

            return array;
        }

        public static int[] Clone(int[] array)
        {
            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);

            return temp;
        }

        public static string ToString(int[] array)
        {
            return "[" + string.Join(", ", array) + "]";
        }
    }
}
