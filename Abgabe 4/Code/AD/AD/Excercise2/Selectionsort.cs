using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise2
{
    public class Selectionsort : ISorter
    {
        public void Sort(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int max = i;

                for (int j = i; j >= 0; j--)
                {
                    if (array[j] > array[max])
                    {
                        max = j;
                    }
                }

                int h = array[i];

                array[i] = array[max];
                array[max] = h;
            }
        }
    }
}
