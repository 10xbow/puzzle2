using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q64_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 98303;

            var temp = Convert.ToString(N, 2).ToCharArray().ToList();
            temp.Reverse();
            int m = temp.IndexOf('0');
            Console.WriteLine(m != 0 ? Math.Pow(2, m).ToString() : "");
        }
    }
}
