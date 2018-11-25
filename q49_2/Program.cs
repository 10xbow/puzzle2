using System;

namespace q49_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var EXP = 10;

            var m = 0;
            var sum = 0.0;
            while (sum <= EXP)
            {
                // グループ数の期待値を超えるまで繰り返す
                m++;
                sum += 1.0 / m;
            }
            Console.WriteLine(m);
            Console.ReadLine();
        }
    }
}
