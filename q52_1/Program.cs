using System;
using System.Collections.Generic;
using System.Linq;

namespace q52_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 16;
            var remain = new Stack<int> { };
            remain.Push(N);
            Console.WriteLine(Search(remain, Enumerable.Range(1,N-1).ToList()));
        }

        static long Search(Stack<int> used, List<int> remain)
        {
            long max = 0;
            if (remain.Count() > 0)
            {
                max = 1;
                foreach (var r in remain)
                {
                    long cnt = 0;
                    cnt = used.Count(u => u > r);
                    max *= cnt;
                }

            }
            for (int i = 0; i < remain.Count(); i++)
            {
                if (used.Peek() > remain[i])
                {
                    used.Push(remain[i]);
                    remain.RemoveAt(i);
                    max = Math.Max(max, Search(used, remain));
                    remain.Insert(i,used.Pop());
                }
            }
            return max;
        }
    }
}
