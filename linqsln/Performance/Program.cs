using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Enumerable.Range(0, 100000000);
            bool exits = a.Any();
            Console.WriteLine(exits);
            foreach (var item in a.Take(100).Skip(50).Where(x=>x%2==0).TakeWhile(y=>y<=90).SkipWhile(x=>x<60))
            {
                Console.Write(item);
            }
            Console.WriteLine(a.First(x=>x%1237==0));
            Console.WriteLine(a.FirstOrDefault(x=>x*234==9475200));
            //Console.WriteLine(a.Single());
            Console.WriteLine(a.Single(x=>x==199));
            Console.ReadKey();
        }
    }
}
