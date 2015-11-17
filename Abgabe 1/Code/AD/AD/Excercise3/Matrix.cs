using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AD.Excercise3
{
    public class Matrix
    {
        public int Rows
        {
            get;
            private set;
        }
        public int Columns
        {
            get;
            private set;
        }

        protected int[,] matrix;

        public Matrix(int rows, int columns)
        {
            Columns = columns;
            Rows = rows;

            matrix = new int[columns, rows];
        }


        public void Input()
        {
            var regex = new Regex(@"(\d+\s+)+");

            for (int y = 0; y < Rows; y++)
            {
                string line = Console.ReadLine();

                if (regex.IsMatch(line))
                {
                    int[] items = line.Trim().Split(' ').Select(x => int.Parse(x)).ToArray();

                    if (items.Length > Columns)
                    {
                        throw new Exception("Too many elements for row " + (y + 1));
                    }
                    else
                    {
                        for (int x = 0; x < Columns; x++)
                        {
                            matrix[x, y] = items[x];
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid input");
                }
            }
        }

        public void Print()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    Console.Write(matrix[x, y] + " ");
                }

                Console.WriteLine();
            }
        }


        public Matrix Add(Matrix other)
        {
            if (Columns == other.Columns && Rows == other.Rows)
            {
                var clone = other.Clone();

                int steps = 0;

                for (int x = 0; x < Columns; x++)
                {
                    for (int y = 0; y < Rows; y++)
                    {
                        clone.matrix[x, y] += matrix[x, y];

                        steps++;
                    }
                }

                Console.WriteLine("Took " + steps + " steps to calculate the sum of both matrices");

                return clone;
            }
            else
            {
                throw new Exception("Matrix sizes don't match each other");
            }
        }

        public Matrix Mul(Matrix other)
        {
            if (Columns != other.Rows)
            {
                throw new Exception("Matrices don't match each other");
            }
            else
            {
                int steps = 0;

                var multiplied = new Matrix(Rows, other.Columns);

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < other.Columns; j++)
                    {
                        for (int k = 0; k < Columns; k++)
                        {
                            multiplied.matrix[j, i] += matrix[k, i] * other.matrix[j, k];

                            steps++;
                        }
                    }
                }

                Console.WriteLine("Took " + steps + " steps to calculate the product of both matrices");

                return multiplied;
            }
        }

        public Matrix Clone()
        {
            var clone = new Matrix(Rows, Columns);
            clone.matrix = (int[,])matrix.Clone();

            return clone;
        }
    }
}
