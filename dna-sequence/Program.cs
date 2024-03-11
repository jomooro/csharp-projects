using System;

class DnaSequence
{
    static void Main()
    {

        string dnaSequence1 = "ATGCGATACTGA";
        string dnaSequence2 = "ATGCGATAGA";

        Console.WriteLine($"Is {dnaSequence1} a valid protein? {DnaProtein(dnaSequence1)}");
        Console.WriteLine($"Is {dnaSequence2} a valid protein? {DnaProtein(dnaSequence2)}");
    }

    static bool DnaProtein(string dna)
    {
        // Get the length of the DNA sequence
        int dnaLength = dna.Length;

        // Check if the length is less than 6 or not a multiple of 3
        if (dnaLength < 6 || dnaLength % 3 != 0)
        {
            return false;
        }

        // Check if the DNA sequence starts with "ATG" and ends with "TGA"
        if (!dna.StartsWith("ATG") || !dna.EndsWith("TGA"))
        {
            return false;
        }

        // If all conditions are met, the DNA sequence is considered a valid protein
        return true;
    }
}

