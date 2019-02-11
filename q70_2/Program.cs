using System;

namespace q70_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 10;
            int N = 12;

            // 「使われている数」の最大値
            var sum = M + N - 1;
            // 平均に近い値
            var ave = Math.Floor(sum / M * 1.0);

            var kind = 0;
            for (int i = 1; i <= M; i++)
            {
                if (sum == ave * i + (ave + 1) * (M - i))
                {
                    kind = (int)Math.Ceiling(N * (i / ave + (M - i) / (ave + 1)));
                    break;
                }
            }
            Console.WriteLine(kind);
        }
    }
}
