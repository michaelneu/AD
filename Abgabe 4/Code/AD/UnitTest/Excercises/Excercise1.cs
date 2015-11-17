using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AD;
using AD.Excercise1;
using System.Diagnostics;

namespace UnitTest.Excercises
{
    [TestClass]
    public class Excercise1
    {
        private ISorter[] GenerateSorters()
        {
            return new ISorter[] { new Insertionsort(), new Bubblesort(), new Selectionsort() };
        }

        [TestMethod]
        public void TestExcercise1()
        {
            Debug.WriteLine("Testing excercise 1");

            int[] array = { -5, 13, -32, 7, -3, 17, 23, 12, -35, 19 };

            Debug.WriteLine("Array: " + ArrayFactory.ToString(array));

            var _sortedByFramework = array.ToList();
            _sortedByFramework.Sort();
            int[] sortedByFramework = _sortedByFramework.ToArray();

            Debug.WriteLine("Expected result: " + ArrayFactory.ToString(sortedByFramework));

            foreach (var sorter in GenerateSorters())
            {
                int[] temp = ArrayFactory.Clone(array);
                sorter.Sort(temp);

                Debug.WriteLine(sorter.GetType().Name + ": " + ArrayFactory.ToString(temp));

                CollectionAssert.AreEqual(temp, sortedByFramework);
            }
        }
    }
}
