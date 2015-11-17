using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise2
{
    public class StrassenAlgorithm
    {
        public static int[,] Multiply(int[,] a, int[,] b)
        {
            int n = a.Length;
            int[,] result = new int[n, n];

            if ((n % 2 != 0) && (n != 1))
            {
                int[,] a1, b1, c1;
                int n1 = n + 1;
                a1 = new int[n1, n1];
                b1 = new int[n1, n1];
                c1 = new int[n1, n1];

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        a1[i, j] = a[i, j];
                        b1[i, j] = b[i, j];
                    }
                c1 = Multiply(a1, b1);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        result[i, j] = c1[i, j];
                return result;
            }

            if (n == 1)
            {
                result[0, 0] = a[0, 0] * b[0, 0];
            }
            else
            {
                int[,] A11 = new int[n / 2, n / 2];
                int[,] A12 = new int[n / 2, n / 2];
                int[,] A21 = new int[n / 2, n / 2];
                int[,] A22 = new int[n / 2, n / 2];

                int[,] B11 = new int[n / 2, n / 2];
                int[,] B12 = new int[n / 2, n / 2];
                int[,] B21 = new int[n / 2, n / 2];
                int[,] B22 = new int[n / 2, n / 2];

                Divide(a, A11, 0, 0);
                Divide(a, A12, 0, n / 2);
                Divide(a, A21, n / 2, 0);
                Divide(a, A22, n / 2, n / 2);

                Divide(b, B11, 0, 0);
                Divide(b, B12, 0, n / 2);
                Divide(b, B21, n / 2, 0);
                Divide(b, B22, n / 2, n / 2);

                int[,] P1 = Multiply(add(A11, A22), add(B11, B22));
                int[,] P2 = Multiply(add(A21, A22), B11);
                int[,] P3 = Multiply(A11, Sub(B12, B22));
                int[,] P4 = Multiply(A22, Sub(B21, B11));
                int[,] P5 = Multiply(add(A11, A12), B22);
                int[,] P6 = Multiply(Sub(A21, A11), add(B11, B12));
                int[,] P7 = Multiply(Sub(A12, A22), add(B21, B22));

                int[,] C11 = add(Sub(add(P1, P4), P5), P7);
                int[,] C12 = add(P3, P5);
                int[,] C21 = add(P2, P4);
                int[,] C22 = add(Sub(add(P1, P3), P2), P6);

                Copy(C11, result, 0, 0);
                Copy(C12, result, 0, n / 2);
                Copy(C21, result, n / 2, 0);
                Copy(C22, result, n / 2, n / 2);
            }
            return result;
        }

        private static int[,] add(int[,] A, int[,] B)
        {
            int n = A.Length;

            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    result[i, j] = A[i, j] + B[i, j];

            return result;
        }

        private static int[,] Sub(int[,] A, int[,] B)
        {
            int n = A.Length;

            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    result[i, j] = A[i, j] - B[i, j];

            return result;
        }

        private static void Divide(int[,] p1, int[,] c1, int iB, int jB)
        {
            for (int i1 = 0, i2 = iB; i1 < c1.Length; i1++, i2++)
                for (int j1 = 0, j2 = jB; j1 < c1.Length; j1++, j2++)
                {
                    c1[i1, j1] = p1[i2, j2];
                }
        }

        private static void Copy(int[,] c1, int[,] p1, int iB, int jB)
        {
            for (int i1 = 0, i2 = iB; i1 < c1.Length; i1++, i2++)
                for (int j1 = 0, j2 = jB; j1 < c1.Length; j1++, j2++)
                {
                    p1[i2, j2] = c1[i1, j1];
                }
        }

        public static void Print(int[,] array)
        {
            int n = array.Length;

            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
