using System;
using System.Collections.Generic;
using static MyMath;

namespace q43_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 7;

            var memo = new Dictionary<int, long> { [0] = 1 };
            long seat(int n)
            {
                if (memo.ContainsKey(n)) { return memo[n]; }
                var count1 = Convert.ToString(n, 2).Split('1').Length - 1;
                var pre = count1 - 1;
                var post = count1 % N;
                long cnt = 0;
                for (int i = 0; i < N; i++)
                {
                    var mask = (1 << i);
                    if (((n & mask) > 0) && (i != pre) && (i != post))
                    {
                        cnt += seat(n - mask);
                    }
                }
                memo.Add(n, cnt);
                return cnt;
            }

            Console.WriteLine(seat((1 << N) - 1) * Factorial(N - 1));
            Console.ReadLine();
        }
    }
}
