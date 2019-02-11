using System;

namespace q70_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 10;
            int N = 12;

            int search(int m, int n)
            {
                if (m <= 0) return 0;
                if (m == 1) return 1;

                // m >= nのときは等差数列の和で求められる
                if (m >= n) return n * (2 * m - n + 1) / 2;

                // 「1」をセットする行数を取得
                var max = n - m + 1;
                // 配置したものを除外して残りを再帰的に探索
                return (m - 1) * max + 1 + search(m - max, n - max);
            }

            Console.WriteLine(search(M, N));
        }
    }
}
