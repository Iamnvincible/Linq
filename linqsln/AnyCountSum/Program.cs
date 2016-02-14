using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCountSum
{
    public static class mylinq
    {
        public static bool Myany(this IEnumerable<string> source)
        {
            return source.GetEnumerator().MoveNext();
        }
        public static bool Myany<T>(this IEnumerable<T> source)
        {
            return source.GetEnumerator().MoveNext();
        }
        public static bool Myany<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Where(predicate).GetEnumerator().MoveNext();
        }
        public static int Mycount<T>(this IEnumerable<T> source)
        {
            int count = 0;
            foreach (var item in source)
            {
                count++;
            }
            return count;
        }
        public static int Mycount<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
           return source.Where(predicate).Count();
        }
        public static int Mysum(this IEnumerable<int> source)
        {
            int sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }
            return sum;
        }
        public static int Mysum<T>(this IEnumerable<T>source,Func<T,int> predicate)
        {
            int sum = 0;
            foreach (var item in source)
            {
                sum += predicate(item);
            }
            return sum;
        }
        public static int Myaggregate(this IEnumerable<int> source,Func<int,int,int> func)
        {
            int sum = 0;
            foreach (var item in source)
            {
                sum = func(sum, item);
            }
            return sum;
        }
        public static T Myaggregate<T>(this IEnumerable<T> source,Func<T,T,T> func)
        {
            var sum = default(T);
            foreach (var item in source)
            {
                sum = func(sum, item);
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(SequenceFromConsole().Mycount(x => x.Contains("zy")));
            List<string> alist = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                alist.Add(i.ToString());
            }
            var re = alist.Any();
            var ree = alist.Any(x => x.Length == 1);
            var reee = alist.Count(x => x.Length == 1);
            var reeee = alist.Sum(x => int.Parse(x));
            Console.ReadLine();
            var mre = alist.Myany();
            var mree = alist.Myany(x => x.Length == 1);
            //foreach (var item in input)
            //{
            //    Console.WriteLine("\t" + item);
            //}
        }
        static IEnumerable<string> SequenceFromConsole()
        {
            string tex = "";
            while (tex != "done")
            {
                yield return tex;
                tex = Console.ReadLine();
            }
        }
    }
}
