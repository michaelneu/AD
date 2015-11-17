using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.Excercise2
{
    public class Bubblesort : ISorter
    {
        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 2; j >= i; j--)
                {
                    if (array[j] < array[j + 1])
                    {
                        int h = array[j];

                        array[j] = array[j + 1];
                        array[j + 1] = h;
                    }
                }
            }
        }
    }
}
