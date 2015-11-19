using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AD.Excercise3;

namespace AD.Excercise4
{
    public class AVLSort
    {
        public static void Sort<T>(T[] values) where T : IComparable
        {
            var avl = new AVLTree<T>();

            foreach (var item in values)
            {
                avl.Insert(item);
            }

            var avlList = avl.ToList();

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = avlList[i];
            }
        }
    }
}
