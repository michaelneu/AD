using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.Excercise4
{
    public class Algorithm
    {
        public static int Recursion(int n, int m)
        {
            if (n == 0)
            {
                return m + 1;
            }
            else if (m == 0 && n >= 1)
            {
                return Recursion(n - 1, 1);
            }
            else
            {
                return Recursion(n - 1, Recursion(n, m - 1));
            }
        }

        public static int Iteration(int n, int m)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(n);
            stack.Push(m);

            while (stack.Count != 0)
            {
                m = stack.Pop();
                n = stack.Pop();

                if (n == 0)
                {
                    // "recursion end"

                    if (stack.Count > 0)
                    {
                        // coming from previous "inner recursion"
                        stack.Pop();
                        n = stack.Pop();

                        stack.Push(n);
                        stack.Push(m + 1);
                    }
                }
                else if (m == 0 && n >= 1)
                {
                    stack.Push(n - 1);
                    stack.Push(1);
                }
                else
                {
                    // outer recursion call
                    stack.Push(n - 1);
                    stack.Push(m);

                    // inner recursion call
                    stack.Push(n);
                    stack.Push(m - 1);
                }
            }

            return m + 1;
        }
    }
}
