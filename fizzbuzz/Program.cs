using System;
using System.Collections.Generic;

class Program
{
    public string CheckNumber(int number)
    {
        if (number % 3 == 0 && number % 5 == 0)
            return "FizzBuzz";
        if (number % 3 == 0)
            return "Fizz";
        if (number % 5 == 0)
            return "Buzz";
        
        return number.ToString();
    }

    public string CountTo(int limit)
    {
        List<string> result = new List<string>();

        for (int i = 1; i <= limit; i++)
        {
            result.Add(CheckNumber(i));
        }

        return "[" + string.Join(", ", result) + "]";
    }

    static void Main()
    {
        Program program = new Program();
        Console.WriteLine(program.CountTo(15));
    }
}
