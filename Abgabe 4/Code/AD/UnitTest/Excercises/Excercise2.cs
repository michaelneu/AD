using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AD;
using AD.Excercise2;

namespace UnitTest.Excercises
{
    [TestClass]
    public class Excercise2 : Prototypes.MultiTest
    {
        protected override ISorter[] GenerateSorters()
        {
            return new ISorter[] { new Insertionsort(), new Bubblesort(), new Selectionsort(), new Quicksort() };
        }
        
        [TestMethod]
        public void TestExcercise2()
        {
            Debug.WriteLine("Testing excercise 2");
            RunTest(20, 40);
        }
    }
}
