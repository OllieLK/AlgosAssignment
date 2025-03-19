using System;
using System.IO;

/// PROGRAM: STOCK MARKET VOLUME ANALYZER
/// AUTHOR: OLIVER LAZARUS-KEENE 29218390
/// DATE: 19/02/2025
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
/// own folder if any issues should arise. If there are any further issues, the code can be accessed from my repository:
/// https://github.com/OllieLK/AlgosAssignment
/// 
/// 
/// USAGE:
/// Upon excecution a main menu will display which gives the user options, entered as numbers in the console, to select
/// between the various functions. after a function has been done it will return the user to the menu, where they can do 
/// another function or exit the application.
/// 
/// ALGORITHMS USED:
/// Bubble sort, Merge sort, Insertion sort, Selection Sort.
/// Linear search, Binary search.
/// 
/// PROGRAMMED IN VISUAL STUDIO. OLIVER LAZARUS-KEENE 29218390 


namespace Algorithms
{
    class Program
    {
        // Arrays in which the shares are stored. they are loaded as strings then converted to integers hence the two of each array.
        public static int[] S1_256, S1_2048, S2_256, S2_2048, S3_256, S3_2048;
        public static string[] sS1_256, sS1_2048, sS2_256, sS2_2048, sS3_256, sS3_2048;

        // Functions called at the start of excecution. loads the files and converts them into integers.
        public static int[] ConvertToInteger(string[] s)
        {
            int[] a = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                a[i] = Convert.ToInt32(s[i]); // Loop through and convert one by one
            }
            return a;
        }
        public static void LoadFiles()
        {
            sS1_256 = File.ReadAllLines("Share_1_256.txt"); // Load them all as string[]s 
            sS1_2048 = File.ReadAllLines("Share_1_2048.txt");
            sS2_256 = File.ReadAllLines("Share_2_256.txt");
            sS2_2048 = File.ReadAllLines("Share_2_2048.txt");
            sS3_256 = File.ReadAllLines("Share_3_256.txt");
            sS3_2048 = File.ReadAllLines("Share_3_2048.txt");

            S1_256 = ConvertToInteger(sS1_256); // Convert them all to integers
            S1_2048 = ConvertToInteger(sS1_2048);
            S2_256 = ConvertToInteger(sS2_256);
            S2_2048 = ConvertToInteger(sS2_2048);
            S3_256 = ConvertToInteger(sS3_256);
            S3_2048 = ConvertToInteger(sS3_2048);
        }

        // For converting the array back to strings, so it can be writed to a file to save the result of a merge of two files.
        public static string[] ConvertToString(int[] i)
        {
            List<string> list = new List<string>(); // Using a list here, since i wanted to use a foreach loop and that would have not worked with an array
            string[] strings = new string[i.Length];
            foreach (int j in i)
            {
                list.Add(j.ToString()); // Wanted to try using for each loop.
            }
            strings = list.ToArray(); // Converting the list back to an array and returning it.
            return strings;
        }

        // Simple function to output the array to the user. takes the array to output
        // as a parameter, aswell as the interval (For instance, an interval of 10 would
        // output every 10th element.
        public static void DisplayEveryInterval(int[] Array, int Interval) // DONE
        {
            for (int i = 0; i < Array.Length - 1; i = i + Interval)
            {
                Console.WriteLine(Array[i]);
            }
        }

        // Specific function for the merging of two arrays. concatonates and then performs a merge sort on the result.
        // Also gives user option of saving to a file.
        public static void MergeTwoFiles() // DONE
        {
            int[] array1 = null;
            int[] array2 = null; // Initialize two arrays as null (Dont know which size user wants to use yet)
            int interval = 0;

            Console.WriteLine("256 or 2048 arrays?");
            string arraySize = Console.ReadLine();
            if (arraySize == "256")
                interval = 20; // Set display interval according to arraysize user is using.
            else
                interval = 80;

            // Takes input of the two arrays to merge. returns to main menu if the user chooses same array twice.
            Console.WriteLine("Select array no 1. (1, 2 or 3)");
            string choice1 = Console.ReadLine();
            Console.WriteLine("Select array no 2. (1, 2 or 3)");
            string choice2 = Console.ReadLine();
            if (choice1 == choice2)
            {
                Console.WriteLine("Cannot merge same arrays. Returning to main menu");
                return;
            }

            // This switch block just sets the two arrays to the correct ones the user choose.
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
            int[] ConcatArray = array1.Concat(array2).ToArray(); // Concatonates arrays first.
            ConcatArray = MergeSort(ConcatArray, "a"); // Performs merge sort algorithm on them
            DisplayEveryInterval(ConcatArray, interval); // Display result

            // Logic for saving the new made array if the user wants to
            Console.WriteLine("Do you want to save this as a new file? y/n");
            string saveChoice = Console.ReadLine();
            if (saveChoice == "y")
            {
                string[] saveArray = ConvertToString(ConcatArray);
                Console.WriteLine("Enter file name (no extension needed)");
                string fileName = Console.ReadLine();
                try // saving done within try block incase of any file errors.
                {
                    System.IO.File.WriteAllLines((fileName + ".txt"), saveArray);
                    Console.WriteLine("Saving Complete");
                }
                catch
                {
                    Console.WriteLine("Saving Failed");
                }
            }
        }

