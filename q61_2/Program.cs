using System;
using System.Collections.Generic;
using System.Linq;

namespace q61_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 20;

            var z = new List<List<long>>(N + 1) { };
            for (int i = 0; i <= N; i++)
            {
                z.Add(Enumerable.Repeat((long)0, i + 1).ToList());
            }
            z[0][0] = 1;
            for (int n = 1; n <= N; n++)
            {
                for (int k = 1; k <= n; k++)
                {
                    z[n][k] = z[n][k - 1] + z[n - 1][n - k];
                }
            }
            Console.WriteLine(2 * z[N][N]);
        }
    }
}
