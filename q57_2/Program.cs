using System;
using static MyMath;

namespace q57_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int STATION = 32;
            int EXPRESS = 12;
            int LIMITED = 4;

            Console.WriteLine(NCr(STATION - 2, EXPRESS -2) * NCr(EXPRESS - 2, LIMITED - 2));
        }
    }
}
