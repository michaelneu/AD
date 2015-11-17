using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.Excercise4
{
    public class MatrixFactory
    {
        public static int[,] GenerateMatrix(int size)
        {
            var random = new Random();
            var matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(20) - 10;
                }
            }

            return matrix;
        }

        public static void HighlightMatrix(int[,] matrix, MatrixResult result)
        {
            const ConsoleColor color = ConsoleColor.DarkYellow;

            Console.Write(string.Format("Maximum result: {0}\nMatrix (", result.Maximum));
            Chalk.Write("highlighted elements", color);
            Console.WriteLine(" are part of MatrixTeilsumme2D): \n");

            string format = "{0,3: #;-#;0}  ";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(new String(' ', 3));

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    string text = string.Format(format, matrix[i, j]);

                    if (result.Contains(i, j))
                    {
                        Chalk.Write(text, color);
                    }
                    else
                    {
                        Console.Write(text);
                    }
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
        }
    }
}
