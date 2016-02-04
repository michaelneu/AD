using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD
{
    class AdjacencyMatrix
    {
        private int[,] matrix;

        public int this[GraphNode from, GraphNode to]
        {
            get
            {
                return matrix[from.Index, to.Index];
            }
            set
            {
                matrix[from.Index, to.Index] = value;
            }
        }

        public int this[int from, int to]
        {
            get
            {
                return matrix[from, to];
            }
            set
            {
                matrix[from, to] = value;
            }
        }

        public int Size
        {
            get;
            private set;
        }

        public AdjacencyMatrix(int size)
        {
            matrix = new int[size, size];
            Size = size;
        }

        public override string ToString()
        {
            string dashes = new string('-', matrix.GetLength(0) * 4 - 1),
                output =  "\n   " + dashes + "\n";

            for (int i = 0; i < Size; i++)
            {
                output += "  | ";

                for (int j = 0; j < Size; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        output += "  | ";
                    }
                    else
                    {
                        output += matrix[i, j] + " | ";
                    }
                }

                output += "\n   " + dashes + "\n";
            }

            return output;
        }
    }
}
