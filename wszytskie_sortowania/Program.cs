using System;
using System.Diagnostics;
using System.IO;

//    Przetestuj i porównaj(Stopwatch) napisane przez nas metody testowania: 
//    bąbelkowe, bąbelkowe poprawione, przez scalanie, szybkie, przez wybieranie, przez wstawianie.
//    Zinterperetuj wyniki.

class Program
{
    static void BabelSort(int[] L)
    {
        int N = L.Length;

        for (int i = 0; i < N; i++)
        {
            for (int j = N - 1; j > i; j--)
            {
                if (L[j] < L[j - 1])
                {
                    int t = L[j - 1];
                    L[j - 1] = L[j];
                    L[j] = t;
                }
            }
        }
    }


    static void BabelSort1(int[] L)
    {
        int N = L.Length;

        for (int i = 0; i < N; i++)
        {
            bool posortowana = true;
            for (int j = N - 1; j > i; j--)
            {
                if (L[j] < L[j - 1])
                {
                    int t = L[j - 1];
                    L[j - 1] = L[j];
                    L[j] = t;
                    posortowana = false;
                }
            }
            if (posortowana)
            {
                break;
            }
        }
    }



    static void Scalaj(int[] T, int p, int mid, int k, int[] T2)
    // p - poczatek, k - koniec, mid - srodek
    // łączy 2 posortowane tablice T[p...mid] i T[mid+1...k]
    {

        int p1 = p, k1 = mid; // pod-tablica 1
        int p2 = mid + 1, k2 = k;   // pod-tablica 2
                                    // aż do wyczerpania tablic dokonaj scalenia przy pomocy tablicy pomocniczej
        int i = p1;
        while ((p1 <= k1) && (p2 <= k2))
        {
            if (T[p1] < T[p2])
            {
                T2[i] = T[p1]; p1++;
            }
            else
            {
                T2[i] = T[p2]; p2++;
            }
            i++;
        }
        while (p1 <= k1)
        {
            T2[i] = T[p1]; p1++; i++;
        }
        while (p2 <= k2)
        {
            T2[i] = T[p2]; p2++; i++;
        }
        // skopiuj z tablicy tymczasowej do oryginalnej
        for (i = p; i <= k; i++)
            T[i] = T2[i];
    }

    static void MergeSort(int[] T, int p, int k, int[] T2)
    {
        if (p < k)
        {
            int mid = (p + k) / 2;  // środek
            MergeSort(T, p, mid, T2);   // sortuj lewą połowę
            MergeSort(T, mid + 1, k, T2); // sortuj prawą połowę
            Scalaj(T, p, mid, k, T2);   // scalaj
        }
    }

    static int Podzial(int[] T, int l, int p)
    {
        int i, j, klucz, tmp, index;

        index = (l + p) / 2;
        //index = l;
        //index = p;

        klucz = T[index];
        // zamien element centralny z prawym
        tmp = T[index];
        T[index] = T[p];
        T[p] = tmp;

        i = l;
        for (j = l; j < p; j++)
        {
            if (T[j] <= klucz)
            {// jeżeli pierwszy element to spełnia to zasadniczo jest tylko i++
                tmp = T[i];
                T[i] = T[j];
                T[j] = tmp;
                i++;
            }
        }
        // na lewo od i-tego elementy mniejsze
        // wstaw element centralny na swoje miejsce
        tmp = T[i];
        T[i] = T[p];
        T[p] = tmp;

        return i;
    }



    static void QuickSort(int[] T, int l, int p)
    {
        if (l >= p) return;
        int i = Podzial(T, l, p);
        QuickSort(T, l, i - 1);
        QuickSort(T, i + 1, p);
    }

    static void SortujWyb(int[] L)
    {
        for (int i = 0; i < L.Length; i++)
        {        // szukamy najmniejszego elementu w A (i, N - 1)         
            int k = i;
            for (int j = i + 1; j < L.Length; j++)
                if (L[k] > L[j]) k = j;
            // zamieniamy z go z elementem i-tym        
            int t = L[k]; L[k] = L[i]; L[i] = t;
        }
    }

    static void SortujWstaw(int[] L)
    {
        int k, j;
        for (int i = 1; i < L.Length; i++)
        {
            k = L[i];
            j = i;
            while (j > 0 && L[j - 1] > k)
            {
                L[j] = L[j - 1]; // przesuwam elementy
                j--;
            }
            L[j] = k; // wstawiam w odpowiednie miejsce
        }
    }
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader("plik1.txt");
        string line;
        int size = 0;
        int[] tab = new int[100000];
        int[] t = new int[100000];
        int[] t2 = new int[100000];
        while ((line = sr.ReadLine()) != null)
        {
            t[size] = Convert.ToInt32(line);
            size++;
        }
        sr.Close();

        Stopwatch stoper = new Stopwatch();

        for (int i = 0; i < t.Length; i++)
            tab[i] = t[i];

        stoper.Reset();
        stoper.Start();
        BabelSort(tab);
        stoper.Stop();
        Console.Write(tab.Length + " babelkowe " + stoper.ElapsedTicks + ";");
        Console.WriteLine();

        for (int i = 0; i < t.Length; i++)
            tab[i] = t[i];

        stoper.Reset();
        stoper.Start();
        BabelSort1(tab);
        stoper.Stop();
        Console.Write(tab.Length + " babelkowe 1 " + stoper.ElapsedTicks + ";");
        Console.WriteLine();

        for (int i = 0; i < t.Length; i++)
            tab[i] = t[i];

        stoper.Reset();
        stoper.Start();
        MergeSort(tab, 0, tab.Length - 1, t2);
        stoper.Stop();
        Console.Write(tab.Length + " scalanie " + stoper.ElapsedTicks + ";");
        Console.WriteLine();


        for (int i = 0; i < t.Length; i++)
            tab[i] = t[i];

        stoper.Reset();
        stoper.Start();
        QuickSort(tab, 0, tab.Length - 1);
        stoper.Stop();
        Console.Write(tab.Length + " szybkie " + stoper.ElapsedTicks + ";");
        Console.WriteLine();


        for (int i = 0; i < t.Length; i++)
            tab[i] = t[i];

        stoper.Reset();
        stoper.Start();
        SortujWyb(tab);
        stoper.Stop();
        Console.Write(tab.Length + " wybieranie " + stoper.ElapsedTicks + ";");
        Console.WriteLine();

        for (int i = 0; i < t.Length; i++)
            tab[i] = t[i];

        stoper.Reset();
        stoper.Start();
        SortujWstaw(tab);
        stoper.Stop();
        Console.Write(tab.Length + " wstawianie " + stoper.ElapsedTicks + ";");
        Console.WriteLine();

        Console.ReadKey();
    }
}

//p3
//100000 babelkowe   464560769;
//100000 babelkowe 1 470056413;
//100000 scalanie       363220;
//100000 szybkie        306017;
//100000 wybieranie  205193954;
//100000 wstawianie  126488699;

//p2
//100000 babelkowe    405970113;
//100000 babelkowe 1  415699858;
//100000 scalanie        232290;
//100000 szybkie         145616;
//100000 wybieranie   217334175;
//100000 wstawianie   271491424;

// p1
//100000 babelkowe     213509938;
//100000 babelkowe 1        5487;
//100000 scalanie         237030;
//100000 szybkie          111762;
//100000 wybieranie    201641488;
//100000 wstawianie         9133;
