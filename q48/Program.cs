using System;
using System.Collections.Generic;
using System.Linq;

namespace q48
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 16;
            int N = 4;

            var Sum = M * (M + 1) / 2;
            var goal = Sum / N;

            int search(int n, List<bool> used, int sum, int card)
            {
                if (n == 1) { return 1; } // 残りが1人になれば終了

                var cnt = 0;
                used[card] = true;        // カードを使用済みに変更
                sum += card;
                if (sum == goal)
                {
                    // 合計が目標に到達すれば、次の人に割り当てていく
                    // (最初に使うカードは未割当のうち最大のもの)
                    cnt += search(n - 1, used, 0, used.FindLastIndex(q => q == false));
                }
                else
                {
                    // 目標に達していないときは、未使用のカードを使用
                    for (int i = Math.Min(card - 1, goal - sum); i > 0; i--)
                    {
                        if (!used[i]) { cnt += search(n, used, sum, i); }
                    }
                }
                used[card] = false; // カードを使用前に戻す
                return cnt;
            }

            if (Sum % N == 0)
            {
                var Used = Enumerable.Repeat(false, M + 1).ToList();
                Console.WriteLine(search(N, Used, 0, M));
            }
            else
            {
                Console.WriteLine(0);
            }
            Console.ReadLine();
        }
    }
}
