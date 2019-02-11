using System;
using System.Collections.Generic;
using System.Linq;

namespace q66_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 20;
            int N = 100;

            int search(int m, int n, List<int> vote)
            {
                if (m == 0) return (n == 0) ? 1 : 0;
                int cnt = 0;
                for (int i = vote[m]; i <= n / m; i++)
                {
                    vote[m - 1] = i;
                    if ((vote[m - 1] % vote[M - 1]) == 0)
                    {
                        cnt += search(m - 1, n - i, vote);
                    }
                }
                return cnt;
            }

            var Vote = Enumerable.Repeat(0, M + 1).ToList();
            Vote[M] = 1;
            Console.WriteLine(search(M, N, Vote));
        }
    }
}
