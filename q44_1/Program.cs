using System;

namespace q44_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 12345;

            int cnt = 0;
            for (int i = 0; i <= N; i++)
            {
                if(!RadixConvert.ToString(i,3,true).Contains("2")) { cnt++; }
            }

            Console.WriteLine(cnt);
            Console.ReadLine();
        }
    }
}
