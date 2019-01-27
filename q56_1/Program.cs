using System;
using static MyMath;

namespace q56_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 10;
            int N = 6;
            Console.WriteLine(Check(M, N));
        }

        static long Aiko(int n)
        {
            long cnt = 3; // 全員が同じもの（グーだけ、パーだけ、チョキだけ）
            // グー、チョキ、パーが1人ずつと、残りを加える
            if (n >= 3) cnt += NHr(3, n - 3);
            return cnt;
        }

        static long Check(int m, int n)
        {
            // 1回で勝つのはグーで勝つ、チョキで勝つ、パーで勝つ、の3通り
            if (n == 1) return 3;
            long cnt = Aiko(m) * Check(m, n - 1);
            for (int i = 2; i < m; i++)
            {
                // 勝った人数
                cnt += 3 * Check(i, n - 1);
            }
            return cnt;
        }
    }
}
