using System;
using System.Collections.Generic;
using System.Linq;

namespace q65_2
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

            bool array_and(List<List<int>> a,List<List<int>> b)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    for (int j = 0; j < b.Count; j++)
                    {
                        var flag = true;
                        for (int k = 0; k < N; k++)
                        {
                            if (a[i][k] != b[j][k]) flag = false;
                        }
                        if (flag) return true;
                    }
                }
                return false;
                // return a.Zip(b,(x,y) => (a,b)).All(x => x.a.SequenceEqual(x.b));
            }

            var white = Enumerable.Repeat(0, N).ToList();
            var black = Enumerable.Repeat((1 << N) - 1, N).ToList();

            var fw_log = new Dictionary<List<int>, int>(new MyEqualityComparer()) { [white] = 0 };
            var bw_log = new Dictionary<List<int>, int>(new MyEqualityComparer()) { [black] = 0 };
            var fw = new List<List<int>> { white };
            var bw = new List<List<int>> { black };

            var depth = 1;
            while (true)
            {
                // 順方向
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
                if (fw.Count == 0 || array_and(fw, bw)) break;
                depth++;

                // 逆方向
                var bw_next = new List<List<int>> { };
                foreach (var b in bw)
                {
                    foreach (var q in queens)
                    {
                        var check = new List<int> { };
                        for (int i = 0; i < N; i++)
                        {
                            check.Add(b[i] ^ q[i]);
                        }
                        // 過去に登場したパターンかチェック
                        if (!bw_log.ContainsKey(check))
                        {
                            bw_next.Add(check);
                            bw_log[check] = depth;
                        }
                    }
                }
                bw = bw_next;
                // 次のチェック対象がなくなれば終了
                if ((bw.Count == 0) || array_and(fw, bw)) break;
                depth++;
            }
            if (array_and(fw, bw))
            {
                Console.WriteLine(depth);
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