        //      SORTING ALGORTITHMS
        // 4 sorting algortithms the program uses. each takes two parameters, an array of integers and a string for the direction
        // They each return an array of integers, which are sorted. further details of how they work are commented within each function
        public static int[] BubbleSort(int[] arraytosort, string Direction) // DONE
        {
            int temp; // Temp for storing value when swapping
            bool swapped; // Bool to not continue if no swaps are done - array sorted

            for (int i = 0; i < arraytosort.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < arraytosort.Length - i - 1; j++)
                {
                    if (Direction == "a")
                    {
                        if (arraytosort[j] > arraytosort[j + 1]) // Comparison of two elements based on the direction, greater for ascending
                        {
                            // swap over the elements using the temp variable
                            temp = arraytosort[j];
                            arraytosort[j] = arraytosort[j + 1];
                            arraytosort[j + 1] = temp;
                            swapped = true; // Swapped set true, so the loop continues.
                        }
                    }
                    else if (Direction == "d")
                    {
                        if (arraytosort[j] < arraytosort[j + 1]) // smaller than for descending, so its sorted going down.
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
                    return arraytosort; // return if sorted.
                }
            }
            return arraytosort;
        }
        public static int[] SelectionSort(int[] arraytosort, string direction) // DONE
        {
            int temp; // Temp for swapping
            int selectedIndex;
            int length = arraytosort.Length;

            for (int i = 0; i < length; i++)
            {
                selectedIndex = i; // set current index to the first value in array
                for (int j = i + 1; j < length; j++)  // Find smallest / largest in array
                {
                    if (direction == "a" && arraytosort[j] < arraytosort[selectedIndex])
                        selectedIndex = j;

                    if (direction == "d" && arraytosort[j] > arraytosort[selectedIndex])
                        selectedIndex = j;
                }
                if (selectedIndex != i) // If changed, swap accordingly
                {
                    temp = arraytosort[i];
                    arraytosort[i] = arraytosort[selectedIndex];
                    arraytosort[selectedIndex] = temp;
                }
            }
            return arraytosort;
        }
        public static int[] InsertionSort(int[] arraytosort, string direction)
        {
            int n = arraytosort.Length;

            for (int i = 1; i < n; i++) // Starts from one (Because we check i-1, so first gets checked)
            {
                int current = arraytosort[i]; // Current element to be placed
                int j = i - 1;

                if (direction == "a") // Ascending order
                {
                    while (j >= 0 && arraytosort[j] > current)
                    {
                        arraytosort[j + 1] = arraytosort[j];
                        j--;
                    }
                }
                else // Descending order
                {
                    while (j >= 0 && arraytosort[j] < current)
                    {
                        arraytosort[j + 1] = arraytosort[j];
                        j--;
                    }
                }

                arraytosort[j + 1] = current; // Place element
            }

            return arraytosort;
        }
        public static int[] MergeSort(int[] arrayToSort, string direction) // DONE
        {
            if (arrayToSort.Length == 1)
                return arrayToSort; // Base case: Return if length is 1; array already sorted (Stops stack overflow)

             
            // SPLITTING THE ARRAY INTO TO HALFS: (Mid set to half of current length)
            int mid = arrayToSort.Length / 2;
            int[] left = new int[mid]; // Create left and right subarrays
            int[] right = new int[arrayToSort.Length - mid];
            // Fill left array with correct values from array
            for (int i = 0; i < mid; i++)
            {
                left[i] = arrayToSort[i];
            }
            // Same for right array
            for (int i = mid; i < arrayToSort.Length; i++)
            {
                right[i - mid] = arrayToSort[i];
            }


            // Recursively sort both halves of the array (Will be called again and break down further)
            left = MergeSort(left, direction);
            right = MergeSort(right, direction);

            return Merge(left, right, direction);
        }
        public static int[] Merge(int[] left, int[] right, string direction)// DONE
        {
            int[] result = new int[left.Length + right.Length]; // Initialize a new array for result of merge (Length set to sum of left and right)
            int i = 0, j = 0, k = 0; // Indexes for subarrays.

            // Merge the two sorted subarrays based on direction
            while (i < left.Length && j < right.Length)
            {
                if (direction == "a") // Ascending order
                {
                    if (left[i] <= right[j])
                    {
                        result[k++] = left[i++];
                    }
                    else
                    {
                        result[k++] = right[j++];
                    }
                }
                else // Descending order
                {
                    if (left[i] >= right[j])
                    {
                        result[k++] = left[i++];
                    }
                    else
                    {
                        result[k++] = right[j++];
                    }
                }
            }

            // if there is a remaining element (List not even in size) add too array
            while (i < left.Length)
            {
                result[k++] = left[i++];
            }
            while (j < right.Length)
            {
                result[k++] = right[j++];
            }

            return result;
        }

