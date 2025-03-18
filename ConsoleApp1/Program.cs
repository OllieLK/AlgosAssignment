using System;
using System.ComponentModel;
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
        public static int[] MergeSort(int[] arrayToSort, string direction)
        {            
            int n = arrayToSort.Length;
            int[] tempArray = new int[n];

            // Iterative bottom-up merge sort
            for (int size = 1; size < n; size *= 2)
            {
                for (int leftStart = 0; leftStart < n - size; leftStart += 2 * size)
                {
                    int left = leftStart;
                    int mid = leftStart + size;
                    int right = Math.Min(leftStart + 2 * size, n);
                    int i = left, j = mid, k = left;

                    while (i < mid && j < right)
                    {
                        if ((direction == "a" && arrayToSort[i] <= arrayToSort[j]) ||
                            (direction == "d" && arrayToSort[i] >= arrayToSort[j]))
                        {
                            tempArray[k++] = arrayToSort[i++];
                        }
                        else
                        {
                            tempArray[k++] = arrayToSort[j++];
                        }
                    }

                    while (i < mid)
                    {
                        tempArray[k++] = arrayToSort[i++];
                    }

                    while (j < right)
                    {
                        tempArray[k++] = arrayToSort[j++];
                    }

                    for (i = left; i < right; i++)
                    {
                        arrayToSort[i] = tempArray[i];
                    }
                }
            }
            return arrayToSort;
        }

        public static void LinearSearch(int[] arrayToSearch, int searchItem)
        {
            List<int> indexes = new List<int>();
            int closestValue = arrayToSearch[0];
            int minDiff = Math.Abs(arrayToSearch[0] - searchItem);

            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                if (arrayToSearch[i] == searchItem)
                {
                    indexes.Add(i);
                }
                else
                {
                    int diff = Math.Abs(arrayToSearch[i] - searchItem);
                    if (diff < minDiff || (diff == minDiff && arrayToSearch[i] < closestValue))
                    {
                        minDiff = diff;
                        closestValue = arrayToSearch[i];
                    }
                }
            }
            if (indexes.Count == 0)
            {
                Console.WriteLine("Not Present In Array, the closest value is: " + closestValue);
            }
            else
            {
                Console.Write("Found At Position (Indexing starts at 0): ");
                for (int i = 0; i < indexes.Count; i++)
                {
                    Console.Write(indexes[i] + ", ");
                }
                Console.ReadLine();
            }
        }
        public static void BinarySearch(int[] arr, int searchTerm)
        {
            arr = BubbleSort(arr, "a");
            int left = 0, right = arr.Length - 1;
            List<int> indexes = new List<int>();
            int closestValue = arr[0];
            int minDiff = Math.Abs(arr[0] - searchTerm);
            bool found = false;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == searchTerm)
                {
                    found = true;
                    indexes.Add(mid);

                    // Find duplicates on both sides using binary search
                    int temp = mid - 1;
                    while (temp >= 0 && arr[temp] == searchTerm)
                    {
                        indexes.Add(temp);
                        temp--;
                    }

                    temp = mid + 1;
                    while (temp < arr.Length && arr[temp] == searchTerm)
                    {
                        indexes.Add(temp);
                        temp++;
                    }

                    break; // No need to continue binary search
                }

                int diff = Math.Abs(arr[mid] - searchTerm);
                if (diff < minDiff || (diff == minDiff && arr[mid] < closestValue))
                {
                    minDiff = diff;
                    closestValue = arr[mid];
                }

                if (arr[mid] < searchTerm)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            if (found)
            {
                Console.Write("Found at positions (Within array - after its been sorted): ");
                Console.WriteLine(string.Join(", ", indexes));
            }
            else
            {
                Console.WriteLine("Not present in array, closest value is: " + closestValue);
            }
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
                BinarySearch(SelectedArray, SearchTerm);
            else
                LinearSearch(SelectedArray, SearchTerm);            
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