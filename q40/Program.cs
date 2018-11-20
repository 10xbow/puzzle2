using System;
using System.Collections.Generic;
using System.Linq;

namespace q40
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 12;

            // 移動距離をチェック
            int check(IList<int> island)
            {
                var pos = (0, N);
                var q = new Queue<(int, int)>();
                q.Enqueue(pos);
                var log = new Dictionary<(int, int), int> { [pos] = 0 };
                int left = 0;
                int right = 0;
                while (q.Count > 0) // 幅優先検索を実施
                {
                    (left, right) = q.Dequeue();
                    for (int l = left - 1; l <= left + 1; l += 2)
                    {
                        for (int r = right - 1; r < right + 1; r += 2)
                        {
                            // 両方が同じ位置になれば終了
                            if (l == r)
                            {
                                return log[(left, right)] + 2;
                            }
                            if ((l >= 0) && (r <= N) && (island[l] == island[r]))
                            {
                                if ((l < r) && !log.ContainsKey((l, r)))
                                {
                                    // AがBより左にあり、未探索であれば次を探索
                                    q.Enqueue((l, r));
                                    log[(l, r)] = log[(left, right)] + 2;
                                }
                            }
                        }
                    }
                }
                return -1; // 距離を求められなかった場合
            }

            int search(IList<int> island, int left, int level)
            {
                island[left] = level; // 島の高さをセット
                // すべてセットしたら、移動距離をチェック
                if (left == N) { return check(island); }

                int max = -1;
                if (level > 0) // 開始地点より上の場合下がる
                {
                    max = Math.Max(max, search(island, left + 1, level - 1));
                }
                if (left + level < N) // 山を作れる場合、上がる
                {
                    max = Math.Max(max, search(island, left + 1, level + 1));
                }
                return max;
            }
            var i = Enumerable.Repeat(0, N + 1).ToList();
            Console.WriteLine(search(i, 0, 0));
            Console.ReadLine();
        }
    }
}
