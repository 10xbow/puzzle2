using System;
using System.Collections.Generic;

namespace q43_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 7;
            var women = new List<int>(N);
            int factorial = 1;
            for (int i = 0; i < N; i++)
            {
                women.Add(i + 1);
                factorial *= (i + 1);
            }

            long cnt = 0;
            var seat = new Permutation().Enumerate(women);
            foreach (var item in seat)
            {
                var flag = true;
                for (int j = 0; j < N; j++)
                {
                    if ((item[j] - 1 == j) || (item[j] - 1 == (j + 1) % N))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) { cnt++; }
            }

            Console.WriteLine(cnt * factorial / N);
            Console.ReadLine();
        }
    }
}
