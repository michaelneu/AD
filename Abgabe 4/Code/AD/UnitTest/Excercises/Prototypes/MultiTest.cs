using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AD;
using System.Diagnostics;

namespace UnitTest.Excercises.Prototypes
{
    public abstract class MultiTest
    {
        protected abstract ISorter[] GenerateSorters();

        protected void SingleTest(int length)
        {
            int[] array = ArrayFactory.GenerateArray(length);

            Debug.WriteLine("Array: " + ArrayFactory.ToString(array));

            var _sortedByFramework = array.ToList();
            _sortedByFramework.Sort();
            int[] sortedByFramework = _sortedByFramework.ToArray();

            Debug.WriteLine("Expected result: " + ArrayFactory.ToString(sortedByFramework));

            foreach (var sorter in GenerateSorters())
            {
                int[] temp = ArrayFactory.Clone(array);
                sorter.Sort(temp);

                // invert the array for bubblesort as the excercise wants it this way
                if (sorter is AD.Excercise2.Bubblesort)
                {
                    var list = temp.ToList();
                    list.Reverse();
                    temp = list.ToArray();
                }

                Debug.WriteLine(sorter.GetType().Name + ": " + ArrayFactory.ToString(temp));

                CollectionAssert.AreEqual(temp, sortedByFramework);
            }
        }

        protected void RunTest(int min, int max)
        {
            for (int i = min; i < max; i++)
            {
                SingleTest(i);
                Debug.WriteLine("");
            }
        }
    }
}
