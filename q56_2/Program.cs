using System;

namespace q56_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 10;
            int N = 6;

            Console.WriteLine(Check(M, N));
        }

        static long Check(int m, int n)
        {
            if (n == 1) return 3;
            // あいこのときは全員が同じときとm-1C2通り
            long cnt = (3 + (m - 1) * (m - 2) / 2) * Check(m, n - 1);
            for (int i = 2; i < m; i++)
            {
                // 勝った人数
                cnt += 3 * Check(i, n - 1);
            }
            return cnt;
        }
    }
}
