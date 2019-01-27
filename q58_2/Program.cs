using System;
using static MyMath;

namespace q58_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 15;

            if (N > 2)
            {
                Console.WriteLine(Catalan(N - 1) * (N - 2) * Math.Pow(2, N - 3));
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
