using System;

namespace q52_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 16;

            long max = 0;
            for (int i = 1; i <= N; i++)
            {
                max = (long)Math.Max(max, Math.Pow(i, N - i));
            }
            Console.WriteLine(max);
        }
    }
}
