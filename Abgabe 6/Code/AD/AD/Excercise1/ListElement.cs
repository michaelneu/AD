using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise1
{
    internal class ListElement<T> where T : IComparable
    {
        public T Data
        {
            get;
            set;
        }

        public ListElement<T> Next
        {
            get;
            set;
        }

        public ListElement<T> Previous
        {
            get;
            set;
        }

        public ListElement(T data)
        {
            Data = data;
            Next = null;
        }

        public override string ToString()
        {
            if (Data == null)
            {
                return "";
            }
            else
            {
                return Data.ToString();
            }
        }
    }
}
