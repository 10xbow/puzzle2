using System;

namespace q42
{
    class Program
    {
        static void Main(string[] args)
        {
            int W = 99;
            int H = 101;

            var inside = (W - 1) * (H - 1) * 2;
            var outside = (H + W) * 2;
            if ((W != 1) && (H != 1) && ((W % 2 == 0) || (H % 2 == 0)))
            {
                Console.WriteLine(inside + outside - 2);
            }
            else
            {
                Console.WriteLine(inside + outside);
            }
            Console.ReadLine();
        }
    }
}
