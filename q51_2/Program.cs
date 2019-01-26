using System;
using System.Collections.Generic;
using System.Linq;

namespace q51_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 1587600;
            Console.WriteLine(Seq(N, new List<int> { }));
        }

        // 1桁ずつ取り出してつなげる
        static long Seq(long remain, IReadOnlyList<int> used)
        {
            if (remain <= 1) return 1;
            long cnt = 0;

            var bit = new Dictionary<int, int> { [2]= 0b0001, [3]= 0b0010, [5]= 0b0100, [6]= 0b0011, [7]= 0b1000, [8]= 0b0001 };

            foreach(var i in bit)
            {
                if ((remain % i.Key == 0) && used.All(n => n > 0))
                {
                    // 割り切れた数を取り出して、途中に平方数がなければ追加
                    var used_map = used.Select(j => j ^ i.Value);
                    var temp = new List<int> { i.Value }.Concat(used_map).ToList();
                    cnt += Seq(remain / i.Key,temp);
                }     
            }
            return cnt;
        }
    }
}
