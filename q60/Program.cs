using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q60
{
    class Program
    {
        static void Main(string[] args)
        {
            var memo = new Dictionary<(List<int>, int), int>(new GenericEqualityComparer<(List<int>, int), int>);
            var uniq = new Dictionary<List<int>, bool>(new MyEqualityComparer());
            // 順に探索
            int search(List<int> board, int user)
            {
                if (memo.ContainsKey(board, user)) return memo[board, user];
                if (Check(board, -user))
                {
                    uniq[board] = true;
                    return 1;
                }
                var cnt = 0;
                for (int i = 0; i < 9; i++)
                {
                    if (board[i] == 0)
                    {
                        board[i] = user;
                        cnt += search(board, -user);
                        board[i] = 0;
                    }
                }
                memo.Add(board, user)
            }
        }

        static bool Check(List<int> board, int user)
        {
            for (int i = 0; i < 3; i++)
            {
                // 縦方向と横方向のチェック
                if (((board[i * 3] == user) &&
                     (board[i * 3] == board[i * 3 + 1]) &&
                     (board[i * 3] == board[i * 3 + 2])) ||
                    ((board[i] == user) &&
                     (board[i] == board[i + 3]) &&
                     (board[i] == board[i + 6])))
                {
                    return true;
                }
            }
            // 斜め方向のチェック
            if ((board[4] == user) &&
                (((board[0] == board[4]) && (board[4] == board[8])) ||
                 ((board[2] == board[4]) && (board[4] == board[6]))))
            {
                return true;
            }
            return false;
        }
    }

    public class MyEqualityComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> x, IList<int> y)
        {
            if (x.Count != y.Count)
            {
                return false;
            }
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(IList<int> obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Count; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i];
                }
            }
            return result;
        }
    }

    public class MyEqualityComparer2 : IEqualityComparer<(IList<int>, int)>
    {
        public bool Equals((IList<int>, int) x, (IList<int>, int) y)
        {
            if ((x.Item1.Count != y.Item1.Count) || (x.Item2 != y.Item2))
            {
                return false;
            }
            for (int i = 0; i < x.Item1.Count; i++)
            {
                if (x.Item1[i] != y.Item1[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode((IList<int>, int) obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Item1.Count; i++)
            {
                unchecked
                {
                    result = result * 23 + obj.Item1[i];
                }
            }
            return result + obj.Item2;
        }
    }

    public class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        private Func<T, T, bool> _predicate;
        private Func<T, int> _gethash;

        public GenericEqualityComparer(Func<T, T, bool> predicate)
            : this(predicate, obj => obj.GetHashCode())
        {
        }
        public GenericEqualityComparer(Func<T, T, bool> predicate, Func<T, int> gethash)
        {
            _predicate = predicate;
            _gethash = gethash;
        }

        public bool Equals(T x, T y)
        {
            return _predicate(x, y);
        }
        public int GetHashCode(T obj)
        {
            return _gethash(obj);
        }
    }
}
