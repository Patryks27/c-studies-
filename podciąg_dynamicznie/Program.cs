using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    // złożoność O(n*m)
    static void DL(string s1, string s2)
    {
        int m = s1.Length, n = s2.Length;
        int[,] L = new int[m + 1, n + 1];
        int i = 0, j = 0;
        for (i = 0; i < m + 1; i++) L[i, 0] = 0;
        for (j = 0; j < n + 1; j++) L[0, j] = 0;

        for (i = 0; i < m; i++)
        {
            for (j = 0; j < n; j++)
            {
                if (s1[i] == s2[j])
                {
                    L[i + 1, j + 1] = L[i, j] + 1;
                }
                else
                {
                    L[i + 1, j + 1] = Math.Max(L[i, j + 1], L[i + 1, j]);
                }

            }
        }
        string s = "";
        i = m - 1;
        j = n - 1;
        while (i >= 0 && j >= 0)
        {
            if (s1[i] == s2[j])
            {
                s = s1[i] + s;
                i--;
                j--;

            }
            else if (L[i + 1, j] > L[i, j + 1]) j--;

            else i--;

        }
        Console.WriteLine(s + " " + L[m, n]);
    }

    static void Main(string[] args)
    {
        string s1 = "ABCBDAB";
        string s2 = "BDCABA";
        string s3 = "abaabbaaa";
        string s4 = "babab";
        string s5 = "TOALETA";
        string s6 = "POLITECHNIKA";
        DL(s1, s2);
        DL(s3, s4);
        DL(s5, s6);
        Console.ReadKey();
    }
}