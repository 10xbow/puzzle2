using System;
using System.Collections.Generic;
using System.Linq;

namespace q69
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 25;

            // 数を分解する
            var memo = new Dictionary<(int, int), List<List<int>>> { };
            List<List<int>> split(int n, int pre)
            {
                if (memo.ContainsKey((n, pre))) return memo[(n, pre)];
                var result = new List<List<int>> { };

                // 直前の数より大きいものを順に調べる
                for (int i = pre; i <= ((n - 1) / 2); i++)
                {
                    result.Add(new List<int> { i, n - i });
                    foreach (var j in split(n - i, i + 1))
                    {
                        var temp = new List<int> { i };
                        j.ForEach(k => temp.Add(k));
                        result.Add(temp);
                    } 
                }
                memo.Add((n, pre), result);
                return result;
            }

            // 左から順に調べる
            int search(List<int> used, int pos)
            {
                if (used.Count == pos) return 1;
                // 次の数を調べる
                var cnt = search(used, pos + 1);
                foreach (var i in split(used[pos], 1))
                {
                    // 調べる数で分解し、同じ数字が無ければ次を探索
                    var flag = true;
                    for (int j = 0; j < i.Count; j++)
                    {
                        if (used.Contains(i[j]))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) cnt += search(used.Concat(i).ToList(), pos + 1);
                }
                return cnt;
            }

            Console.WriteLine(search(new List<int> { N }, 0));
        }
    }
}
