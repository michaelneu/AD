using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise4
{
    public class TreeNode<T>
    {
        public TreeNode<T> ChildLeft
        {
            get;
            set;
        }

        public TreeNode<T> ChildRight
        {
            get;
            set;
        }

        public T Data
        {
            get;
            set;
        }

        public TreeNode(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return ToString(SortOrder.IN);
        }

        public string ToString(SortOrder order)
        {
            T[] sorted = ToOrderedList(order);

            return string.Join(", ", sorted);
        }

        internal T[] ToOrderedList(SortOrder order)
        {
            var sorted = new List<T>();
            T[] left = new T[0],
                right = new T[0];

            if (ChildLeft != null)
            {
                left = ChildLeft.ToOrderedList(order);
            }

            if (ChildRight != null)
            {
                right = ChildRight.ToOrderedList(order);
            }

            switch (order)
            {
                case SortOrder.PRE:
                    sorted.Add(Data);
                    sorted.AddRange(left);
                    sorted.AddRange(right);
                    break;

                case SortOrder.POST:
                    sorted.AddRange(left);
                    sorted.AddRange(right);
                    sorted.Add(Data);
                    break;

                default:
                    sorted.AddRange(left);
                    sorted.Add(Data);
                    sorted.AddRange(right);
                    break;
            }

            return sorted.ToArray();
        }
    }
}
