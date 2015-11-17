using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise4
{
    public class Insertionsort : ISorter
    {
        private void Sort(int[] array, int start)
        {
            if (start < array.Length)
            {
                int key = array[start];

                int i = start - 1;

                while (i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i--;
                }

                array[i + 1] = key;

                Sort(array, start + 1);
            }
        }

        public void Sort(int[] array)
        {
            Sort(array, 0);
        }
    }
}
