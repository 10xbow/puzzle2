using System;
using System.Collections.Generic;
using System.Linq;

namespace q46
{
    class Program
    {
        static void Main(string[] args)
        {
            int W = 5;
            int H = 4;
            int N = 22;

            var dirs = new Dictionary<int, int> { [1] = 0b1, [-1] = 0b10, [W] = 0b100, [-W] = 0b1000 };

            int search(int pos, int dir, List<int> used, int n)
            {
                if (n < 0) { return 0; }
                if (pos + dir == W * H - 1) { return (n == 0) ? 1 : 0; }

                used[pos] |= dirs[dir];  // 移動元のフラグをセット
                pos += dir;
                used[pos] |= dirs[-dir]; // 移動先のフラグをセット
                
                var cnt = 0;
                foreach (var d in dirs)
                {
                    var m = n - ((dir == d.Key) ? 0 : 1); // 回転すると曲がる回数を減らす
                    if ((used[pos] & d.Value) == 0)
                    {
                        cnt += search(pos, d.Key, used, m);
                    }
                }
                used[pos] ^= dirs[-dir]; // 移動先のフラグを戻す
                pos -= dir;
                used[pos] ^= dirs[dir];  // 移動元のフラグを戻す
                return cnt;
            }

            var Used = Enumerable.Repeat(0, W * H).ToList();
            for (int w = 0; w < W; w++)
            {
                Used[w] |= dirs[-W];              // 上端の上方向は移動済み
                Used[w + (H - 1) * W] |= dirs[W]; // 下端の下方向は移動済み
            }
            for (int h = 0; h < H; h++)
            {
                Used[h * W] |= dirs[-1];          // 左端の左方向は移動済み
                Used[(h + 1) * W - 1] |= dirs[1]; // 右端の右方向は移動済み
            }

            var Cnt = 0;
            Cnt += search(0, 1, Used, N); // 最初に右方向へ
            Cnt += search(0, W, Used, N); // 最初に下方向へ
            Console.WriteLine(Cnt);
            Console.ReadLine();
        }
    }
}
