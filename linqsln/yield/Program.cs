using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yield
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in getnubers())
            {
                Console.WriteLine(item.ToString());
            }
        }
        static IEnumerable<int> getnubers()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
            }
        }
    }
}
