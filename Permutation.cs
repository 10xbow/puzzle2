using System.Collections.Generic;
using System.Linq;

public class Permutation
{
    public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items)
    {
        if (items.Count() == 1)
        {
            yield return new T[] { items.First() };
            yield break;
        }
        foreach (var item in items)
        {
            var leftside = new T[] { item };
            var unused = items.Except(leftside);
            foreach (var rightside in Enumerate(unused))
            {
                yield return leftside.Concat(rightside).ToArray();
            }
        }
    }
}
