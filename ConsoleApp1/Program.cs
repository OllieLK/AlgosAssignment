using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
/*
 * PRAGMA ONCE
 * 
 * 
 * 
 * 
 */


namespace Algorithms
{
    class Program
    {
        public static int[] S1_256, S1_2048, S2_256, S2_2048, S3_256, S3_2048;
        public static string[] sS1_256, sS1_2048, sS2_256, sS2_2048, sS3_256, sS3_2048;
        public static int[] ConvertToInteger(string[] s)
        {
            int[] a = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                a[i] = Convert.ToInt32(s[i]);
            }
            return a;
        }
        public static bool LoadFiles()
        {
            sS1_256 = File.ReadAllLines("Share_1_256.txt");
            sS1_2048 = File.ReadAllLines("Share_1_2048.txt");
            sS2_256 = File.ReadAllLines("Share_2_256.txt");
            sS2_2048 = File.ReadAllLines("Share_2_2048.txt");
            sS3_256 = File.ReadAllLines("Share_3_256.txt");
            sS3_2048 = File.ReadAllLines("Share_3_2048.txt");

            S1_256 = ConvertToInteger(sS1_256);
            S1_2048 = ConvertToInteger(sS1_2048);
            S2_256 = ConvertToInteger(sS2_256);
            S2_2048 = ConvertToInteger(sS2_2048);
            S3_256 = ConvertToInteger(sS3_256);
            S3_2048 = ConvertToInteger(sS3_2048);
            return true;
        }
        public static int[] BubbleSort(int[] arraytosort)
        {
            int temp;
            bool swapped;

            for (int i = 0; i < arraytosort.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < arraytosort.Length - i - 1; j++)
                {
                    if (arraytosort[j] > arraytosort[j + 1])
                    {
                        temp = arraytosort[j];
                        arraytosort[j] = arraytosort[j + 1];
                        arraytosort[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped = false)
                {
                    return arraytosort;
                }
            }
            return arraytosort;
        }
        public static List<int> LinearSearch(int[] arraytosearch int SearchItem)
        {
            List<int> PositionsOfFounds = new List<int>();
            for (int i = 0; i < arraytosearch.Length - 1; i++) { 
                if (arraytosearch[i] == SearchItem)
                {
                    PositionsOfFounds.Add(i);
                }
            }
            return PositionsOfFounds;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("");
            LoadFiles();
            
            Console.WriteLine(S2_256[6]);
        }       
    }
}