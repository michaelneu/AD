using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AD.Excercise4;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public class Excercise4
    {
        private int[] ArrayFromString(string text)
        {
            return text.Split(new string[] { ", " }, StringSplitOptions.None)
                       .Select(x => int.Parse(x))
                       .ToArray();
        }

        [TestMethod]
        public void TestBinaryTreeReconstructionPreIn()
        {
            // populate the tree
            var numbers = ArrayFactory.GetArray(20);
            var tree = new BinaryTree<int>();

            foreach (var item in numbers)
            {
                tree.Insert(item);
            }

            // get the sort ordered lists
            int[] preorderInsertion = ArrayFromString(tree.ToString(SortOrder.PRE)),
                inorderInsertion = ArrayFromString(tree.ToString());

            Debug.WriteLine("After insertion: ");
            Debug.WriteLine("Preorder: " + string.Join(", ", preorderInsertion));
            Debug.WriteLine("Inorder:  " + string.Join(", ", inorderInsertion));

            // reconstruct the tree
            tree = new BinaryTree<int>();
            tree.FromPreInOrderList(preorderInsertion, inorderInsertion);

            int[] preorderReconstruction = ArrayFromString(tree.ToString(SortOrder.PRE)),
                inorderReconstruction = ArrayFromString(tree.ToString());

            Debug.WriteLine("After reconstruction: ");
            Debug.WriteLine("Preorder: " + string.Join(", ", preorderReconstruction));
            Debug.WriteLine("Inorder:  " + string.Join(", ", inorderReconstruction));

            // verification
            CollectionAssert.AreEqual(preorderInsertion, preorderReconstruction);
            CollectionAssert.AreEqual(inorderInsertion, inorderReconstruction);
        }

        [TestMethod]
        public void TestSearchTreeReconstruction()
        {
            var sortedNumbers = new int[] { 4, 2, 1, 3, 6, 5, 7 };

            var tree = new SearchTree<int>();
            tree.FromPreorder(sortedNumbers);
            
            Assert.AreEqual(string.Join(", ", sortedNumbers), tree.ToString(SortOrder.PRE));
        }
    }
}
