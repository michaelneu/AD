using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AD.Excercise3;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class Excercise3
    {
        private void TestSorter(ISorter sorter)
        {
            var array = ArrayFactory.GetArray(10);
            var customSorted = ArrayFactory.Clone(array);

            sorter.Sort(customSorted);

            var list = array.ToList();
            list.Sort();

            CollectionAssert.AreEqual(customSorted, list);
        }

        [TestMethod]
        public void TestCountsort()
        {
            TestSorter(new Countsort());
        }

        [TestMethod]
        public void TestMapsort()
        {
            TestSorter(new Mapsort());
        }
    }
}
