using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public interface IOrderingImpl<T> : IEnumerable<T>
    {
        int compareTo(T left, T right);
        IEnumerable<T> OriginalSource { get; }
    }
    public class MyOrderedEnumerable<T, TKey> : IOrderingImpl<T>, IEnumerable<T> where TKey :IComparable<TKey>
    {
        private Comparison<T> comparison;
        private IEnumerable<T> source;
        public MyOrderedEnumerable(IEnumerable<T> source, Func<T, TKey> comparer)
        {
            this.source = source;
            comparison = (a, b) => comparer(a).CompareTo(comparer(b));
        }
        public IEnumerable<T> OriginalSource
        {
            get
            {
                return source;
            }
        }

        public int compareTo(T left, T right)
        {
            return comparison(left, right);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var sorted = source.ToList();
            sorted.Sort(comparison);
            return sorted.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static class Mylinq
    {
        public static MyOrderedEnumerable<T, TKey> MyOrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> comparer) where TKey : IComparable<TKey>
        {
            return new MyOrderedEnumerable<T, TKey>(source, comparer);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var result = SequenceFromConsole().MyOrderBy(x =>x.Length);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        static IEnumerable<string> SequenceFromConsole()
        {
            string a = "";
            while (a != "done")
            {
                a = Console.ReadLine();
                yield return a;
            }
        }
    }
}
