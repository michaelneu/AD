using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise4
{
    public class Mergesort : ISorter
    {
        private void Merge(int[] array, int first, int last, int middle)
        {
            int n = last - first + 1,
                a1first = first,
                a1last = middle - 1,
                a2first = middle,
                a2last = last;

            int[] temp = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (a1first <= a1last)
                {
                    if (a2first <= a2last)
                    {
                        if (array[a1first] <= array[a2first])
                        {
                            temp[i] = array[a1first++];
                        }
                        else
                        {
                            temp[i] = array[a2first++];
                        }
                    }
                    else
                    {
                        temp[i] = array[a1first++];
                    }
                }
                else
                {
                    temp[i] = array[a2first++];
                }
            }

            for (int i = 0; i < n; i++)
			{
                array[first + i] = temp[i];
			}
        }

        private void MergeSortRecursion(int[] array, int first, int last)
        {
            if (first < last)
            {
                int middle = (first + last + 1) / 2;

                MergeSortRecursion(array, first, middle - 1);
                MergeSortRecursion(array, middle, last);

                Merge(array, first, last, middle);
            }
        }

        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int pow = (int)Math.Pow(2, i);

                int lastStart = 0;
                for (int j = 0; j <= array.Length; j += pow)
                {
                    int first = lastStart,
                        last = Math.Min(j, array.Length - 1);

                    Merge(array, first, last, (first + last + 1) / 2);

                    lastStart = j;
                }
            }
        }
    }
}
