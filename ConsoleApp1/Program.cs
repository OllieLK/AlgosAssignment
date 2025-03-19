using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
/// PROGRAM: STOCK MARKET VOLUME ANALYZER
/// AUTHOR: OLIVER LAZARUS-KEENE 29218390
/// DATE: 
/// 
/// DESCRIPTION:
/// This program is a console based C# application that reads stock exchange values and can
/// sort and search them using various algorithms. there is a main menu which will display
/// within the console when the application is ran, from there the user can select from the
/// several functions and the output will be displayed accordingly
/// 
/// DEPENDANCIES:
/// All of the share .txt files must be placed in ConsoleApp1/bin/Debug/net8.0
/// They were placed in there and working correctly when submitted, they are using relative
/// addressing so should work correctly regardless of machine. They are submitted within the zip file in their
/// own folder if any issues should arise.
/// 
/// 
/// ALGORITHMS USED:
/// Bubble sort, Merge sort, Quick sort.
/// Linear search, Binary search.
/// 
/// PROGRAMMED IN VISUAL STUDIO.


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

        public static void DisplayEveryInterval(int[] Array, int Interval)
        {
            for (int i = 0;i < Array.Length - 1; i= i + Interval) {
                Console.WriteLine(Array[i]);
            }
        }
        
        public static void MergeTwoFiles()
        {
            int[] array1 = null;
            int[] array2 = null;
            int interval = 0;
            Console.WriteLine("256 or 2048 arrays?");
            string arraySize = Console.ReadLine();
            if (arraySize == "256")
                interval = 20;
            else
                interval = 80;
            Console.WriteLine("Select array no 1. (1, 2 or 3)");
            string choice1 = Console.ReadLine();
            Console.WriteLine("Select array no 2. (1, 2 or 3)");
            string choice2 = Console.ReadLine();

            switch (arraySize)
            {
                case "256":
                    switch (choice1)
                    {
                        case "1":
                            array1 = S1_256;
                            break;
                        case "2":
                            array1 = S2_256; 
                            break;
                        case "3":
                            array1 = S3_256;
                            break;
                    }
                    switch (choice2)
                    {
                        case "1":
                            array2 = S1_256;
                            break;
                        case "2":
                            array2 = S2_256;
                            break;
                        case "3":
                            array2 = S3_256;
                            break;
                    }
                    break;
                case "2048":
                    switch (choice1)
                    {
                        case "1":
                            array1 = S1_2048;
                            break;
                        case "2":
                            array1 = S2_2048;
                            break;
                        case "3":
                            array1 = S3_2048;
                            break;
                    }
                    switch (choice2)
                    {
                        case "1":
                            array2 = S1_2048;
                            break;
                        case "2":
                            array2 = S2_2048;
                            break;
                        case "3":
                            array2 = S3_2048;
                            break;
                    }
                break;
            }
            Console.WriteLine("Press enter to concatenate, and then mergesort the result. it will then print every 20 values for 256 length arrays, and 80 for 2048 arrays.");
            Console.ReadLine();
            int[] ConcatArray = array1.Concat(array2).ToArray();
            DisplayEveryInterval(MergeSort((ConcatArray), "a"), interval);
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
        public static int[] QuickSort(int[] arrayToSort, string direction)
        {
            throw new NotImplementedException();
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
            
            Console.WriteLine("Using Bubble(b), Merge(m), Or Quicksort(q)");
            string SortType = Console.ReadLine();
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
                            switch (SortType)
                            {
                                case "b":
                                    DisplayEveryInterval(BubbleSort(S1_256, SortDirection), 10);
                                    break;
                                case "m":
                                    DisplayEveryInterval(MergeSort(S1_256, SortDirection), 10);
                                    break;
                                case "d":
                                    DisplayEveryInterval(QuickSort(S1_256, SortDirection), 10);
                                    break;
                            }
                            break;
                        case 2:
                            switch (SortType)
                            {
                                case "b":
                                    DisplayEveryInterval(BubbleSort(S2_256, SortDirection), 10);
                                    break;
                                case "m":
                                    DisplayEveryInterval(MergeSort(S2_256, SortDirection), 10);
                                    break;
                                case "d":
                                    DisplayEveryInterval(QuickSort(S2_256, SortDirection), 10);
                                    break;
                            }
                            break;
                        case 3:
                            switch (SortType)
                            {
                                case "b":
                                    DisplayEveryInterval(BubbleSort(S3_256, SortDirection), 10);
                                    break;
                                case "m":
                                    DisplayEveryInterval(MergeSort(S3_256, SortDirection), 10);
                                    break;
                                case "d":
                                    DisplayEveryInterval(QuickSort(S3_256, SortDirection), 10);
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 2048:
                    switch (menuChoice)
                    {
                        case 1:
                            switch (SortType)
                            {
                                case "b":
                                    DisplayEveryInterval(BubbleSort(S1_2048, SortDirection), 50);
                                    break;
                                case "m":
                                    DisplayEveryInterval(MergeSort(S1_2048, SortDirection), 50);
                                    break;
                                case "d":
                                    DisplayEveryInterval(QuickSort(S1_2048, SortDirection), 50);
                                    break;
                            }
                            break;
                        case 2:
                            switch (SortType)
                            {
                                case "b":
                                    DisplayEveryInterval(BubbleSort(S2_2048, SortDirection), 50);
                                    break;
                                case "m":
                                    DisplayEveryInterval(MergeSort(S2_2048, SortDirection), 50);
                                    break;
                                case "d":
                                    DisplayEveryInterval(QuickSort(S2_2048, SortDirection), 50);
                                    break;
                            }
                            break;
                        case 3:
                            switch (SortType)
                            {
                                case "b":
                                    DisplayEveryInterval(BubbleSort(S3_2048, SortDirection), 50);
                                    break;
                                case "m":
                                    DisplayEveryInterval(MergeSort(S3_2048, SortDirection), 50);
                                    break;
                                case "d":
                                    DisplayEveryInterval(QuickSort(S3_2048, SortDirection), 50);
                                    break;
                            }
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
                Console.WriteLine("Select Function:\n[1] Display sorted arrays\n[2] Search Arrays\n[3] Concatenate and merge\n[4] Quit");
                int menuChoice = Int16.Parse(Console.ReadLine());
                if (menuChoice == 1)
                {
                    DisplayMenu();
                } else if (menuChoice == 2)
                {
                    SearchMenu();
                } else if (menuChoice == 3)
                {
                    MergeTwoFiles();
                } else if (menuChoice == 4)
                {
                    break;
                }
            } while (true);            
        }       
    }
}