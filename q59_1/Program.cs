using System;
using System.Collections.Generic;

namespace q59_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 11;
            int A = 25;
            int B = 24;

            var memo = new Dictionary<(int, int), long> { };
            long search(int a, int b)
            {
                if (memo.ContainsKey((a, b))) return memo[(a, b)];

                // 両方がゴールの点数に到達すれば終了
                if ((a == A) && (b == B)) return 1;
                // 先取する点数に一方でも到達して、2点差つくと終了
                if (((a >= N) || (b >= N)) && (Math.Abs(a - b) > 1)) return 0;
                // 一方でもゴールの点数を超えると終了
                if ((a > A) || (b > B)) return 0;
                // いずれかが点数を取った場合を再帰的に探索
                memo.Add((a, b), search(a + 1, b) + search(a, b + 1));
                return memo[(a, b)];
            }

            Console.WriteLine(search(0, 0));
        }
    }
}
