using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AD;
using AD.Excercise4;

namespace UnitTest.Excercises
{
    [TestClass]
    public class Excercise4 : Prototypes.MultiTest
    {
        protected override ISorter[] GenerateSorters()
        {
            return new ISorter[] { new Insertionsort(), new Mergesort() };
        }

        [TestMethod]
        public void TestExcercise4()
        {
            Debug.WriteLine("Testing excercise 4");
            RunTest(10, 20);
        }
    }
}
