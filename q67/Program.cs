using System;
using System.Collections.Generic;
using System.Linq;

namespace q67
{
    class Program
    {
        static void Main(string[] args)
        {
            int W = 4;
            int H = 7;
            int n = 4;

            // 移動方向
            var MASK = (1 << (W * H)) - 1;
            var left = 0;
            var right = 0;
            for (int i = 0; i < H; i++)
            {
                left = (left << W) | ((1 << (W - 1)) - 1);
                right = (right << W) | ((1 << W) - 2);
            }

            // 移動した位置をビット演算で算出
            var move = new List<Func<int, int>>
            {
                m => (m >> 1) & left,
                m => (m >> 1) & left, // 右
                m => (m << W) & MASK, // 上
                m => (m << 1) & right, // 左
                m => m >> W, // 下
            };

            // 有効な迷路かを判定
            bool enable(int maze)
            {
                // 左上からスタート
                var man = (1 << (W * H - 1)) & (MASK - maze);
                while (true)
                {
                    var next_man = man;
                    foreach (var m in move)
                    {
                        next_man |= m(man); // 上下左右に移動
                    }
                    next_man &= (MASK - maze); // 壁以外の部分が移動可能
                    if ((next_man & 1) == 1) return true; //  右下にたどり着けば成功
                    if (man == next_man) break;
                    man = next_man;
                }
                return false;
            }

            // map:壁の配置
            // p1, d1: 1人目の位置、移動方向
            int search(int maze, int p1, int d1, int depth)
            {
                if (p1 == 1) return depth;
                for (int i = 0; i < move.Count; i++)
                {
                    // 右手法で動ける方向を探索
                    var d = (d1 - 1 + i + move.Count) % move.Count;
                    if ((move[d](p1) & (MASK - maze)) > 0)
                    {
                        return search(maze, move[d](p1), d, depth + 1);
                    }
                }
                return 0;
            }

            var max = 0;
            var maze_array = Enumerable.Range(0, W * H).ToList();
            var wall = maze_array.Combination(n);
            for (int i = 0; i < wall.Count; i++)
            {
                var maze = 0;
                for (int j = 0; j < wall[i].Count; j++)
                {
                    maze |= 1 << wall[i][j];
                }
                if (enable(maze))
                {
                    var man_a = 1 << (W * H - 1);
                    // 左上から下方向に移動
                    max = Math.Max(search(maze, man_a, 3, 1), max);
                }
            }
            Console.WriteLine(max);
        }
    }

    // 配列に対して組み合わせを列挙する
    static class ListExtensions
    {
        public static List<List<int>> Combination(this List<int> L, int n)
        {
            var result = new List<List<int>> { };
            if (n == 0) return result;
            for (int i = 0; i <= L.Count - n; i++)
            {
                if (n > 1)
                {
                    var combi = L.Skip(i).ToList().Combination(n - 1);
                    for (int j = 0; j < combi.Count; j++)
                    {
                        result.Add(new List<int> { L[i] }.Concat(combi[j]).ToList());
                    }
                }
                else
                {
                    result.Add(new List<int> { L[i] });
                }
            }
            return result;
        }
    }
}
