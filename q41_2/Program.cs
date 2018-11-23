using System;
using System.Collections.Generic;
using System.Linq;

namespace q41_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int W = 10;
            int H = 10;

            var memo = new Dictionary<List<int>, long>(new MyEqualityComparer()) { };
            long search(List<int> tile)
            {
                if (memo.ContainsKey(tile)) { return memo[tile]; }

                // 最後まで探索すれば完了
                if (tile.Min() == H) { return 1; }

                // タイルを置く位置
                var pos = tile.FindIndex(m => m == tile.Min());
                long cnt = 0;
                var tiles = new List<(int w, int h)> { (1, 1), (2, 2), (4, 2), (4, 4) };
                foreach (var item in tiles)
                {
                    // タイルを置けるかチェック
                    var check = true;
                    for (int x = 0; x < item.w; x++)
                    {
                        if ((pos + x >= W) || (tile[pos + x] + item.h > H))
                        {
                            // 配置できないとき
                            check = false;
                        }
                        else if (tile[pos + x] != tile[pos])
                        {
                            // 使用済みの位置があったとき
                            check = false;
                        }

                    }
                    if (!check) { break; } // 置けない場合はスキップ

                    // タイルを置いて次を探す
                    for (int x = 0; x < item.w; x++)
                    {
                        tile[pos + x] += item.h;
                    }
                    cnt += search(tile);
                    // タイルを元に戻す
                    for (int x = 0; x < item.w; x++)
                    {
                        tile[pos + x] -= item.h;
                    }
                }
                memo[tile] = cnt;
                return cnt;
            }

            var Tile = Enumerable.Repeat(0, W).ToList();
            Console.WriteLine(search(Tile));
            Console.ReadLine();
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
}
