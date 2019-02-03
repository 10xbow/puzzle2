using System;
using System.Collections.Generic;
using System.Linq;

namespace q62
{
    class Program
    {
        static void Main(string[] args)
        {
            int H = 10;
            int W = 7;

            var pins = Enumerable.Repeat(0, W * H).ToList();

            // 壊れた数を増やしながら探索
            var broken = 0;
            var done = false;
            for (int i = 0; i < W * H / 2; i++)
            {
                broken = i;
                search(0, broken);
                if (done) break;
            }

            // 壊れた洗濯バサミを配置した状態で、何通りの使い方があるか調査

            int check(List<int> temp)
            {
                var connect = Enumerable.Repeat(0, W * H).ToList();
                int remain = 0;
                int single = 0;
                for (int i = 0; i < temp.Count(); i++)
                {
                    if (temp[i] == 0)
                    {
                        // 配置されていない場合、上下左右の空き状況をチェック
                        if ((i % W != 0) && (temp[i - 1] == 0)) connect[i]++;
                        if ((i % W != W - 1) && (temp[i + 1] == 0)) connect[i]++;
                        if ((i / W != 0) && (temp[i - W] == 0)) connect[i]++;
                        if ((i / W != H - 1) && (temp[i + W] == 0)) connect[i]++;
                        remain++; // 配置されていない洗濯バサミをカウント
                        if (connect[i] == 1) single++; // 1通りに決まる位置の数
                    }
                }
                if (single > 0)
                {
                    for (int i = 0; i < W * H; i++)
                    {
                        if ((connect[i] == 1) && (temp[i] == 0))
                        {
                            // 1通りに決まる場合、使う
                            temp[i] = 1;
                            if ((i % W != 0) && (temp[i] == 0))
                            {
                                temp[i - 1] = 1;
                            }
                            else if ((i % W != W - 1) && (temp[i + 1] == 0))
                            {
                                temp[i + 1] = 1;
                            }
                            else if ((i / W != 0) && (temp[i - W] == 0))
                            {
                                temp[i - W] = 1;
                            }
                            else if ((i / W != H - 1) && (temp[i + W] == 0))
                            {
                                temp[i + W] = 1;
                            }
                            else
                            {
                                return 1; // 配置できない
                            }
                        }
                    }
                    return check(temp);
                }
                else
                {
                    return remain;
                }
            }

            // 壊れた洗濯バサミを再帰的に配置
            // pos: 配置する位置
            // depth: 配置する数
            void search(int pos, int depth)
            {
                if (depth == 0)
                {
                    // 配置完了
                    if (check(pins.Concat(new List<int> { }).ToList()) == 0)
                    {
                        // 1通りに決まったときは出力して終了
                        Console.WriteLine(broken);
                        done = true;
                    }
                    return;
                }
                if (pos == W * H) return; // 探索完了
                if (pins[pos] == 0)
                {
                    // 配置していないとき
                    if ((pos % W < W - 1) && (pins[pos + 1] == 0))
                    {
                        // 横に配置
                        (pins[pos], pins[pos + 1]) = (1, 1);
                        search(pos, depth - 1);
                        (pins[pos], pins[pos + 1]) = (0, 0);  
                    }
                    if (done) return;
                    if ((pos / W < H - 1) && (pins[pos + W] == 0))
                    {
                        // 縦に配置
                        (pins[pos], pins[pos + W]) = (1, 1);
                        search(pos, depth - 1);
                        (pins[pos], pins[pos + W]) = (0, 0);
                    }
                }
                if (done) return;
                search(pos + 1, depth); // 次を探索
            }
        }
    }
}
