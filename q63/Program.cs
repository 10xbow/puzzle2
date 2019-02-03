using System;

namespace q63
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 60;
            int N = 60;

            // 最大公約数を再帰で求める
            int gcd(int a, int b)
            {
                if (b == 0) return a;
                return gcd(b, a % b);
            }

            // 最小公倍数を求める
            int lcm(int a, int b)
            {
                return a * b / gcd(a, b);
            }

            int min;
            int max;

            if (M == N)
            {
                (min, max) = (M, 2 * M);
            }
            else if (gcd(M, N) == 1)
            {
                (min, max) = (M * N, M * N);
            }
            else
            {
                (min, max) = (lcm(M, N), 2 * lcm(M, N));
            }

            Console.WriteLine(min);
            Console.WriteLine(max);
        }
    }
}
