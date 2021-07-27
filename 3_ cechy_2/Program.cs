using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Flaga(ref int[] tab) //złożoność liniowa
    {
        int lewy = 0;
        int prawy = tab.Length - 1;
        int srodek = 0;
        while (srodek <= prawy)
        {
            if (tab[srodek] == 0)
            {
                swap(ref tab[lewy++], ref tab[srodek++]);
            }
            else if (tab[srodek] == 2)
            {
                swap(ref tab[srodek], ref tab[prawy--]);
            }
            else
            {
                srodek++;
            }
        }
    }
    static void swap(ref int a, ref int b)
    {
        int tmp = a;
        a = b;
        b = tmp;
    }

    static void Main(string[] args)
    {

        //int[] tab =  { 1, 2, 1, 0, 0, 1, 0, 2, 0, 1, 2, 2, 1, 1,0,0};
        int[] tab = { 2,1,0,0,0,0,0,2,0,1,1,1 };
        Flaga(ref tab);

        for (int i = 0; i < tab.Length; i++)
        {
            Console.Write(tab[i] + " ");
        }

        Console.ReadKey();

        Console.ReadKey();
    }
}