using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryExpression
{
    class Employee
    {
        public int Age { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            var square = numbers.Select(n => new { n, Square = n * n });
            var square2 = from n in numbers select new { n, Square = n * n };
            foreach (var item in square)
            {
                Console.WriteLine(item.Square);
            }
            foreach (var item in square2)
            {
                Console.WriteLine(item.n);
            }

            join();
            Console.ReadLine();
        }
        public static void whereandselect(IEnumerable<Employee> employee)
        {
            var people = from n in employee where n.Age > 20 orderby n.LastName, n.FirstName, n.Age descending select n;
            var people2 = employee.Where(n => n.Age > 20).OrderBy(n => n.LastName).ThenBy(n => n.FirstName).ThenByDescending(n => n.Age);
        }
        public static void join()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            string[] labels = { "1", "3", "5", "8", "9", "0" };
            var query = from n in numbers join la in labels on n.ToString() equals la select new { n, la };
            var query2 = numbers.Join(labels, n => n.ToString(), la => la, (n, la) => new { n, la });
            foreach (var item in query)
            {
                Console.Write(item.n);
            }
            foreach (var item in query2)
            {
                Console.Write(item.la);
            }
        }
        public static void groupjoin(IEnumerable<Employee> em, IEnumerable<Employee> en)
        {
            var query = from n in em join t in en on n.Department equals t.Department into samedepart select new { n.Department, samedepart };
            var query2 = em.GroupJoin(en, m => m.Department, n => n.Department, (n, dep) => new { n.Department, dep });

            var query3 = em.GroupBy(e => e.Department).Select(d => new { d.Key, size = d.Count() });
            var query31 = em.GroupBy((e)=> e.Department).Select(d => new { d.Key, ordered= from x in d orderby x.LastName select x });
        }
        public static void selectmany()
        {
            int[] odds = { 1, 3, 5, 7, 9 };
            int[] evens = { 2, 4, 6, 8 };
            var values = from o in odds from e in evens where o<e  select new { o, e, sum=o + e };
            var values2 = odds.SelectMany(odd=>evens,(o,e)=>new { o, e }).Where(p=>p.o<p.e).Select(pair=>new { pair.o,pair.e,sum=pair.e+pair.o});
        }
    }
}
