using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AD.Excercise3;

namespace AD.Excercise1
{
    public class BinaryTree<T> where T : IComparable
    {
        public bool UseRecursion
        {
            get;
            set;
        }

        private Node<T> root;

        #region Insert
        public void Insert(T data)
        {
            var element = new Node<T>(data);

            if (root == null)
            {
                root = element;
            }
            else
            {
                if (UseRecursion)
                {
                    root = InsertRecursive(root, element);
                }
                else
                {
                    InsertIterative(element);
                }
            }
        }

        private Node<T> InsertRecursive(Node<T> node, Node<T> element)
        {
            if (element.Data.CompareTo(node.Data) < 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = element;
                }
                else
                {
                    node.LeftChild = InsertRecursive(node.LeftChild, element);
                }
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = element;
                }
                else
                {
                    node.RightChild = InsertRecursive(node.RightChild, element);
                }
            }

            return node;
        }

        private void InsertIterative(Node<T> element)
        {
            var node = root;

            while (node != null)
            {
                if (element.Data.CompareTo(node.Data) < 0)
                {
                    if (node.LeftChild == null)
                    {
                        node.LeftChild = element;

                        break;
                    }
                    else
                    {
                        node = node.LeftChild;
                    }
                }
                else
                {
                    if (node.RightChild == null)
                    {
                        node.RightChild = element;

                        break;
                    }
                    else
                    {
                        node = node.RightChild;
                    }
                }
            }
        }
        #endregion

        #region Remove
        public void Remove(T data)
        {
            if (root != null)
            {
                if (UseRecursion)
                {
                    root = RemoveRecursive(root, data);
                }
                else
                {
                    RemoveIterative(data);
                }
            }
        }

        private Node<T> RemoveRecursive(Node<T> node, T data)
        {
            if (node.Data.Equals(data))
            {
                if (node.LeftChild != null && node.RightChild != null)
                {
                    var mostRightNode = RemoveMostRightNodeRecursive(node.LeftChild);

                    // prevent a somehow appearing stackoverflow. dunno...
                    if (mostRightNode != node.LeftChild)
                    {
                        mostRightNode.LeftChild = node.LeftChild;
                    }

                    mostRightNode.RightChild = node.RightChild;

                    return mostRightNode;
                }
                else if (node.LeftChild != null)
                {
                    return node.LeftChild;
                }
                else
                {
                    return node.RightChild;
                }
            }
            else
            {
                if (data.CompareTo(node.Data) < 0)
                {
                    node.LeftChild = RemoveRecursive(node.LeftChild, data);
                }
                else
                {
                    node.RightChild = RemoveRecursive(node.RightChild, data);
                }

                return node;
            }
        }

        private Node<T> RemoveMostRightNodeRecursive(Node<T> tree)
        {
            if (tree.RightChild == null)
            {
                return tree;
            }
            else
            {
                // get the element
                var mostRight = RemoveMostRightNodeRecursive(tree.RightChild);

                // remove it if we're at it's parent
                if (mostRight == tree.RightChild)
                {
                    tree.RightChild = mostRight.LeftChild;
                }

                return mostRight;
            }
        }

        private enum TraverseDirection { LEFT, RIGHT };

        private void RemoveIterative(T data)
        {
            Node<T> node = root,
                parent = null;

            var direction = TraverseDirection.LEFT;

            while (node != null)
            {
                if (node.Data.Equals(data))
                {
                    if (node.LeftChild != null && node.RightChild != null)
                    {
                        var mostRightChild = RemoveMostRightNodeIterative(node.LeftChild);

                        // prevent a somehow appearing stackoverflow. dunno...
                        if (mostRightChild != node.LeftChild)
                        {
                            mostRightChild.LeftChild = node.LeftChild;
                        }

                        mostRightChild.RightChild = node.RightChild;

                        AssignParentChild(parent, mostRightChild, direction);
                    }
                    else if (node.LeftChild != null)
                    {
                        AssignParentChild(parent, node.LeftChild, direction);
                    }
                    else
                    {
                        AssignParentChild(parent, node.RightChild, direction);
                    }

                    break;
                }
                else
                {
                    parent = node;

                    if (data.CompareTo(node.Data) < 0)
                    {
                        node = node.LeftChild;
                        direction = TraverseDirection.LEFT;
                    }
                    else
                    {
                        node = node.RightChild;
                        direction = TraverseDirection.RIGHT;
                    }
                }
            }
        }

        private void AssignParentChild(Node<T> parent, Node<T> node, TraverseDirection direction)
        {
            if (parent != null)
            {
                switch (direction)
                {
                    case TraverseDirection.LEFT:
                        parent.LeftChild = node;
                        break;

                    case TraverseDirection.RIGHT:
                        parent.RightChild = node;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                root = node;
            }
        }

        private Node<T> RemoveMostRightNodeIterative(Node<T> tree)
        {
            Node<T> node = tree,
                parent = null;

            while (node != null)
            {
                if (node.RightChild == null)
                {
                    if (parent != null)
                    {
                        parent.RightChild = node.LeftChild;
                    }

                    return node;
                }
                else
                {
                    parent = node;
                    node = node.RightChild;
                }
            }

            return tree;
        }
        #endregion

        public override string ToString()
        {
            if (root != null)
            {
                return root.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
