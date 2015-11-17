using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise1
{
    public class RingList<T> where T : IComparable
    {
        private ListElement<T> firstElement;

        public int Count
        {
            get;
            private set;
        }

        public bool Empty
        {
            get
            {
                return Count == 0;
            }
        }

        public T this[int index]
        {
            get
            {
                var element = GetElementAtIndex(index);

                if (element != null)
                {
                    return element.Data;
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                var element = GetElementAtIndex(index);

                if (element != null)
                {
                    element.Data = value;
                }
            }
        }

        private ListElement<T> GetElementAtIndex(int index)
        {
            if (!Empty && index >= 0 && index < Count)
            {
                var element = firstElement;

                do
                {
                    if (index == 0)
                    {
                        return element;
                    }
                    else
                    {
                        element = element.Next;
                        index--;
                    }
                }
                while (element != firstElement);
            }

            return null;
        }

        public void Add(T data)
        {
            var element = new ListElement<T>(data);

            if (Empty)
            {
                firstElement = element;
                element.Previous = element;
                element.Next = element;
            }
            else
            {
                var formerLastElement = firstElement.Previous;

                element.Previous = formerLastElement;
                formerLastElement.Next = element;

                element.Next = firstElement;
                firstElement.Previous = element;
            }

            Count++;
        }

        public bool Remove(T data)
        {
            var element = firstElement;

            if (!Empty)
            {
                do
                {
                    if (element.Data.Equals(data))
                    {
                        element.Previous.Next = element.Next;
                        Count--;

                        return true;
                    }

                    element = element.Next;
                }
                while (element != firstElement);
            }

            return false;
        }

        public override string ToString()
        {
            var list = new List<string>();

            if (!Empty)
            {
                var element = firstElement;

                do
                {
                    list.Add(element.ToString());

                    element = element.Next;
                }
                while (element != firstElement);
            }

            return string.Format("[{0}]", string.Join(", ", list));
        }
    }
}
