using System;
using System.Collections.Generic;
using System.Linq;

namespace q54_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 50;
            int N = 5;

            var primes = MakePrimes(M);

            var memo = new Dictionary<(int, int), int> { };
            int Search(int n, int i)
            {
                if (memo.ContainsKey((n, i))) return memo[(n, i)];
                if (i == primes.Count()) return (n == 0) ? 1 : 0;
                var use = primes[i];
                var cnt = 0;
                cnt += Search(n + use, i + 1);           // 左の皿
                cnt += Search(Math.Abs(n - use), i + 1); // 右の皿
                cnt += Search(n, i + 1);                 // 置かない
                memo.Add((n, i), cnt);
                return cnt;
            }

            Console.WriteLine(Search(N, 0));
        }

        // M以下の素数リストを作成
        static List<int> MakePrimes(int max)
        {
            var primes = new List<int> { };
            for (int i = 2; i < max; i++)
            {
                var isPrime = true;
                for (int j = 2; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime) primes.Add(i);
            }
            return primes;
        }
    }
}
