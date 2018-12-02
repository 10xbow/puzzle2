using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q50_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 50;
            int N = 4;

            List<int> check(List<int> used, int x)
            {
                var result = new List<int> { };
                var temp = used.Concat(new int[] { 0 }).ToList();
                for (int i = 0; i < temp.Count(); i++)
                {
                    if (temp.FindIndex(n => n == temp[i] + x) < 0)
                    {
                        result.Add(temp[i] + x);
                    }
                    else
                    {
                        return null;
                    }
                    result.Add(temp[i]);
                }
                return result;
            }

            long search(int n, int prev, List<int> used)
            {
                if (n == 0) return 1;
                long cnt = 0;
                for (int i = prev; i <= M; i++)
                {
                    var next_used = check(used, i);
                    if (next_used != null)
                    {
                        cnt += search(n - 1, i + 1, next_used);
                    }
                }
                return cnt;
            }

            var Used = new List<int> { };
            Console.WriteLine(search(N, 1, Used));
            Console.ReadLine();
        }
    }
}
