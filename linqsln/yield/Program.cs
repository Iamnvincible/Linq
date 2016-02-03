using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yield
{
    public static class MyLinq
    {
        //一个扩展方法
        //public static IEnumerable<string> MyWhere(this IEnumerable<string> source)
        //{
        //    foreach (string item in source)
        //    {
        //        if (item.Length < 2)
        //            yield return item;
        //    }
        //}
        //public static IEnumerable<string> MyWhere(this IEnumerable<string> source,Func<string,bool> predicate)
        //{
        //    foreach (string item in source)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //    }
        //}
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }
        public static IEnumerable<string> MySelect(this IEnumerable<int> source,Func<int,string> selector)
        {
            foreach (int item in source)
            {
                yield return selector(item);
            }
        }
        public static IEnumerable<TResult> MySelect<TSource,TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int,TResult> selector)
        {
            int index = 0;
            foreach (TSource item in source)
            {
                yield return selector(item,index++);
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var sequence = GenerateStrings();
            sequence = sequence.Where(x => x.Length < 2);
            var sequence2 = GenerateStrings();
            //sequence2 = sequence2.MyWhere();
            sequence2 = sequence2.MyWhere(x=>x.Length<2);
            var sequence3 = GenerateIntegers().MyWhere(x => x % 7 == 0);
            var sequence4 = GenerateIntegers().Select(x => x.ToString());
            var sequence5 = GenerateIntegers().Select(x =>true);
            var sequence6 = GenerateIntegers().MySelect((x,index)=>new { index, str=x.ToString()+"str" });
            foreach (var s in sequence6)
            {
                Console.WriteLine("{0}=={1}", s.index, s.str);
            }
            foreach (var item in sequence)
            {
                Console.WriteLine(item.ToString());
            }
            foreach (var item in sequence2)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
        static IEnumerable<string> GenerateStrings()
        {
            for (int i = 8; i < 100; i++)
            {
                yield return i.ToString();
            }
        }
        static IEnumerable<int> GenerateIntegers()
        {
            for (int i = 8; i < 100; i++)
            {
                yield return i;
            }
        }

    }
}
//List<string> a0 = new List<string> { "aaa", "bbb" };
//List<string> a1 = new List<string> { "ccc", "ddd" };
//List<List<string>> b = new List<List<string>> { a0,a1 };
//var c = b.Select(x => x);//两个foreach
//var c1 = a1.Select(x => x);//一次
//var d = b.SelectMany(x => x);//一次
