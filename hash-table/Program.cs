using System;
using System.Collections;

class HashTable
{
    static void Main()
    {
        Hashtable myHashTable = new Hashtable();

        // Adding key-value pairs to the hash table
        myHashTable.Add("Key1", "Value1");
        myHashTable.Add("Key2", "Value2");
        myHashTable.Add("Key3", "Value3");

        // Accessing values using keys
        Console.WriteLine("Value for Key1: " + myHashTable["Key1"]);
        Console.WriteLine("Value for Key2: " + myHashTable["Key2"]);
        Console.WriteLine("Value for Key3: " + myHashTable["Key3"]);

        // Checking if a key exists
        string keyToCheck = "Key4";
        if (myHashTable.ContainsKey(keyToCheck))
        {
            Console.WriteLine("Value for " + keyToCheck + ": " + myHashTable[keyToCheck]);
        }
        else
        {
            Console.WriteLine(keyToCheck + " not found in the hash table.");
        }

        // Removing a key-value pair
        string keyToRemove = "Key2";
        if (myHashTable.ContainsKey(keyToRemove))
        {
            myHashTable.Remove(keyToRemove);
            Console.WriteLine("Key2 removed from the hash table.");
        }
        else
        {
            Console.WriteLine(keyToRemove + " not found in the hash table.");
        }

        // Displaying all key-value pairs
        Console.WriteLine("\nKey-Value pairs in the hash table:");
        foreach (DictionaryEntry entry in myHashTable)
        {
            Console.WriteLine(entry.Key + ": " + entry.Value);
        }
    }
}
