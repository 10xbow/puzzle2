﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace q41_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int W = 10;
            int H = 10;

            var memo = new Dictionary<(List<int>, int), long>(new MyEqualityComparer()) { };
            long search(List<int> tile, int pos)
            {
                if (memo.ContainsKey((tile, pos))) { return memo[(tile, pos)]; }

                // 最後まで探索すれば完了
                if (pos == W * H) { return 1; }

                // すでに使用済みなら次を探索
                if (tile[pos] == 1) { return search(tile, pos + 1); }

                long cnt = 0;
                var tiles = new List<(int, int)> { (1, 1), (2, 2), (4, 2), (4, 4) };
                foreach (var item in tiles)
                {
                    // タイルを置けるかチェック
                    var check = true;
                    for (int x = 0; x < item.Item1; x++)
                    {
                        for (int y = 0; y < item.Item2; y++)
                        {
                            if ((pos % W >= W - x) || (pos / W >= H - y))
                            {
                                // 配置できないとき
                                check = false;
                            }
                            else if (tile[pos + x + y * W] == 1)
                            {
                                // 使用済みの位置があったとき
                                check = false;
                            }
                        }
                    }
                    if (!check) { break; } // 置けない場合はスキップ

                    // タイルを置いて次を探す
                    for (int x = 0; x < item.Item1; x++)
                    {
                        for (int y = 0; y < item.Item2; y++)
                        {
                            tile[pos + x + y * W] = 1;
                        }
                    }
                    cnt += search(tile, pos + 1);
                    // タイルを元に戻す
                    for (int x = 0; x < item.Item1; x++)
                    {
                        for (int y = 0; y < item.Item2; y++)
                        {
                            tile[pos + x + y * W] = 0;
                        }
                    }
                }
                memo[(tile, pos)] = cnt;
                return cnt;
            }

            var Tile = Enumerable.Repeat(0, W * H).ToList();
            Console.WriteLine(search(Tile, 0));
            Console.ReadLine();
        }

        public class MyEqualityComparer : IEqualityComparer<(List<int>,int)>
        {
            public bool Equals((List<int>, int) x, (List<int>, int) y)
            {
                if (x.Item1.SequenceEqual(y.Item1) && x.Item2 == y.Item2)
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode((List<int>, int) obj)
            {
                int result = 17;
                for (int i = 0; i < obj.Item1.Count; i++)
                {
                    unchecked
                    {
                        result = result * 23 + obj.Item1[i];
                    }
                }
                result = result + obj.Item2 * 1000;
                return result;
            }
        }
    }
}
