using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Generate a list of 25 random numbers
        List<int> randomNumbers = GenerateRandomNumbers();
        Console.WriteLine("Random Numbers: " + string.Join(", ", randomNumbers));

        // Sort the numbers in descending order using radix sort
        List<int> sortedDesc = new List<int>(randomNumbers);
        RadixSort(sortedDesc);
        sortedDesc.Reverse(); // Reverse for descending order
        Console.WriteLine("Sorted Numbers (Descending, Radix Sort): " + string.Join(", ", sortedDesc));

        // Sort the numbers in ascending order using bubble sort
        List<int> sortedAsc = new List<int>(randomNumbers);
        BubbleSort(sortedAsc);
        Console.WriteLine("Sorted Numbers (Ascending, Bubble Sort): " + string.Join(", ", sortedAsc));

        // Prompt the user to enter the number to search for
        Console.Write("Enter the number to search for: ");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }

        // Search for the number using binary search
        int index = BinarySearch(sortedAsc, k);
        if (index != -1)
        {
            Console.WriteLine($"Number {k} found at index {index} using binary search.");
        }
        else
        {
            Console.WriteLine($"Number {k} not found using binary search.");
        }
    }

    static List<int> GenerateRandomNumbers(int size = 25, int maxValue = 100)
    {
        Random rnd = new Random();
        List<int> numbers = new List<int>();
        for (int i = 0; i < size; i++)
        {
            numbers.Add(rnd.Next(1, maxValue + 1));
        }
        return numbers;
    }

    // Radix sort helper functions
    static void CountingSort(List<int> arr, int exp)
    {
        int n = arr.Count;
        int[] output = new int[n];
        int[] count = new int[10];

        // Store count of occurrences in count[]
        for (int i = 0; i < n; i++)
        {
            int index = (arr[i] / exp) % 10;
            count[index]++;
        }

        // Change count[i] so that count[i] now contains actual
        // position of this digit in output[]
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Build the output array
        for (int i = n - 1; i >= 0; i--)
        {
            int index = (arr[i] / exp) % 10;
            output[count[index] - 1] = arr[i];
            count[index]--;
        }

        // Copy the output array to arr[], so that arr[] now
        // contains sorted numbers according to the current digit
        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }

    static void RadixSort(List<int> arr)
    {
        // Find the maximum number to know the number of digits
        int maxNum = arr[0];
        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] > maxNum)
            {
                maxNum = arr[i];
            }
        }

        // Do counting sort for every digit
        for (int exp = 1; maxNum / exp > 0; exp *= 10)
        {
            CountingSort(arr, exp);
        }
    }

    // Bubble sort function
    static void BubbleSort(List<int> arr)
    {
        int n = arr.Count;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }

    // Binary search function
    static int BinarySearch(List<int> arr, int k)
    {
        int low = 0;
        int high = arr.Count - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == k)
            {
                return mid;
            }
            else if (arr[mid] < k)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1; // not found
    }
}
