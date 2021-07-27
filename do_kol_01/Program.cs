using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;//dodaćbiblioteke

namespace do_kol_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
           Console.WriteLine(2 + 2);
            sw.Stop();
            long czas = sw.ElapsedTicks;
            sw.Reset();
            Console.WriteLine(czas);
            Console.ReadKey();
        }
    }
}
