﻿using System.Collections.Generic;

static class MyMath
{
    internal static long NCr(int N, int R)
    {
        var memo = new Dictionary<(int, int), long> { };
        long nCr(int n, int r)
        {
            if (memo.ContainsKey((n, r))) { return memo[(n, r)]; }
            if ((r == 0) || (r == n)) { return 1; }
            var result = nCr(n - 1, r - 1) + nCr(n - 1, r);
            memo.Add((n, r), result);
            return result;
        }
        return nCr(N, R);
    }

    internal static long Factorial(int N)
    {
        long result = 1;
        for (int i = 1; i <= N; i++)
        {
            result *= i;
        }
        return result;
    }
}