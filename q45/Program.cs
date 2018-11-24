using System;

namespace q45
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 9;

            if (N <= 3)
            {
                Console.WriteLine(0);
            }
            else
            {
                var factorial = 1;
                for (int i = 1; i <= N; i++)
                {
                    factorial *= i;
                }
                Console.WriteLine(factorial * (N - 3) / 6);
                Console.ReadLine();
            }
        }
    }
}
