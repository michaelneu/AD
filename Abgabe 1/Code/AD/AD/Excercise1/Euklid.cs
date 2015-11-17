using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.Excercise1
{
    public class Euklid
    {
        public int GreatestCommonDivisorRecursion(int a, int b)
        {
            int r = a % b;

            if (r == 0)
            {
                return b;
            }
            else
            {
                return GreatestCommonDivisorRecursion(b, r);
            }
        }

        public int GreatestCommonDivisorIteration(int a, int b)
        {
            int r;

            do
            {
                r = a % b;
                a = b;
                b = r;
            } while (r != 0);

            return a;
        }

        public int LeastCommonMultiplier(int a, int b)
        {
            int multiplier = 0;

            while ((a * ++multiplier) % b != 0)
            {
                // 
            }

            return a * multiplier;
        }
    }
}
