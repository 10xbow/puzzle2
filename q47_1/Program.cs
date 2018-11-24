using System;

namespace q47_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 6;
            int N = 6;

            // 圧縮処理
            int compress(string str)
            {
                var len = 2;
                var pre = str[0];
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != pre) // 直前の文字と違えば切り替える
                    {
                        pre = str[i];
                        len += 2;
                    }
                }
                return len;
            }

            // すべてのパターンを生成
            int make_str(string str)
            {
                if (str.Length == N)
                {
                    return (str.Length > compress(str)) ? 1 : 0;
                }
                var cnt = 0;
                for (int i = 0; i < M; i++)
                {
                    cnt += make_str(str + i);
                }
                return cnt;
            }

            Console.WriteLine(make_str(""));
            Console.ReadLine();
        }
    }
}
