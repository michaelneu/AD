using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise1
{
    public class Insertionsort : ISorter
    {
        public void Sort(int[] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                int key = array[j];

                int i = j - 1;

                while (i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i--;
                }

                array[i + 1] = key;
            }
        }
    }
}