        //      SEARCHING ALGORTIHMS
        // Takes the array to search as a parameter and outputs the results of the search
        // Returns nothing as output for both is done within function
        public static void LinearSearch(int[] arrayToSearch, int searchItem) // DONE
        {
            List<int> indexes = new List<int>(); // List for storing indexes found
            int closestValue = arrayToSearch[0]; // Closest value - initialized as the first element in the array
            int minDiff = Math.Abs(arrayToSearch[0] - searchItem); // Difference between element and closest value - so if is ever smaller than this set the new closest value

            for (int i = 0; i < arrayToSearch.Length; i++) // loop through array 
            {
                if (arrayToSearch[i] == searchItem)
                {
                    indexes.Add(i); // if its a match add to indexes
                }
                else
                {
                    int diff = Math.Abs(arrayToSearch[i] - searchItem); // find difference between current element and search item
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        closestValue = arrayToSearch[i]; // if the difference is lower than the minimum, set closest value to this element
                    }
                }
            }
            if (indexes.Count == 0)
            {
                Console.WriteLine("Not Present In Array, the closest value is: " + closestValue); // output closest value if not found
            }
            else
            {
                Console.Write("Found At Position (Indexing starts at 0): ");
                for (int i = 0; i < indexes.Count; i++)
                {
                    Console.Write(indexes[i] + ", "); // loop through and output indexs where search term found.
                }
                Console.ReadLine();
            }
        }
        public static void BinarySearch(int[] arr, int searchTerm) // DONE
        {
            arr = BubbleSort(arr, "a"); // Sort the array using my bubble sort function before running search

            int left = 0, right = arr.Length - 1;// Set left and rights equal to bounds of array
            List<int> indexes = new List<int>(); // Indexes where found

            // Initialize closest value, minimum differnce same as the linear search.
            int closestValue = arr[0];
            int minDiff = Math.Abs(arr[0] - searchTerm);
            bool found = false;

            while (left <= right)
            {
                // Set the mid correctly based on new left and right values after the pass.
                int mid = left + (right - left) / 2;

                if (arr[mid] == searchTerm)
                {
                    // if the new mid is the search term, set found to true and add the index to the list
                    found = true;
                    indexes.Add(mid);

                    // Find duplicates (Would be adjacent as array sorted)
                    int temp = mid - 1;
                    while (arr[temp] == searchTerm) // Check lower than mid
                    {
                        indexes.Add(temp);
                        temp--;
                    }

                    temp = mid + 1;
                    while (arr[temp] == searchTerm) // Check higher than mid
                    {
                        indexes.Add(temp);
                        temp++;
                    }

                    break; // as found break out of loop - save time.
                }

                // Check and alter closest value and minimum difference, same as in linear search
                int diff = Math.Abs(arr[mid] - searchTerm);
                if (diff < minDiff)
                {
                    minDiff = diff;
                    closestValue = arr[mid];
                }



                if (arr[mid] < searchTerm)
                    left = mid + 1; // Update new left bound if the search term is larger than current middle
                else
                    right = mid - 1; // Update right bound in opposite manner
            }

            if (found) // Output results in the same manner as linear search
            {
                Console.Write("Found at positions (Within array - after its been sorted): ");
                Console.WriteLine(string.Join(", ", indexes));
            }
            else
            {
                Console.WriteLine("Not present in array, closest value is: " + closestValue);
            }
        }

        //      MENUS FOR THE TWO MAIN FUNCTIONS
        public static void DisplayMenu() // DONE
        {
            // Take inputs from user for which algorithm to use and on what array, in what direction
            Console.WriteLine("Using Bubble(b), Merge(m), Selection(s), Or Insertion(i)");
            string SortType = Console.ReadLine();
            Console.WriteLine("Sort Going Up (a) or down (d)");
            string SortDirection = Console.ReadLine();
            Console.WriteLine("Show 256 or 2048 array?");
            int ArrayType = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Array no 1, 2, or 3?");
            int menuChoice = Int16.Parse(Console.ReadLine());

            // nested switch blocks to show user selected array and set interval correctly.
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
                                case "i":
                                    DisplayEveryInterval(InsertionSort(S1_256, SortDirection), 10);
                                    break;
                                case "s":
                                    DisplayEveryInterval(SelectionSort(S1_256, SortDirection), 10); 
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
                                case "i":
                                    DisplayEveryInterval(InsertionSort(S2_256, SortDirection), 10);
                                    break;
                                case "s":
                                    DisplayEveryInterval(SelectionSort(S2_256, SortDirection), 10);
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
                                case "i":
                                    DisplayEveryInterval(InsertionSort(S3_256, SortDirection), 10);
                                    break;
                                case "s":
                                    DisplayEveryInterval(SelectionSort(S3_256, SortDirection), 10);
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
                                case "i":
                                    DisplayEveryInterval(InsertionSort(S1_2048, SortDirection), 50);
                                    break;
                                case "s":
                                    DisplayEveryInterval(SelectionSort(S1_2048, SortDirection), 10);
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
                                case "i":
                                    DisplayEveryInterval(InsertionSort(S2_2048, SortDirection), 50);
                                    break;
                                case "s":
                                    DisplayEveryInterval(SelectionSort(S2_2048, SortDirection), 10);
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
                                case "i":
                                    DisplayEveryInterval(InsertionSort(S3_2048, SortDirection), 50);
                                    break;
                                case "s":
                                    DisplayEveryInterval(SelectionSort(S3_2048, SortDirection), 10);
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
        public static void SearchMenu() // DONE
        {
            // Take inputs of what array, how to search, and the search term.
            Console.WriteLine("Enter Search Term (Integer)");
            int SearchTerm = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Using linear search or binary search? b/l");
            string SearchType = Console.ReadLine();
            Console.WriteLine("Search 256 or 2048 array?");
            int ArrayType = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Array no 1, 2, or 3?");
            int menuChoice = Int16.Parse(Console.ReadLine());

            int[] SelectedArray = null; // Initialize selected array as null - will be assigned in switch block

            // Set the selected array correct to the users choice
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

            // Perform requested search
            if (SearchType == "b")
                BinarySearch(SelectedArray, SearchTerm);
            else
                LinearSearch(SelectedArray, SearchTerm);
        }

        // Entry point, loads files and contains main menu
        public static void Main(string[] args)// DONE
        {
            
            try // Loading files done in try block incase there are any file errors
            {
                LoadFiles();
                Console.WriteLine("Files loaded successfully");
            }
            catch
            {
                Console.WriteLine("File loading error");
            }

            do // Main menu done in a loop, so returns after functions finished and can select another function
            {
                Console.WriteLine("Select Function:\n[1] Display sorted arrays\n[2] Search Arrays\n[3] Concatenate and merge\n[4] Quit");
                int menuChoice = Int16.Parse(Console.ReadLine());
                if (menuChoice == 1)
                {
                    DisplayMenu();
                }
                else if (menuChoice == 2)
                {
                    SearchMenu();
                }
                else if (menuChoice == 3)
                {
                    MergeTwoFiles();
                }
                else if (menuChoice == 4)
                {
                    break; // break out and close program if user wants to
                }
            } while (true);
        }
    }
}