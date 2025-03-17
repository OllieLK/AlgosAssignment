using System;
using System.IO;



namespace Algorithms
{
    class Program
    {
        // Need to change searching to work with bin sort
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


        public static void DisplayEveryInterval(int[] Array, int Interval)
        {
            for (int i = 0;i < Array.Length - 1; i= i + Interval) {
                Console.WriteLine(Array[i]);
            }
        }
        
        public static int[] BubbleSort(int[] arraytosort, string Direction)
        {
            int temp;
            bool swapped;

            for (int i = 0; i < arraytosort.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < arraytosort.Length - i - 1; j++)
                {
                    if (Direction == "a")
                    {
                        if (arraytosort[j] > arraytosort[j + 1])
                        {
                            temp = arraytosort[j];
                            arraytosort[j] = arraytosort[j + 1];
                            arraytosort[j + 1] = temp;
                            swapped = true;
                        }
                    }
                    else if (Direction == "d")
                    {
                        if (arraytosort[j] < arraytosort[j + 1])
                        {
                            temp = arraytosort[j];
                            arraytosort[j] = arraytosort[j + 1];
                            arraytosort[j + 1] = temp;
                            swapped = true;
                        }
                    }
                }
                if (swapped == false)
                {
                    return arraytosort;
                }
            }
            return arraytosort;
        }
        public static int[] MergeSort(int[] arraytosort, string Direction)
        {
            int length = arraytosort.Length;
            int[] temp = new int[length];

            for (int i = 1; int < length; int *= 2)
            {
                for (int left = 0; left < length - i; left += 2 * i)
                {
                    int mid = left + i - 1;
                    int right =
                }
            }
        }
        public int[] QuickSort(int[] arraytosort, string Direction) { }
        

        public static (List<int>, int) LinearSearch(int[] arraytosearch, int SearchItem)
        {
            arraytosearch = BubbleSort(arraytosearch, "a");
            int closestValue = arraytosearch[0];
            int lowestDifference = closestValue - SearchItem;
            List<int> PositionsOfFounds = new List<int>();

            for (int i = 0; i < arraytosearch.Length; i++) { 
                if (arraytosearch[i] == SearchItem)
                {
                    PositionsOfFounds.Add(i);
                }
                int currentDifference = arraytosearch[i] - SearchItem;
                if (currentDifference < lowestDifference)
                {
                    closestValue = arraytosearch[i];
                    lowestDifference = currentDifference;
                }
            }
            return (PositionsOfFounds, closestValue);
        }
        public static (List<int>, int) BinarySearch(int[] arraytosearch, int SearchItem) {
            arraytosearch = BubbleSort(arraytosearch, "a");
            List<int> PositionsOfFounds = new List<int>();
            int closestValue = arraytosearch[0];
            int lowestDifference = closestValue - SearchItem;
            int left = 0;
            int right = arraytosearch.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arraytosearch[mid] == SearchItem)
                {
                    PositionsOfFounds.Add(mid);

                    int i = mid - 1;
                    while (i >= 0 && arraytosearch[i] == SearchItem)
                    {
                        PositionsOfFounds.Add(i);
                        i--;
                    }

                    int j = mid + 1;
                    while (j < arraytosearch.Length && arraytosearch[j] == SearchItem)
                    {
                        PositionsOfFounds.Add(j);
                        j++;
                    }
                    return (PositionsOfFounds, 0);
                }

                int currentDifference = arraytosearch[mid] - SearchItem;
                if (currentDifference < lowestDifference)
                {
                    closestValue = arraytosearch[mid];
                    lowestDifference = currentDifference;
                }

                if (arraytosearch[mid] < SearchItem)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return (PositionsOfFounds, closestValue);
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Sort Going Up (a) or down (d)");
            string SortDirection = Console.ReadLine();
            Console.WriteLine("Show 256 or 2048 array?");
            int ArrayType = Int16.Parse(Console.ReadLine());    
            Console.WriteLine("Array no 1, 2, or 3?");
            int menuChoice = Int16.Parse(Console.ReadLine());

            switch (ArrayType)
            {
                case 256:
                    switch (menuChoice)
                    {
                        case 1:
                            DisplayEveryInterval(BubbleSort(S1_256, SortDirection), 10);
                            break;
                        case 2:
                            DisplayEveryInterval(BubbleSort(S2_256, SortDirection), 10);
                            break;
                        case 3:
                            DisplayEveryInterval(BubbleSort(S3_256, SortDirection), 10);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2048:
                    switch (menuChoice)
                    {
                        case 1:
                            DisplayEveryInterval(BubbleSort(S1_2048, SortDirection), 50);
                            break;
                        case 2:
                            DisplayEveryInterval(BubbleSort(S2_2048, SortDirection), 50);
                            break;
                        case 3:
                            DisplayEveryInterval(BubbleSort(S3_2048, SortDirection), 50);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }          
        }
        public static void SearchMenu()
        {
            Console.WriteLine("Enter Search Term (Integer)");
            int SearchTerm = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Using linear search or binary search? b/l");
            string SearchType = Console.ReadLine();
            Console.WriteLine("Search 256 or 2048 array?");
            int ArrayType = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Array no 1, 2, or 3?");
            int menuChoice = Int16.Parse(Console.ReadLine());

            int Closest;
            List<int> Values;
            int[] SelectedArray = null;

            switch (ArrayType)
            {
                case 256:
                    switch (menuChoice)
                    {
                        case 1:
                            SelectedArray = S1_256;
                            break;
                        case 2:
                            SelectedArray = S2_256;
                            break;
                        case 3:
                            SelectedArray = S3_256;
                            break;
                        default:
                            break;
                    }
                    break;
                case 2048:
                    switch (menuChoice)
                    {
                        case 1:
                            SelectedArray = S1_2048;
                            break;
                        case 2:
                            SelectedArray = S2_2048;
                            break;
                        case 3:
                            SelectedArray = S3_2048;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (SearchType == "b")
            {
                (Values, Closest) = BinarySearch(SelectedArray, SearchTerm);
            } else
            {
                (Values, Closest) = LinearSearch(SelectedArray, SearchTerm);
            }
            if (Values.Count == 0)
            {
                Console.WriteLine("Not Present In Array, the closest value (In the sorted array) is  ");                
            }
            else
            {
                Console.Write("Found At Position (Within sorted array): ");
                for (int i = 0; i < Values.Count - 1; i++)
                {
                    Console.Write(Values[i] + ", ");
                }
                Console.ReadLine();
            }
        }

        public static void Main(string[] args)
        {
            LoadFiles();
            do
            {
                Console.WriteLine("Select Function:\n[1] Display sorted arrays\n[2] Search Arrays\n[3] Quit");
                int menuChoice = Int16.Parse(Console.ReadLine());
                if (menuChoice == 1)
                {
                    DisplayMenu();
                } else if (menuChoice == 2)
                {
                    SearchMenu();
                } else if (menuChoice == 3)
                {
                    break;
                }
            } while (true);            
        }       
    }
}