using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCountSum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> alist = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                alist.Add(i.ToString());
            }
            var re=alist.Any();
            var ree = alist.Any(x => x.Length == 1);
            var reee = alist.Count(x => x.Length == 1);
            var reeee = alist.Sum(x =>int.Parse(x));
            Console.ReadLine();
        }
    }
}
