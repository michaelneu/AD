using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise3
{
    public class AVLTree<T> where T : IComparable
    {
        private Node<T> root;

        public void Insert(T data)
        {
            var element = new Node<T>(data);

            if (root == null)
            {
                root = element;
            }
            else
            {
                root = InsertRecursion(root, element);
            }
        }

        private Node<T> InsertRecursion(Node<T> node, Node<T> element)
        {
            if (element.Data.CompareTo(node.Data) < 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = element;
                }
                else
                {
                    node.LeftChild = InsertRecursion(node.LeftChild, element);
                }

                return CheckRotationLeft(node);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = element;
                }
                else
                {
                    node.RightChild = InsertRecursion(node.RightChild, element);
                }

                return CheckRotationRight(node);
            }
        }

        public void Remove(T data)
        {
            if (root != null)
            {
                root = RemoveRecursion(root, data);
            }
        }

        private Node<T> RemoveRecursion(Node<T> node, T data)
        {
            if (node.Data.Equals(data))
            {
                if (node.LeftChild != null && node.RightChild != null)
                {
                    var mostRight = RemoveMostRightChild(node.LeftChild);

                    if (mostRight != node.LeftChild)
                    {
                        mostRight.LeftChild = node.LeftChild;
                    }

                    mostRight.RightChild = node.RightChild;

                    return mostRight;
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
                    node.LeftChild = RemoveRecursion(node.LeftChild, data);

                    return CheckRotationLeft(node);
                }
                else
                {
                    node.RightChild = RemoveRecursion(node.RightChild, data);

                    return CheckRotationRight(node);
                }
            }
        }

        private Node<T> RemoveMostRightChild(Node<T> node)
        {
            if (node.RightChild == null)
            {
                return node;
            }
            else
            {
                var mostRight = RemoveMostRightChild(node.RightChild);

                if (mostRight == node.RightChild)
                {
                    node.RightChild = null;
                }

                return mostRight;
            }
        }

        private Node<T> CheckRotationLeft(Node<T> node)
        {
            int heightLeft = Node<T>.HeightOrDefault(node.LeftChild),
                heightRight = Node<T>.HeightOrDefault(node.RightChild);

            if (heightLeft - heightRight > 1)
            {
                var leftTree = node.LeftChild;

                int heightOuterTree = Node<T>.HeightOrDefault(leftTree.LeftChild),
                    heightInnerTree = Node<T>.HeightOrDefault(leftTree.RightChild);

                if (heightOuterTree > heightInnerTree)
                {
                    return RotateRight(node);
                }
                else
                {
                    return RotateLeftRight(node);
                }
            }

            return node;
        }

        private Node<T> CheckRotationRight(Node<T> node)
        {
            int heightLeft = Node<T>.HeightOrDefault(node.LeftChild),
                heightRight = Node<T>.HeightOrDefault(node.RightChild);

            if (heightRight - heightLeft > 1)
            {
                var rightTree = node.RightChild;

                int heightInnerTree = Node<T>.HeightOrDefault(rightTree.LeftChild),
                    heightOuterTree = Node<T>.HeightOrDefault(rightTree.RightChild);

                if (heightOuterTree > heightInnerTree)
                {
                    return RotateLeft(node);
                }
                else
                {
                    return RotateRightLeft(node);
                }
            }
            else
            {
                return node;
            }
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            if (node != null)
            {
                var temp = node.RightChild;

                if (temp != null)
                {
                    node.RightChild = temp.LeftChild;
                    temp.LeftChild = node;

                    return temp;
                }
            }

            return node;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            if (node != null)
            {
                var temp = node.LeftChild;

                if (temp != null)
                {
                    node.LeftChild = temp.RightChild;
                    temp.RightChild = node;

                    return temp;
                }
            }

            return node;
        }

        private Node<T> RotateLeftRight(Node<T> node)
        {
            node.LeftChild = RotateLeft(node.LeftChild);

            return RotateRight(node);
        }

        private Node<T> RotateRightLeft(Node<T> node)
        {
            node.RightChild = RotateRight(node.RightChild);

            return RotateLeft(node);
        }

        public List<T> ToList()
        {
            if (root != null)
            {
                return root.ToList();
            }
            else
            {
                return new List<T>();
            }
        }

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
