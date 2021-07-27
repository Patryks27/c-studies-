using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortwanie_przez_scalanie
{
    class Program
    {
        //złoąoznośc algotyrmu alna
        static void scalanie(int[] tab, int l, int r)
        {
            int[] pom = new int[tab.Length];
            for (int i = l; i <= r; i++)
            {
                pom[i] = tab[i];
            }
            int licznik = l;
            int srod = (l + r) / 2 + 1;
            int sstale = (l + r) / 2 + 1;
            while (l< sstale && srod <=r)
            {
                if(pom[l]<pom[srod])
                {
                    tab[licznik] = pom[l];
                    l++;
                }
                else
                {
                    tab[licznik] = pom[srod];
                    srod++;
                }
                licznik++;
            }

            while(l < sstale)
            {
                tab[licznik] = pom[l];
                l++;
                licznik++;
            }
        }
        static void Sortowanie_Scalanie(int [] tab, int l,int r)
        {
            if(l<r)
            {
                Sortowanie_Scalanie(tab,l, (l + r) / 2);
                Sortowanie_Scalanie(tab, ((l + r) / 2) + 1, r);
                scalanie(tab, l, r);
            }
        }
        static void Main(string[] args)
        {
            int[] tab = { 985, 1, 7, 3, -34, 34, 1, -123 ,-23};
            Sortowanie_Scalanie(tab, 0, tab.Length - 1);
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }
            Console.ReadKey();
        }
    }
}
