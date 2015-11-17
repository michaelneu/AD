using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise4
{
    public class SearchTree<T> : BinaryTree<T> where T : IComparable
    {
        public void FromPreorder(T[] preorder)
        {
            if (preorder == null)
            {
                throw new ArgumentNullException("Invalid preorder passed");
            }
            else
            {
                // 4, 2, 1, 3, 6, 5, 7

                root = CreateFromPreorder(preorder);
            }
        }

        private TreeNode<T> CreateFromPreorder(T[] preorder)
        {
            if (preorder.Length > 0)
            {
                // pop the first element
                var data = preorder.First();
                preorder = preorder.Skip(1)
                                   .ToArray();

                // split the array into smaller and bigger children
                var leftChildren = preorder.TakeWhile(x => x.CompareTo(data) <= 0)
                                           .ToArray();

                var rightChildren = preorder.Skip(leftChildren.Count())
                                            .ToArray();

                // get the children via recursion
                var node = new TreeNode<T>(data);
                node.ChildLeft = CreateFromPreorder(leftChildren);
                node.ChildRight = CreateFromPreorder(rightChildren);

                return node;
            }

            return null;
        }
    }
}
