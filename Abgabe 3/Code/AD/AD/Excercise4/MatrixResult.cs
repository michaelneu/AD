using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.Excercise4
{
    public class MatrixResult
    {
        public int StartX
        {
            get;
            private set;
        }
        public int StartY
        {
            get;
            private set;
        }
        public int EndX
        {
            get;
            private set;
        }
        public int EndY
        {
            get;
            private set;
        }
        public int Maximum
        {
            get;
            private set;
        }

        public MatrixResult(int startX, int startY, int endX, int endY, int max)
        {
            StartX = startX;
            StartY = startY;

            EndX = endX;
            EndY = endY;

            Maximum = max;
        }

        public bool Contains(int i, int j)
        {
            return StartX <= i && i <= EndX && StartY <= j && j <= EndY;
        }
    }
}
