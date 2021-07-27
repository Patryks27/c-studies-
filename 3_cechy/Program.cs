using System;

class Program
{
    static int[] Zliczanie012(int[] T) // klucz tylko 0 1 2
    {
        int n = T.Length;
        int[] W = new int[n]; // tablica zawierająca elementy posortowane
        int[] L = new int[3]; // zawiera liczbę elementów o danej wartości odpowiednio 0, 1, 2
        int i;

        // zerowanie tablicy liczników
        for (i = 0; i < 3; i++) L[i] = 0;

        // zliczanie wystąpień elementów o kluczu i
        for (i = 0; i < n; i++) L[T[i]]++;

        // ile elementów jest mniejszych i równych danej wartości o kluczu i
        for (i = 1; i < 3; i++) L[i] += L[i - 1];

        // wstawienie elementu na odpowiednią pozycję i aktualizacja licznika
        for (i = n - 1; i >= 0; i--)
        {
            int p = L[T[i]];
            W[p - 1] = T[i];
            L[T[i]]--;
        }

        return W;
    }

    static void Main(string[] args)
    {
        int[] T = { 2, 0, 0, 1, 2, 0, 1, 0, 1, 2, 0, 1, 0, 2, 2, 1 };
        int[] W = Zliczanie012(T);

        for (int i = 0; i < W.Length; i++)
            Console.Write(W[i] + " ");
        Console.ReadKey();
    }
}
