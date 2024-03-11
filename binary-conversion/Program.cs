using System;

class BinaryConverter
{
    static void Main()
    {
        string binaryNumber = "101011";
        try
        {
            int decimalValue = BinaryConversion(binaryNumber);
            Console.WriteLine($"Binary: {binaryNumber}\nDecimal: {decimalValue}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    /**
     * Converts a binary number to its decimal representation.
     * 
     * @param binaryNumber the binary number to be converted.
     * @return the decimal representation of the binary number.
     * @throws ArgumentException if the input is not a valid binary number.
     */
    static int BinaryConversion(string binaryNumber)
    {
        // Check if the input is a valid binary number
        if (!IsBinary(binaryNumber))
        {
            throw new ArgumentException("Invalid binary number");
        }

        int decimalValue = 0;
        int power = 0;

        // Iterate through the binary digits from right to left
        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {
            int digit = binaryNumber[i] - '0'; // Convert character to integer

            // Calculate the decimal value using the formula: decimal = d0×2^0 + d1×2^1 + d2×2^2 + ...
            decimalValue += digit * (int)Math.Pow(2, power);
            power++;
        }

        return decimalValue;
    }

    /**
     * Checks if the given string is a valid binary number.
     * 
     * @param binaryNumber the string to be checked.
     * @return true if the string is a valid binary number, false otherwise.
     */
    static bool IsBinary(string binaryNumber)
    {
        foreach (char digit in binaryNumber)
        {
            if (digit != '0' && digit != '1')
            {
                return false;
            }
        }
        return true;
    }
}
