using System;
using System.Collections.Generic;

namespace q49_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int EXP = 10;

            var memo = new Dictionary<int, double> { [1] = 1 };
            double group_count(int n)
            {
                if (memo.ContainsKey(n)) { return memo[n]; }
                var result = 1.0 / n + group_count(n - 1);
                memo.Add(n, result);
                return result;
            }

            // 人数を1から順に増やす
            var m = 1;
            while (group_count(m) <= EXP)
            {
                // グループ数の期待値を超えるまで繰り返す
                m++;
            }
            Console.WriteLine(m);
            Console.ReadLine();
        }
    }
}
