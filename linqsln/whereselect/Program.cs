using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whereselect
{
    public static class MyLinqImplementation
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in GenerateSequence())
            {
                Console.WriteLine(item);
            }
        }
        static IEnumerable<string> GenerateSequence()
        {
            var i = 0;
            while (i++ < 100)
                yield return i.ToString();
        }
    }
}
