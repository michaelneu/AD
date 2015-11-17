using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AD.Excercise1;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class Excercise1
    {
        [TestMethod]
        public void TestLinkedList()
        {
            var array = ArrayFactory.GetArray(20);

            var list = new CustomLinkedList<int>();

            foreach (var item in array)
            {
                list.Add(item);
            }

            Debug.WriteLine("Original:  " + list.ToString());
            list.Quicksort();
            Debug.WriteLine("Quicksort: " + list.ToString());

            var customSorted = list.ToString();

            // sort the array using the regular framework
            var framework = new List<int>(array);
            framework.Sort();

            // convenience, append the numbers to a custom linked list and use ToString
            list = new CustomLinkedList<int>();

            foreach (var item in framework)
            {
                list.Add(item);
            }

            Debug.WriteLine("Framework: " + list.ToString());

            var frameworkSorted = list.ToString();

            Assert.AreEqual(customSorted, frameworkSorted);
        }

        [TestMethod]
        public void TestRingList()
        {
            var list = new RingList<int>();

            for (int i = 0; i < 2; i++)
            {
                list.Add(i);
            }

            list.Remove(0);
            list.Remove(1);
            list.Add(3);

            Assert.AreEqual("[3]", list.ToString());
        }

        [TestMethod]
        public void TestLottery()
        {
            var lotto = new Lottery();
            var numbers = lotto.ChooseNumbers(6);

            Debug.WriteLine(numbers.ToString());
        }
    }
}
