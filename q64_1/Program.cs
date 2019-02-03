using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace q64_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 98303;
            int width = 0;
            for (int i = 1; i <= N / 2; i++)
            {
                if (NCr(N, i) % 2 == 0)
                {
                    width = i;
                    break;
                }
            }
            Console.WriteLine(width);
        }

        static BigInteger NCr(int n, int r)
        {
            var result = new BigInteger(1);
            for (int i = 1; i <= r; i++)
            {
                result = result * (n - i + 1) / i;
            }
            return result;
        }
    }
}
