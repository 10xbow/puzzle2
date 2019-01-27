using System;
using System.Collections.Generic;

namespace q58_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 15;

            var memo = new Dictionary<int, (long, long)> { [0] = ( 0, 0 ), [1] = ( 1, 0 ) };
            (long, long) tree_count(int n)
            {
                if (memo.ContainsKey(n)) return memo[n];
                long all = 0;
                long pair = 0;
                long la = 0;
                long lp = 0;
                long ra = 0;
                long rp = 0;
                for (int i = 1; i < n; i++)
                {
                    (la, lp) = tree_count(i);
                    (ra, rp) = tree_count(n - i);
                    // ＋と×のそれぞれで掛け算
                    all += la * ra * 2;
                    pair += la * (2 * rp + (long)Math.Floor(ra / 2.0))
                          + ra * (2 * lp + (long)Math.Floor(la / 2.0));
                }
                memo.Add(n, (all, pair));
                return (all, pair);
            }

            (var All, var Pair) = tree_count(N);
            Console.WriteLine(Pair);
        }
    }
}
