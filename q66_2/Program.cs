using System;
using System.Collections.Generic;

namespace q66_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 20;
            int N = 100;

            // m個の数で合計がkになるものの個数を探す
            var memo = new Dictionary<(int, int), int> { };
            int split(int m, int k)
            {
                if (memo.ContainsKey((m, k))) return memo[(m, k)];
                if ((m == 1) || (m == k)) return 1;
                if (k < m) return 0;
                var result = split(m - 1, k - 1) + split(m, k - m);
                memo.Add((m, k), result);
                return result;
            }

            var cnt = 0;
            for (int k = 1; k <= N / M; k++)
            {
                if ((N - k) % k == 0) cnt += split(M - 1, (N - k) / k);
            }
            Console.WriteLine(cnt);
        }
    }
}
