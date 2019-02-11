using System;
using System.Collections.Generic;
using System.Linq;

namespace q68_1
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

            int search(int n, bool flag, string left, string right)
            {
                if (n == 0)
                {
                    var ary = left + right;
                    var uniq = new string(ary.Distinct().ToArray());
                    return (uniq.Length == N) ? 1 : 0;
                }
                var cnt = 0;
                for (int i = 0; i < c.Length; i++) // 中央の文字を決定
                {
                    for (int j = 0; j < l[i].Length; j++) // 左右の文字を決定
                    {
                        // 交互に配置しながら探索
                        if (flag)
                        {
                            cnt += search(n - 1, !flag, left + l[i][j].ToString(), c[i].ToString() + r[i][j].ToString() + right);
                        }
                        else
                        {
                            cnt += search(n - 1, !flag, left + c[i].ToString() + r[i][j].ToString(), l[i][j].ToString() + right);
                        }
                    }
                }
                return cnt;
            }

            Console.WriteLine(search(N, true, "", ""));
        }
    }
}
