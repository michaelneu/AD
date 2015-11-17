using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.Excercise4
{
    public class MaxTeilsumme
    {
        public static MatrixResult MatrixTeilsumme2D(int[,] matrix)
        {
            int matrixLengthX = matrix.GetLength(0),
                matrixLengthY = matrix.GetLength(1);

            int startX = 0,
                startY = 0,
                endX = 0,
                endY = 0,
                max = int.MinValue;

            for (int startRow = 0; startRow < matrixLengthX; startRow++)
            {
                int[] rowSum = new int[matrixLengthY];

                for (int i = startRow; i < matrixLengthX; i++)
                {
                    for (int j = 0; j < rowSum.Length; j++)
                    {
                        rowSum[j] += matrix[i, j];
                    }

                    ArrayResult rowResult = MaxTeilsummeArray(rowSum);

                    if (rowResult.Maximum > max)
                    {
                        max = rowResult.Maximum;

                        startX = rowResult.Start;
                        endX = rowResult.End;

                        startY = startRow;
                        endY = i;
                    }
                }
            }

            return new MatrixResult(startX, startY, endX, endY, max);
        }

        public static ArrayResult MaxTeilsummeArray(int[] array)
        {
            int s,
                max = int.MinValue,
                aktSum = 0;

            int start = 0,
                end = 0;

            int currentStart = 0;

            for (int i = 0; i < array.Length; i++)
            {
                s = aktSum + array[i];

                if (s > array[i])
                {
                    aktSum = s;
                }
                else
                {
                    currentStart = i;
                    aktSum = array[i];
                }

                if (aktSum > max)
                {
                    start = currentStart;
                    end = i;
                    max = aktSum;
                }
            }

            return new ArrayResult(start, end, max);
        }
    }
}
