using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AD.Excercise4;

namespace AD
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = MatrixFactory.GenerateMatrix(5);
            MatrixResult result = MaxTeilsumme.MatrixTeilsumme2D(matrix);

            MatrixFactory.HighlightMatrix(matrix, result);
        }
    }
}
