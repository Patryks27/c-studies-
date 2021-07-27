﻿using System;

//Skonstruuj algorytm znajdowania silnego przywódcy metodą dziel i zwyciężaj.
//    Zbadaj złożoność stworzonego algorytmu 
//    i równanie rekurencyjne jakie jest związane ze złożonością tego algorytmu

class Program
{
    static int Przywodca(int[] tab, int p, int k)
    {
        if (p == k)
            return tab[p];
        int s = (p + k) / 2;
        int k1 = Przywodca(tab, p, s);
        int k2 = Przywodca(tab, s + 1, k);
        if (k1 == k2)
            return k1;
        int kk1 = 0, kk2 = 0;
        for (int i = p; i <= k; i++)
        {
            if (tab[i] == k1) kk1++;
            if (tab[i] == k2) kk2++;
        }
        if (kk1 > kk2)
            return k1;
        else
            return k2;
    }

    // T(n) = T(n/2) + T(n/2) + n
    // T(1) = 1;
    // rozwiazanie
    // n + nlgn
    // n= 2^k

    static void Main(string[] args)
    {
        int[] ciag0 = new int[] { 0, 1, 0, 1, 0, 1, 1, 1, 2, 1, 2, 1, 2 };

        int k = Przywodca(ciag0, 0, ciag0.Length - 1);
        Console.WriteLine(k);

        Console.ReadKey();
    }
}

