using System;
using static MyMath;

namespace q59_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 11;
            int A = 25;
            int B = 24;

            if (Math.Max(A, B) > N)
            {
                // デュースになっているとき
                if (Math.Abs(A - B) > 2)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(NCr(2 * N - 2, N - 1) * Math.Pow(2, (Math.Min(A, B) - N + 1)));
                }
            }
            else if (Math.Max(A, B) == N)
            {
                // 先取する点に達したとき
                if (Math.Abs(A - B) == 1)
                {
                    Console.WriteLine(NCr(2 * N - 2, N - 1));
                }
                else
                {
                    Console.WriteLine(NCr(A + B - 1, Math.Min(A, B)));
                }
            }
            else
            {
                // 先取する点に達していないとき
                Console.WriteLine(NCr(A + B, A));
            }
        }
    }
}
