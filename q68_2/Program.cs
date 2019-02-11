using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q68_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5;

            // 左右と中央の文字のリストを準備
            var l = new List<string> { "DHLPTXdh", "AEIMQUYaei", "BFJNRVZbfj" };
            var c = "QUY";
            var r = new List<string> { "QRSTUVYZ", "PQRSTUVXYZ", "PQRSTUVXYZ" };

            // 文字列から重複を除外
            string unique(string str)
            {
                var uniq = new string(str.Distinct().ToArray());
                var sorted = new string(uniq.ToCharArray().OrderBy(o => o).ToArray());
                return sorted;
            }

            // 3文字に使われている文字の数で集計
            var ascii = new Dictionary<int, Dictionary<string, int>> { };
            for (int i = 0; i < c.Length; i++)
            {
                for (int j = 0; j < l[i].Length; j++)
                {
                    var uniq = unique($"{l[i][j]}{c[i]}{r[i][j]}");
                    var cnt = uniq.Length;
                    if (!ascii.ContainsKey(cnt)) ascii.Add(cnt,new Dictionary<string, int> { });
                    if (ascii[cnt].ContainsKey(uniq))
                    {
                        ascii[cnt][uniq]++;
                    }
                    else
                    {
                        ascii[cnt].Add(uniq, 1);
                    }
                }
            }
            foreach (var i in ascii)
            {
                Console.WriteLine(i.Key);
                foreach (var j in i.Value)
                {
                    Console.WriteLine($"{j.Key}:{j.Value}");
                }
            }

            // n : 文字列の長さ
            // d : 文字列の種類

            Dictionary<string, int> search(int n, int d)
            {
                if (n == 1) return ascii.ContainsKey(d) ? ascii[d] : new Dictionary<string, int> { };
                var result = new Dictionary<string, int> { };
                for (int i = 1; i <= d; i++)
                {
                    var chars = search(n - 1, i);
                    foreach (var char1 in chars.Keys)
                    {
                        foreach (var len in ascii.Keys)
                        {
                            foreach (var char2 in ascii[len].Keys)
                            {
                                var uniq = $"{char1}{char2}";
                                if (uniq.Length == d)
                                {
                                    if (!result.ContainsKey(uniq)) result.Add(uniq, 0);
                                    result[uniq] += chars[char1] * ascii[len][char2];
                                }
                            }
                        }
                    }
                }
                return result;
            }

            var sum = 0;
            var Chars = search(N, N);
            foreach (var item in Chars)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            sum = Chars.Sum(s => s.Value);
            Console.WriteLine(sum);
        }
    }
}
