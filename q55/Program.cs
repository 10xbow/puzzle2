using System;
using System.Collections.Generic;
using System.Linq;

namespace q55
{
    class Program
    {
        static void Main(string[] args)
        {
            var W = 6;
            var H = 3;

            // 反転するマスクの作成
            var mask = new List<int> { };
            for (int h = 0; h < H; h++)
            {
                for (int w = 0; w < W; w++)
                {
                    // 中心と上下左右を反転対象とする
                    var pos = 1 << (w + h * W);
                    if (w > 0)     pos |= 1 << (w - 1 + h * W);
                    if (w < W - 1) pos |= 1 << (w + 1 + h * W);
                    if (h > 0)     pos |= 1 << (w + (h - 1) * W);
                    if (h < H - 1) pos |= 1 << (w + (h + 1) * W);
                    mask.Add(pos);
                }
            }

            // チェック済みの配置と反転回数
            var _checked = new Dictionary<int, int>
            {
                [0] = 0,
                [(1 << (W * H)) - 1] = 0,
            };
            // 全部白か全部黒からスタート
            var queue = new List<int> { };
            queue.Add(0);
            queue.Add((1 << (W * H)) - 1);
            var n = 0;
            while (queue.Count() > 0)
            {
                var temp = new List<int> { };
                for (int i = 0; i < queue.Count(); i++)
                {
                    for (int j = 0; j < mask.Count(); j++)
                    {
                        // すべての位置について探索
                        if (!_checked.ContainsKey(queue[i] ^ mask[j]))
                        {
                            // 未チェックの場合、次のチェック対象に追加
                            temp.Add(queue[i] ^ mask[j]);
                            _checked[queue[i] ^ mask[j]] = n;
                        }
                    }
                }
                queue = temp;
                n++;
            }
            Console.WriteLine(n - 1);
        }
    }
}
