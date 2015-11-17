using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise4
{
    public class BinaryTree<T> where T : IComparable
    {
        protected TreeNode<T> root;

        public void Insert(T data)
        {
            var element = new TreeNode<T>(data);

            if (root == null)
            {
                root = element;
            }
            else
            {
                var node = root;

                while (node != null)
                {
                    if (node.Data.CompareTo(data) > 0)
                    {
                        if (node.ChildLeft == null)
                        {
                            node.ChildLeft = element;
                            break;
                        }
                        else
                        {
                            node = node.ChildLeft;
                        }
                    }
                    else
                    {
                        if (node.ChildRight == null)
                        {
                            node.ChildRight = element;
                            break;
                        }
                        else
                        {
                            node = node.ChildRight;
                        }
                    }
                }
            }
        }

        public void FromPreInOrderList(T[] preorder, T[] inorder)
        {
            if (preorder.Length == 0 || preorder.Length != inorder.Length)
            {
                throw new ArgumentException("Invalid orderings passed");
            }
            else
            {
                root = CreateFromPreInOrderList(preorder, inorder);

                if (root == null)
                {
                    throw new Exception("Unable to reconstruct the binary tree with the given arrays");
                }
            }
        }
        
        private TreeNode<T> CreateFromPreInOrderList(T[] preorder, T[] inorder)
        {
            if (preorder.Length > 0)
            {
                // pop the node first node from the preorder list
                var data = preorder.First();
                preorder = preorder.Skip(1)
                                   .ToArray();

                var node = new TreeNode<T>(data);

                // find all positions of the node in the inorder sorting, we can't know
                // which one will be the correct one, so we'll have to try them all

                for (int i = 0; i < inorder.Length; i++)
                {
                    if (inorder[i].Equals(data))
                    {
                        // split the inorder list according to the matching element in the inorder list
                        var inorderSplitted = new SplittedArray<T>(inorder, i);
                        
                        var preorderChildLeft = preorder.Take(inorderSplitted.Left.Length)
                                                        .ToArray();

                        var preorderChildRight = preorder.Skip(preorderChildLeft.Length)
                                                         .ToArray();

                        // get the node's children using the splitted order lists
                        node.ChildLeft = CreateFromPreInOrderList(preorderChildLeft, inorderSplitted.Left);
                        node.ChildRight = CreateFromPreInOrderList(preorderChildRight, inorderSplitted.Right);

                        // validate the resulting sub-tree
                        var inorderReconstructed = node.ToOrderedList(SortOrder.IN);
                        var preorderReconstructed = node.ToOrderedList(SortOrder.PRE).Skip(1);

                        if (inorder.SequenceEqual(inorderReconstructed) && preorder.SequenceEqual(preorderReconstructed))
                        {
                            // this sub-tree matches the given lists, return this node
                            return node;
                        }
                    }
                }
            }
            
            return null;
        }

        public override string ToString()
        {
            return ToString(SortOrder.IN);
        }

        public string ToString(SortOrder order)
        {
            if (root != null)
            {
                return root.ToString(order);
            }
            else
            {
                return "";
            }
        }
    }
}
