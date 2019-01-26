using System;
using System.Collections.Generic;

namespace q53
{
    class Program
    {
        static void Main(string[] args)
        {
            int W = 500;
            int N = 10000;

            var primes = new List<int> { };
            for (int i = 2; i < N; i++)
            {
                var flag = true;
                for (int j = 2; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) primes.Add(i);
            }

            var left = 0;
            var right = 0;
            primes.ForEach(p => right += p);

            while (left + 1 < right)
            {
                var mid = (int)Math.Floor((left + right) / 2.0);
                var cnt = 1;
                var weight = 0;
                foreach (var p in primes)
                {
                    if (weight + p < mid)
                    {
                        weight += p;
                    }
                    else
                    {
                        weight = p;
                        cnt++;
                    }
                }
                if (W >= cnt)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }
            Console.WriteLine(left);
        }
    }
}
