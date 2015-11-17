using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class ArrayFactory
    {
        public static int[] GetArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i; // -array.Length / 2;
            }

            var random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int temp = array[i],
                    index = random.Next(array.Length - 1);

                array[i] = array[index];
                array[index] = temp;
            }

            return array;
        }

        public static int[] Clone(int[] array)
        {
            int[] temp = new int[array.Length];

            Array.Copy(array, temp, array.Length);

            return temp;
        }
    }
}
