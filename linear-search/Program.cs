using System;

class LinearSearch
{
    static int LinearSearchFunction(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return i; // Return the index if the target is found
            }
        }
        return -1; // Return -1 if the target is not found in the array
    }

    static void Main()
    {
        int[] array = { 10, 5, 8, 2, 7, 3 };
        int targetValue = 7;

        int result = LinearSearchFunction(array, targetValue);

        if (result != -1)
        {
            Console.WriteLine($"Target value {targetValue} found at index {result}.");
        }
        else
        {
            Console.WriteLine($"Target value {targetValue} not found in the array.");
        }
    }
}
