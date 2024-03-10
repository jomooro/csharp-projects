using System;

class InsertionSort
{
    static void Main()
    {
        int[] array = { 12, 11, 13, 5, 6 };

        Console.WriteLine("Original Array:");
        PrintArray(array);

        InsertionSortAlgorithm(array);

        Console.WriteLine("\nSorted Array:");
        PrintArray(array);
    }

    static void InsertionSortAlgorithm(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            // Move elements of arr[0..i-1] that are greater than key
            // to one position ahead of their current position
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
