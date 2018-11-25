using System;

namespace q47_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 6;
            int N = 6;

            int search(int n, int c)
            {
                if (c <= 2) { return 0; }
                if (n == 1) { return M; }
                return search(n - 1, c) + (M - 1) * search(n - 1, c - 2);
            }

            Console.WriteLine(search(N,N));
            Console.ReadLine();
        }
    }
}
