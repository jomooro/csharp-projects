using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 4, 25, 12, 42, 11 };

        Console.WriteLine("Original array:");
        PrintArray(array);

        SelectionSortAlgorithm(array);

        Console.WriteLine("\nSorted array:");
        PrintArray(array);
    }


    static void SelectionSortAlgorithm(int[] arr)
    {
        int n = arr.Length; // Get the length of the array

        // Iterate through the array
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i; // Assume the current index as the minimum index

            // Find the index of the minimum element in the unsorted part of the array
            for (int j = i + 1; j < n; j++)
            {
                // If a smaller element is found, update the minIndex
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap the found minimum element with the first element
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    static void PrintArray(int[] arr)
    {
        // Iterate through the array and print each element
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine(); 
    }
}
