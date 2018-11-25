using System;

namespace q47_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 6;
            int N = 6;

            long cnt = 0;
            for (int i = 1; i <= (N - 1) / 2; i++)
            {
                cnt += M * (long)Math.Pow((M - 1), (i - 1)) * MyMath.NCr(N - 1, i - 1);
            }
            Console.WriteLine(cnt);
            Console.ReadLine();
        }
    }
}
