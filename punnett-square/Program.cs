using System;

class Program
{
    static void Main()
    {
        // Usage
        string genotype1 = "T";
        string genotype2 = "t";

        string[][] result = PunnettSquare(genotype1, genotype2);

        // Display the Punnett square
        DisplayPunnettSquare(result);
    }

    static string[][] PunnettSquare(string genotype1, string genotype2)
    {
        // Define the possible alleles
        string[] alleles = { genotype1, genotype2 };

        // Initialize the Punnett square with empty strings
        string[][] punnettSquare = new string[alleles.Length + 1][];
        for (int i = 0; i < punnettSquare.Length; i++)
        {
            punnettSquare[i] = new string[alleles.Length + 1];
            for (int j = 0; j < punnettSquare[i].Length; j++)
            {
                punnettSquare[i][j] = "";
            }
        }

        // Fill in the headers
        punnettSquare[0][0] = "";
        for (int i = 1; i < punnettSquare.Length; i++)
        {
            punnettSquare[i][0] = alleles[i - 1];
            punnettSquare[0][i] = alleles[i - 1];
        }

        // Fill in the Punnett square with all possible combinations
        for (int i = 1; i < punnettSquare.Length; i++)
        {
            for (int j = 1; j < punnettSquare[i].Length; j++)
            {
                punnettSquare[i][j] = alleles[i - 1] + alleles[j - 1];
            }
        }

        return punnettSquare;
    }

    static void DisplayPunnettSquare(string[][] punnettSquare)
    {
        for (int i = 0; i < punnettSquare.Length; i++)
        {
            for (int j = 0; j < punnettSquare[i].Length; j++)
            {
                Console.Write(punnettSquare[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
