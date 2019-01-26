using System;
using System.Collections.Generic;
using System.Linq;

namespace q54_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 50;
            int N = 5;

            var primes = MakePrimes(M);

            var memo = new Dictionary<(int, int, int), int> { };
            int Search(int remain, int l, int r)
            {
                if (memo.ContainsKey((remain, l, r))) return memo[(remain, l, r)];
                if (remain == 0) return (l == r) ? 1 : 0;

                var cnt = 0;
                var use = primes[remain - 1];
                cnt += Search(remain - 1, l + use, r);  // 左の皿
                cnt += Search(remain - 1, l, r + use);  // 右の皿
                cnt += Search(remain - 1, l, r);        // 置かない
                memo.Add((remain, l, r), cnt);
                return cnt;
            }

            Console.WriteLine(Search(primes.Count(), N, 0));
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
