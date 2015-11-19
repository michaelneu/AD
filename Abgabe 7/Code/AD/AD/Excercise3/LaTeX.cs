using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise3
{
    internal class LaTeX
    {
        public static void Generate()
        {
            using (var stream = new ConsoleWrapper("Desktop/tree.tex"))
            {
                var tree = new AVLTree<int>();

                var list = new int[] { 5, 6, 9, 12, 13, 3, 8, 10, 11, 16, 15, 14, 6, 4, 2, 1 };

                foreach (var item in list)
	            {
                    tree.Insert(item);
                }

                Console.WriteLine(tree.ToString());

                list = new int[] { 12, 8, 5, 4, 3, 6, 15, 14 };

                foreach (var item in list)
                {
                    tree.Remove(item);
                }

                Console.WriteLine(tree.ToString());
            }
        }
    }
}
