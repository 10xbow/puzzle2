using System;
using System.Collections.Generic;
using static MyMath;

namespace q61_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 20;

            var memo_tall = new Dictionary<int, long> { };
            long tall(int n)
            {
                if (n <= 2) return 1;
                if (memo_tall.ContainsKey(n)) return memo_tall[n];
                long result = 0;
                for (int i = 1; i <= n; i++)
                {
                    result += tall(i - 1) * NCr(n - 1, i - 1) * tall(n - i);
                }
                result /= 2;
                memo_tall.Add(n, result);
                return result;
            }

            if (N == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(2 * tall(N));
            }
        }
    }
}
