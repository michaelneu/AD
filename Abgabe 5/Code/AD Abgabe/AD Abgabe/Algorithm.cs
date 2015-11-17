using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD_Abgabe
{
    class Algorithm
    {
        public static bool ContainsSum(int[] array)
        {
            if (array.Length < 2)
            {
                return false;
            }

            List<int> list = array.ToList();
            int target = list.Last();

            list = list.Take(array.Length - 1).ToList();
            list.Sort();
            array = list.ToArray();

            int min = 0,
                max = array.Length - 1;

            while (min < max)
            {
                int sum = array[min] + array[max];

                if (sum == target)
                {
                    return true;
                }
                else if (sum < target)
                {
                    min++;
                }
                else
                {
                    max--;
                }
            }

            return false;
        }
    }
}
