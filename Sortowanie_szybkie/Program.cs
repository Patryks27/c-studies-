using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie_szybkie
{//złożonośc obliczeniowa nlogn
    class Program
    {
        public static void Szybkie_Sortowanie(int []tab,int l,int r)
        {
            int i = (r + l) / 2;
            int klucz = tab[i];
            tab[i] = tab[r];
            int j = l;
            i = l;
            while(i<r)
            {
                if(tab[i]<klucz)
                {
                    int pom = tab[i];
                    tab[i] = tab[j];
                    tab[j] = pom;
                    j++;
                }
                i++;
            }
            tab[r] = tab[j];
            tab[j] = klucz;
            if(l<j -1)
            {
                Szybkie_Sortowanie(tab, l, j - 1);
            }
            if(j+1 <r)
            {
                Szybkie_Sortowanie(tab, j + 1,r);
            }
        }
        static void Main(string[] args)
        {
            int[] tab = { 5,1,7,3,-34,34,1,-123 };
            Szybkie_Sortowanie(tab, 0, tab.Length-1);
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }
            Console.ReadKey();
        }
    }
}
