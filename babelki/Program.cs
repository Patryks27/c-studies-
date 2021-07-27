using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babelki
{
    class Program
    {
        static public void bobelkowe(int [] tab)
        {
            int a = 0;
            int b = 0;
            int n = tab.Length;
            int pom;
            for(int i=n-1;i>0;i--)
            {
                for(int j=0;j<i;j++)
                {
                    if(tab[j]>tab[j+1])
                    {
                        pom = tab[j];
                        tab[j] = tab[j+1];
                        tab[j+1] = pom;
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            int[] tab = { -8,-94, 2, 764, 3, 67, 9, 43, -7 };
            bobelkowe(tab);
            for(int i=0;i<tab.Length;i++)
            {
                Console.WriteLine(tab[i]);
            }
            Console.ReadKey();
        }
    }
}
