using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise2
{
    public class Quicksort : ISorter
    {
        private Random random;

        public Quicksort()
        {
            random = new Random();
        }

        private int RandomIndex(int first, int last)
        {
            return random.Next(first, last);
        }

        private void Swap(int[] array, int a, int b)
        {
            int temp = array[a];

            array[a] = array[b];
            array[b] = temp;
        }

        private int PreparePartition(int[] array, int first, int last)
        {
            int index = RandomIndex(first, last);
            Swap(array, index, first); // :^)

            int pivot = array[first],
                partition = first - 1;

            for (int i = first; i <= last; i++)
            {
                if (array[i] <= pivot)
                {
                    partition++;

                    Swap(array, i, partition);
                }
            }

            Swap(array, first, partition);

            return partition;
        }

        private void QuickSort(int[] array, int first, int last)
        {
            if (first < last)
            {
                int partition = PreparePartition(array, first, last);

                QuickSort(array, first, partition - 1);
                QuickSort(array, partition + 1, last);
            }
        }

        public void Sort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
    }
}
