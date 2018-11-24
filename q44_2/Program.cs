using System;

namespace q44_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 12345;

            int trit(int n)
            {
                if (n == 0) { return 1; }
                int a = 0;
                while (Math.Pow(3, a + 1) <= n)
                {
                    a++;
                }
                int x = n - (int)Math.Pow(3, a);
                int y = (int)Math.Pow(3, a) - 1;
                return (int)Math.Pow(2, a) + trit(Math.Min(x, y));
            }

            Console.WriteLine(trit(N));
            Console.ReadLine();
        }
    }
}
