using System;
using System.Collections.Generic;
using System.Linq;

namespace q51_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = 1587600;
            Console.WriteLine(Seq(N, new int[] { }));
        }

        // 途中で平方数ができていないかチェック
        public static bool Has_square(IReadOnlyList<int> used)
        {
            var result = false;
            var value = 1;
            for (int i = 0; i < used.Count; i++)
            {
                value *= used[i];
                var sqr = Math.Floor(Math.Sqrt(value));
                if (value == sqr * sqr)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        // 1桁ずつ取り出してつなげる
        public static long Seq(long remain, IReadOnlyList<int> used)
        {
            if (remain <= 1) return 1;
            long cnt = 0;
            var keta = new List<int> { 2, 3, 5, 6, 7, 8 };
            foreach (var num in keta)
            {
                if (remain % num == 0)
                {
                    // 割り切れた数を取り出して、途中に平行数がなければ追加
                    if (!Has_square(used))
                    {
                        var temp = new List<int> { num }.Concat(used).ToList();
                        cnt += Seq(remain / num, temp);
                    }
                }
            }
            return cnt;
        }
    }
}
