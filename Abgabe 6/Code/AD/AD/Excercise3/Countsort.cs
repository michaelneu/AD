using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise3
{
    public class Countsort : ISorter
    {
        public void Sort(int[] array)
        {
            int j = 0;
            var numbers = new int[array.Max() + 1];

            for (int i = 0; i < array.Length; i++)
            {
                numbers[array[i]]++;
            }

            for (int i = 0; i < array.Length; i++)
            {
                while (numbers[j] == 0)
                    j++;

                array[i] = j;
                numbers[j]--;
            }
        }

    }
}
