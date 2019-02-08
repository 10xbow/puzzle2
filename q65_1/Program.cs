using System;
using System.Collections.Generic;
using System.Linq;

namespace q65_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 7;

            // n-Queenを生成
            var queens = new List<List<int>> { };
            void queen(List<int> rows, int n, int left, int down, int right)
            {
                if (n == N)
                {
                    queens.Add(new List<int>(rows));
                    return;
                }
                for (int i = 0; i < N; i++)
                {
                    var pos = 1 << i;
                    if ((pos & (left | down | right)) == 0)
                    {
                        // 他のコマの利きに入っていないとき
                        rows[n] = pos;
                        // 左下、真下、右下を設定し、次の行を探索
                        (var l, var d, var r) = (left | pos, down | pos, right | pos);
                        queen(rows, n + 1, l << 1, d, r >> 1);
                    }
                }
            }

            var Rows = Enumerable.Repeat(0, N).ToList();
            queen(Rows, 0, 0, 0, 0);

            var white = Enumerable.Repeat(0, N).ToList();
            var black = Enumerable.Repeat((1 << N) - 1, N).ToList();

            var fw_log = new Dictionary<List<int>, int>(new MyEqualityComparer()) { [white] = 0 };
            var fw = new List<List<int>> { white };

            var depth = 1;
            while (true)
            {
                // 幅優先検索
                var fw_next = new List<List<int>> { };
                foreach (var f in fw)
                {
                    foreach (var q in queens)
                    {
                        var check = new List<int> { };
                        for (int i = 0; i < N; i++)
                        {
                            check.Add(f[i] ^ q[i]);
                        }
                        // 過去に登場したパターンかチェック
                        if (!fw_log.ContainsKey(check))
                        {
                            fw_next.Add(check);
                            fw_log[check] = depth;
                        }
                    }
                }
                fw = fw_next;
                // 次のチェック対象がなくなれば終了
                if (fw.Count == 0) break;
                // すべて反転できれば終了
                if (fw_log.ContainsKey(black)) break;
                depth++;
            }
            if (fw_log.ContainsKey(black))
            {
                Console.WriteLine(fw_log[black]);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }

    public class MyEqualityComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x.SequenceEqual(y))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(List<int> obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Count; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i];
                }
            }
            return result;
        }
    }
}
