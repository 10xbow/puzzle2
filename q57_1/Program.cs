using System;
using System.Collections.Generic;

namespace q57_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int STATION = 32;
            int EXPRESS = 12;
            int LIMITED = 4;

            var memo = new Dictionary<(int, int, int), long> { };
            long search(int s, int e, int l)
            {
                if (memo.ContainsKey((s, e, l))) return memo[(s, e, l)];

                // 最後の駅で急行、特急停車駅が残っていないときカウント
                if ((s == 0) && (e == 0) && (l == 0)) return 1;
                // 最後の駅で、急行、特急停車駅が残っているとカウントしない
                if ((s == 0) && ((e > 0) || (l > 0))) return 0;
                // 最後の駅以外で急行、特急停車駅が残っていないとカウントしない
                if ((e == 0) || (l == 0)) return 0;

                long cnt = 0;
                cnt += search(s - 1, e - 1, l - 1); // 特急停車駅
                cnt += search(s - 1, e - 1, l);     // 急行停車駅
                cnt += search(s - 1, e, l);         // 通過駅
                memo.Add((s, e, l), cnt);
                return cnt;
            }

            Console.WriteLine(search(STATION - 1, EXPRESS - 1, LIMITED - 1));
        }
    }
}
