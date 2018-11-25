using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q50_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 50;
            int N = 4;

            long search(int n, int prev, long used)
            {
                if (n == 0) { return 1; }
                long cnt = 0;
                for (int i = prev; i <= M; i++)
                {
                    if ((used & (used << i)) == 0)
                    {
                        cnt += search(n - 1, i + 1, used | (used << i));
                    }
                }
                return cnt;
            }

            Console.WriteLine(search(N, 1, 1));
            Console.ReadLine();
        }
    }
}
