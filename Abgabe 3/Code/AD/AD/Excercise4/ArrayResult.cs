using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.Excercise4
{
    public class ArrayResult
    {
        public int Start
        {
            get;
            private set;
        }
        public int End
        {
            get;
            private set;
        }
        public int Maximum
        {
            get;
            private set;
        }

        public ArrayResult(int start, int end, int max)
        {
            Start = start;
            End = end;
            Maximum = max;
        }
    }
}
