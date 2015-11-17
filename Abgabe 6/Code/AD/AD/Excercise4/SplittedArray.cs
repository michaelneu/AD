using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise4
{
    class SplittedArray<T>
    {
        public T[] Left
        {
            get;
            private set;
        }

        public T[] Right
        {
            get;
            private set;
        }

        public SplittedArray(T[] array, int splitIndex)
        {
            if (array.Length == 0)
            {
                Left = new T[0];
                Right = new T[0];
            }
            else
            {
                Left = array.Take(splitIndex).ToArray();
                Right = array.Skip(Left.Length + 1).ToArray();
            }
        }
    }
}
