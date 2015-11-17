using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise2
{
    public class Insertionsort : ISorter
    {
        public void Sort(int[] array)
        {
            for (int i = array.Length - 2; i >= 0; i--)
            {
                int key = array[i];
                int j = i;

                while (j < array.Length - 1 && array[j + 1] < key)
                {
                    array[j] = array[j + 1];
                    j++;
                }

                array[j] = key;
            }
        }
    }
}
