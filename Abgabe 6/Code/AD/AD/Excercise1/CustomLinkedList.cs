using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise1
{
    public class CustomLinkedList<T> where T : IComparable
    {
        #region List Internals
        private ListElement<T> firstElement, lastElement;
        public int Count
        {
            get;
            private set;
        }

        public void Add(T data)
        {
            var element = new ListElement<T>(data);

            if (Count == 0)
            {
                firstElement = element;
                lastElement = element;
            }
            else
            {
                lastElement.Next = element;
                element.Previous = lastElement;

                lastElement = element;
            }

            Count++;
        }

        public override string ToString()
        {
            List<string> elements = new List<string>();

            var node = firstElement;

            while (node != null)
            {
                elements.Add(node.ToString());
                node = node.Next;
            }

            return string.Format("[{0}]", string.Join(", ", elements));
        }
        #endregion

        #region Quicksort
        private void Swap(ListElement<T> a, ListElement<T> b)
        {
            T temp = a.Data;

            a.Data = b.Data;
            b.Data = temp;
        }

        private ListElement<T> PreparePartition(ListElement<T> first, ListElement<T> last)
        {
            T pivot = first.Data;
            var partition = first.Previous;
            var element = first;

            while (element != null && element != last.Next)
            {
                if (element.Data.CompareTo(pivot) <= 0)
                {
                    if (partition == null)
                    {
                        partition = first;
                    }
                    else
                    {
                        partition = partition.Next;
                    }

                    Swap(element, partition);
                }

                element = element.Next;
            }

            Swap(first, partition);

            return partition;
        }

        private void Quicksort(ListElement<T> first, ListElement<T> last)
        {
            if (first != null && last != null && first != last && first.Previous != last)
            {
                var partition = PreparePartition(first, last);

                if (partition != null)
                {
                    Quicksort(first, partition.Previous);
                    Quicksort(partition.Next, last);
                }
            }
        }

        public void Quicksort()
        {
            if (Count > 0)
            {
                Quicksort(firstElement, lastElement);
            }
        }
        #endregion
    }
}
