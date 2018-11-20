using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var q = new List<(int, int)> { pos };

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
        }
    }
}
